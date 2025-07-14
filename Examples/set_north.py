import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
import ximu3s
from imumocap import Link, Matrix
from imumocap.solvers import Mounting


# # get negated heading?
# # get heading alignment inverse?
# def get_heading_alignment(joint: Matrix) -> Matrix:
#     heading = joint.rot_xyz[2]
#     return Matrix(rot_z=-heading)  # inverse


# def set_pose_from_imus(
#     root: Link,
#     imus: dict[str, Matrix],  # {<link name>: <IMU measurement>, ...}
#     world_alignment: Matrix,  # arbitrary world alignment matrix
# ) -> None:
#     links = {l.name: l for l in root.flatten()}

#     for name, matrix in imus.items():
#         links[name].set_joint_from_imu_world(world_alignment * matrix)


# Load model
root, joints = imumocap.file.load_model("model.json")

calibration_pose = imumocap.get_pose(root)

# Connect to and configure IMUs
imus = ximu3s.setup([l.name for l in root.flatten() if l.name])

# Stream to IMU Mocap Viewer
viewer_connection = imumocap.viewer.Connection()

mounting = Mounting.Z_FORWARDS

north = imumocap.solvers.SetNorth(mounting)

while True:
    time.sleep(1 / 30)  # 30 fps

    imus_matrix = {n: i.matrix for n, i in imus.items()}

    if any([i.button_pressed for i in imus.values()]):
        print("Please hold the calibration pose")

        time.sleep(2)

        imus_matrix = {n: i.matrix for n, i in imus.items()}  # grab the current state of the imus

        imumocap.solvers.calibrate(root, imus_matrix, calibration_pose, mounting)

        north.set(imus_matrix[root.name])

        print("Calibrated")

    imus_matrix = north.apply(imus_matrix)

    imumocap.set_pose_from_imus(root, imus_matrix)

    imumocap.solvers.translate(root, [0, 0, 0.5])

    viewer_connection.send(
        [
            *imumocap.viewer.link_to_primitives(root),
            *imumocap.viewer.joints_to_primitives(joints, "Left"),
        ]
    )
