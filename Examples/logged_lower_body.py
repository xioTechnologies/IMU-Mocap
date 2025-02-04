import sys
import time

import imumocap.solvers
import models
import numpy as np
import scipy
import ximu3csv
from imumocap import Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Import IMU data
devices = ximu3csv.read("Logged Lower Body", [ximu3csv.DataMessageType.QUATERNION])

# Resample IMU data and arrange as dictionary of device names
first_timestamp = np.max([d.quaternion.timestamp[0] for d in devices]) / 1e6  # convert microseconds to seconds
last_timestamp = np.min([d.quaternion.timestamp[-1] for d in devices]) / 1e6

FPS = 30
timestamps = np.arange(first_timestamp, last_timestamp, 1 / FPS)

imus = {d.device_name: scipy.interpolate.interp1d(d.quaternion.timestamp / 1e6, d.quaternion.quaternion.wxyz, axis=0)(timestamps) for d in devices}

# Load example model
model = models.LowerBody()

# Calibrate IMU alignment (logged data must start in calibration pose)
imumocap.solvers.calibrate(model.root, {n: Matrix(quaternion=q[0, :]) for n, q in imus.items()})

# Create animation frames
frames = []

for index, _ in enumerate(timestamps):
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
