import sys
import time

import imumocap
import imumocap.solvers
import imumocap.viewer
import models
import ximu3csv
from imumocap import Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Import IMU data
devices = ximu3csv.read("Logged Lower Body", ximu3csv.DataMessageType.QUATERNION)

# Resample IMU data and arrange as dictionary of device names
FPS = 30

devices = ximu3csv.resample(devices, FPS)

number_of_samples = len(devices[0].quaternion.timestamp)

imus = {d.device_name: d.quaternion.quaternion.wxyz for d in devices}

# Load example model
model = models.LowerBody()

# Calibrate IMU alignment (logged data must start in calibration pose)
imumocap.solvers.calibrate(model.root, {n: Matrix(quaternion=q[0, :]) for n, q in imus.items()})

# Create animation frames
frames = []

for index in range(number_of_samples):
    imumocap.set_pose_from_imus(model.root, {n: Matrix(quaternion=q[index, :]) for n, q in imus.items()})

    imumocap.solvers.floor(model.root)

    frames.append(imumocap.get_pose(model.root))

# Plot
imumocap.plot(model.root, frames, block=not dont_block)

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / FPS)

        imumocap.set_pose(model.root, frame)

        connection.send(
            [
                *imumocap.viewer.link_to_primitives(model.root),
                *imumocap.viewer.joints_to_primitives(model.joints, ["Left"]),
            ]
        )

    if dont_block:
        break
