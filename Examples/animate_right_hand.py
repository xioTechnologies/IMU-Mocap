import sys
import time

import imumocap
import imumocap.viewer
import numpy as np

import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = models.Factory().right_hand()

# Create animation frames
frames: list[imumocap.Pose] = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Right I Distal"].set(45 * a)
    model.joints["Right I Proximal"].set(45 * a)
    model.joints["Right I Metacarpal"].set(45 * a)

    model.joints["Right II Distal"].set(90 * a)
    model.joints["Right II Middle"].set(90 * a)
    model.joints["Right II Proximal"].set(90 * a)

    model.joints["Right III Distal"].set(90 * a)
    model.joints["Right III Middle"].set(90 * a)
    model.joints["Right III Proximal"].set(90 * a)

    model.joints["Right IV Distal"].set(90 * a)
    model.joints["Right IV Middle"].set(90 * a)
    model.joints["Right IV Proximal"].set(90 * a)

    model.joints["Right V Distal"].set(90 * a)
    model.joints["Right V Middle"].set(90 * a)
    model.joints["Right V Proximal"].set(90 * a)

    frames.append(model.get_pose())

# Plot
imumocap.plot(model, frames, block=not dont_block)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        model.set_pose(frame)

        viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))

    if dont_block:
        break
