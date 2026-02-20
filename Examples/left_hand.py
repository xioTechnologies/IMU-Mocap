import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
import numpy as np
import ximu3
from imumocap import Link, Matrix, Model
from scipy.optimize import minimize
from scipy.spatial.transform import Rotation as R

# Load model
root, joints = imumocap.file.load_model("left_hand_model.json")

model = Model(root, joints)

calibration_pose = model.get_pose()

# Connect to IMUs
devices = ximu3.PortScanner.scan()

time.sleep(1)  # wait for OS to release port

devices = [d for d in devices if "Carpus" in d.device_name]

if not devices:
    raise Exception("Carpus not found")

print(f"Found {devices[0]}")

carpus_connection = ximu3.Connection(devices[0].connection_config)

carpus_connection.open()


class MuxConnection:
    __quaternion = None

    def __init__(self, config: ximu3.MuxConnectionConfig) -> None:
        self.__connection = ximu3.Connection(config)

        self.__connection.open()

        self.__connection.add_quaternion_callback(self.__quaternion_callback)

        self.__connection.send_command('{"heading":0}')  # TODO: this should be done in solver, not here

    @property
    def internal(self) -> ximu3.Connection:
        return self.__connection

    def get_quaternion(self) -> ximu3.QuaternionMessage:
        return self.__quaternion

    def __quaternion_callback(self, message: ximu3.QuaternionMessage) -> None:
        self.__quaternion = np.array([message.w, message.x, message.y, message.z])


mux_connections = {c.internal.ping().device_name: c for c in [MuxConnection(ximu3.MuxConnectionConfig(c, carpus_connection)) for c in range(0x41, 0x55)]}


def get_imus() -> imumocap.Imus:
    return {n: Matrix(quaternion=c.get_quaternion()) for n, c in mux_connections.items()}


for connection in [carpus_connection] + [c.internal for c in mux_connections.values()]:
    connection.send_command('{"color":"#04000F"}')


# Heading solver
type HeadingTrims = dict[str, Matrix]  # {<link name>: <heading trim>, ...}


def _find_heading(root_name: str, imu_name: str, frame_a: imumocap.Imus, frame_b: imumocap.Imus) -> float:
    root_a, root_b = frame_a[root_name], frame_b[root_name]
    link_a, link_b = frame_a[imu_name], frame_b[imu_name]

    return minimize(
        lambda x: np.rad2deg((R.from_matrix((root_a.inverse * Matrix(rot_z=x[0]) * link_a).rotation) * R.from_matrix((root_b.inverse * Matrix(rot_z=x[0]) * link_b).rotation).inv()).magnitude()),
        [0],
    ).x[0]


def zero(
    root: Link,
    imus_a: imumocap.Imus,
    imus_b: imumocap.Imus,
) -> HeadingTrims:
    # TODO: exception if rot_y > 80 for any IMU (or root only?)
    # TODO: exception if imus_a.keys() != imus_b.keys()
    # TODO: exception if root.name not in imus_a.keys()

    # TODO: zero all IMUs first (or root only?)

    heading_trims = {n: Matrix(rot_z=_find_heading(root.name, n, imus_a, imus_b)) for n in imus_a.keys()}

    return heading_trims


def apply(
    imus: imumocap.Imus,
    heading_trims: HeadingTrims,
) -> imumocap.Imus:
    return {n: heading_trims[n] * i for n, i in imus.items()}


def update(
    root: Link,
    joints: imumocap.Joints,
    heading_trims: HeadingTrims,
) -> HeadingTrims:
    return heading_trims


# Calibrate
imus_a = get_imus()

input("Please rotate the hand and then press Enter")

imus_b = get_imus()

heading_trims = zero(model.root, imus_a, imus_b)

calibrated_heading = imumocap.solvers.calibrate(model.root, apply(imus_a, heading_trims), calibration_pose, imumocap.solvers.Mounting.Y_BACKWARD)

print("Calibrated")

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    imus = apply(get_imus(), heading_trims)

    model.set_pose_from_imus(imus, -calibrated_heading)

    viewer.send_frame(
        [
            *imumocap.viewer.link_to_primitives(model.root),
        ]
    )
