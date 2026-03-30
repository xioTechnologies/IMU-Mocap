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
# model = imumocap.file.load_model("left_hand_model.json")
model = imumocap.file.load_model("right_hand_model_new.json")
# model = imumocap.file.load_model("left_hand_single_finger_model.json")

calibration_pose = model.get_pose()

# Connect to IMUs
twintig_connection = ximu3_helpers.quick_connect("Twintig")  # , keep_open=True

imu_connections = ximu3_helpers.mux_connect(twintig_connection, 20, dictionary=True)

imu_connections = {n: imu for n, imu in imu_connections.items() if n in model.links.keys()}

for connection in [twintig_connection] + [c for c in imu_connections.values()]:
    connection.send_command('{"color":"#040F00"}')


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
    imus: imumocap.Imus,
    heading_trims: HeadingTrims,
    # calibrated_heading: float,
) -> HeadingTrims:
    names = list(heading_trims.keys())
    
    og_heading_trims = heading_trims 

    def objective(x: list[float]) -> float:
        offset_trims: HeadingTrims = {n: Matrix(rot_z=x_val) for n, x_val in zip(names, x)}

        candidate_trims: HeadingTrims = {n: offset_trims[n] * og_heading_trims[n] for n in names}  # combine with og_heading _trim

        model.set_pose_from_imus(apply(imus, candidate_trims))  # , -calibrated_heading)

        return sum(j.get_error() for j in model.joints.values())

    x0 = [heading_trims[n].rot_xyz[2] for n in names]
    # x0 = [0 for _ in names]

    result = minimize(objective, x0)  # valid only when combined with og_heading _trim

    # result = result combined with og_heading _trim

    return {n: Matrix(rot_z=x) * og_heading_trims[n] for n, x in zip(names, result.x)}


# Calibrate
imus_a = get_imus()

input("Please rotate the hand and then press Enter")

imus_b = get_imus()

heading_trims = zero(model, imus_a, imus_b)

calibrated_heading = imumocap.solvers.calibrate(model, apply(imus_a, heading_trims), calibration_pose, imumocap.solvers.Mounting.Y_FORWARD)

print("Calibrated")

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

counter = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    counter += 1

    raw_imus = get_imus()

    # if counter > 100:
    #     counter = 0
    #     heading_trims = update(model, raw_imus, heading_trims)  # , calibrated_heading)

    imus = apply(raw_imus, heading_trims)

    model.set_pose_from_imus(imus, -calibrated_heading)

    viewer.send_frame(imumocap.viewer.model_to_primitives(model))
