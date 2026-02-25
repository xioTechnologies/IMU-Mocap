import sys
import time

import imumocap
import imumocap.solvers
import imumocap.viewer
import ximu3csv
from imumocap import Matrix
from imumocap.solvers import Mounting

import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Import IMU data
devices = ximu3csv.read("logged_lower_body", ximu3csv.DataMessageType.QUATERNION)

FPS = 30

devices = ximu3csv.resample(devices, FPS)

imus_frames = [{d.device_name: Matrix(quaternion=d.quaternion.quaternion.wxyz[i]) for d in devices} for i, _ in enumerate(devices[0].quaternion.timestamp)]

# Load model
model = models.Factory().lower_body()

# Calibrate IMU alignment (logged data must start in calibration pose)
imumocap.solvers.calibrate(model, imus_frames[0], mounting=Mounting.Z_BACKWARD)

# Create animation frames
pose_frames: list[imumocap.Pose] = []

for imus_frame in imus_frames:
    model.set_pose_from_imus(imus_frame)

    imumocap.solvers.floor(model)

    pose_frames.append(model.get_pose())

# Plot
imumocap.plot(model, pose_frames, block=not dont_block)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

while True:
    for pose_frame in pose_frames:
        time.sleep(1 / FPS)

        model.set_pose(pose_frame)

        viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))

    if dont_block:
        break
