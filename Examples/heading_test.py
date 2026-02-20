import imumocap
import imumocap.solvers
import matplotlib.pyplot as plt
import numpy as np
from imumocap import Link, Matrix, Model
from imumocap.solvers import Mounting
from scipy.optimize import minimize
from scipy.spatial.transform import Rotation as R

# Create model
metacarpal_1 = Link("Metacarpal 1", Matrix(x=1))
metacarpal_2 = Link("Metacarpal 2", Matrix(x=1))
metacarpal_3 = Link("Metacarpal 3", Matrix(x=1))

carpus = Link("Carpus", Matrix(x=1))

carpus.connect(metacarpal_1, Matrix(rot_z=-30))
carpus.connect(metacarpal_2)
carpus.connect(metacarpal_3, Matrix(rot_z=30))

calibration_pose = imumocap.get_pose(carpus)

model = Model(carpus)

# print(metacarpal_1.get_imu_world())

# Generate IMU measurements
pose_frames: list[imumocap.Pose] = []
imus_frames: list[imumocap.Imus] = []

for angle in [90 * np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Carpus"] = Matrix(rot_x=angle)

    pose_frames.append(model.get_pose())

    imus_frames.append({link.name: link.get_imu_world() for link in model.root.flatten()})

# imumocap.plot(carpus, pose_frames)

# Zero heading for all IMUs at start
heading_offsets = {n: i.rot_xyz[2] for n, i in imus_frames[0].items()}

imus_frames = [{n: Matrix(rot_z=-heading_offsets[n]) * i for n, i in i.items()} for i in imus_frames]

# Correct IMUs that did not have a physical heading the same as root when heading zeroed above
heading_offsets = {n: 0 for n in imus_frames[0].keys()}  # heading of each IMU in the first frame

imus_rotated = imus_frames[int(len(imus_frames) / 2)]  # sample when hand inclined ~90 degrees
model.set_pose_from_imus(imus_rotated)


def objective_function(x, root_a: Matrix, root_b: Matrix, subject_a: Matrix, subject_b: Matrix):
    candidate = Matrix(rot_z=x[0])

    a = root_a.inverse * candidate * subject_a
    b = root_b.inverse * candidate * subject_b

    return np.rad2deg((R.from_matrix(a.rotation) * R.from_matrix(b.rotation).inv()).magnitude())


def find_heading(root_name: str, imu_name: str, frame_a: imumocap.Imus, frame_b: imumocap.Imus) -> float:
    return minimize(
        objective_function,
        [0],
        (frame_a[root_name], frame_b[root_name], frame_a[imu_name], frame_b[imu_name]),
        method="Nelder-Mead",
        options={"maxiter": 10000, "maxfev": 20000, "disp": False},
    ).x[0]


# find individual headings
heading_offsets = {n: -find_heading("Carpus", n, imus_frames[0], imus_rotated) for n, i in imus_frames[0].items()}

# apply new headings to the frames
imus_frames = [{n: Matrix(rot_z=-heading_offsets[n]) * i for n, i in i.items()} for i in imus_frames]

# Calibrate IMU alignmnet
calibrated_heading = imumocap.solvers.calibrate(model.root, imus_frames[0], calibration_pose, mounting=Mounting.X_FORWARD)  # always zero because of zero heading above

# Recreate from IMU measurements
pose_frames: list[imumocap.Pose] = []

for imus_frame in imus_frames:
    model.set_pose_from_imus(imus_frame, calibrated_heading)

    pose_frames.append(model.get_pose())

imumocap.plot(model, pose_frames)
