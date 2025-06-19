import sys
import time

import imumocap
import models
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.LeftHand()

# Create animation frames
frames = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Left I Distal"].set(45 * a)
    model.joints["Left I Proximal"].set(45 * a)
    model.joints["Left I Metacarpal"].set(45 * a)

    model.joints["Left II Distal"].set(90 * a)
    model.joints["Left II Middle"].set(90 * a)
    model.joints["Left II Proximal"].set(90 * a)

    model.joints["Left III Distal"].set(90 * a)
    model.joints["Left III Middle"].set(90 * a)
    model.joints["Left III Proximal"].set(90 * a)

    model.joints["Left IV Distal"].set(90 * a)
    model.joints["Left IV Middle"].set(90 * a)
    model.joints["Left IV Proximal"].set(90 * a)

    model.joints["Left V Distal"].set(90 * a)
    model.joints["Left V Middle"].set(90 * a)
    model.joints["Left V Proximal"].set(90 * a)

    frames.append(imumocap.get_pose(model.root))

# Plot
model.root.plot(frames, block=not dont_block)

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        imumocap.set_pose(model.root, frame)

        connection.send(imumocap.viewer.link_to_primitives(model.root))

    if dont_block:
        break
