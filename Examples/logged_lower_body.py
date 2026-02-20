import sys
import time

import example_models
import imumocap
import imumocap.solvers
import imumocap.viewer
import ximu3csv
from imumocap import Matrix
from imumocap.solvers import Mounting

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Import IMU data
devices = ximu3csv.read("logged_lower_body", ximu3csv.DataMessageType.QUATERNION)

FPS = 30

devices = ximu3csv.resample(devices, FPS)

imus_frames = [{d.device_name: Matrix(quaternion=d.quaternion.quaternion.wxyz[i]) for d in devices} for i, _ in enumerate(devices[0].quaternion.timestamp)]

# Load model
model = example_models.LowerBody()

# Calibrate IMU alignment (logged data must start in calibration pose)
imumocap.solvers.calibrate(model.root, imus_frames[0], mounting=Mounting.Z_BACKWARD)

# Create animation frames
pose_frames: list[dict[str, imumocap.Matrix]] = []

for imus_frame in imus_frames:
    imumocap.set_pose_from_imus(model.root, imus_frame)

    imumocap.solvers.floor(model.root)

    pose_frames.append(imumocap.get_pose(model.root))

# Plot
imumocap.plot(model.root, pose_frames, block=not dont_block)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

while True:
    for pose_frame in pose_frames:
        time.sleep(1 / FPS)

        imumocap.set_pose(model.root, pose_frame)

        viewer.send_frame(
            [
                *imumocap.viewer.link_to_primitives(model.root),
                *imumocap.viewer.joints_to_primitives(model.joints, mirror="Left"),
            ]
        )

    if dont_block:
        break
