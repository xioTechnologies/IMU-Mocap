import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
import numpy as np
import ximu3
import ximu3_helpers
from imumocap import Matrix, Model
from scipy.optimize import minimize
from scipy.spatial.transform import Rotation as R

# Load model
model = imumocap.file.load_model("left_hand_model.json")

calibration_pose = model.get_pose()

# Connect to IMUs
twintig_connection = ximu3_helpers.quick_connect("Twintig")

imu_connections = ximu3_helpers.mux_connect(twintig_connection, 20, dictionary=True)

for connection in [twintig_connection] + [c for c in imu_connections.values()]:
    connection.send_command('{"color":"#04000F"}')


def get_imus() -> imumocap.Imus:
    def matrix_from(message: ximu3.QuaternionMessage) -> imumocap.Matrix:
        return imumocap.Matrix(quaternion=[message.w, message.x, message.y, message.z]) if message else imumocap.Matrix()

    return {n: matrix_from(c.get_quaternion_message()) for n, c in imu_connections.items()}


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
    model: Model,
    imus_a: imumocap.Imus,
    imus_b: imumocap.Imus,
) -> HeadingTrims:
    # TODO: exception if rot_y > 80 for any IMU (or root only?)
    # TODO: exception if imus_a.keys() != imus_b.keys()
    # TODO: exception if root.name not in imus_a.keys()

    # TODO: zero all IMUs first (or root only?)

    heading_trims = {n: Matrix(rot_z=_find_heading(model.root.name, n, imus_a, imus_b)) for n in imus_a.keys()}

    return heading_trims


def apply(
    imus: imumocap.Imus,
    heading_trims: HeadingTrims,
) -> imumocap.Imus:
    return {n: heading_trims[n] * i for n, i in imus.items()}


def update(
    model: Model,
    joints: imumocap.Joints,
    heading_trims: HeadingTrims,
) -> HeadingTrims:
    return heading_trims


# Calibrate
imus_a = get_imus()

input("Please rotate the hand and then press Enter")

imus_b = get_imus()

heading_trims = zero(model, imus_a, imus_b)

calibrated_heading = imumocap.solvers.calibrate(model, apply(imus_a, heading_trims), calibration_pose, imumocap.solvers.Mounting.Y_BACKWARD)

print("Calibrated")

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    imus = apply(get_imus(), heading_trims)

    model.set_pose_from_imus(imus, -calibrated_heading)

    viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))
