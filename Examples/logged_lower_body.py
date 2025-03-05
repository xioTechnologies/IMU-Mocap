import sys
import time

import imumocap.solvers
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
    for link in model.root.flatten():
        if link.name in imus:
            link.set_joint_from_imu_global(Matrix(quaternion=imus[link.name][index, :]))

    imumocap.solvers.floor(model.root)

    frames.append({l.name: l.joint for l in model.root.flatten()})  # each frame is a dictionary of joint matrices

# Plot
model.root.plot(frames, block=not dont_block)

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / FPS)

        for name, joint in frame.items():
            model.root.dictionary()[name].joint = joint

        connection.send(imumocap.viewer.link_to_primitives(model.root))

    if dont_block:
        break
