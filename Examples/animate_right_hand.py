import sys
import time

import imumocap
import imumocap.viewer
import models
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.RightHand()

# Create animation frames
frames = []

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

    frames.append(imumocap.get_pose(model.root))

# Plot
imumocap.plot(model.root, frames, block=not dont_block)

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        imumocap.set_pose(model.root, frame)

        connection.send(
            [
                *imumocap.viewer.link_to_primitives(model.root),
                *imumocap.viewer.joints_to_primitives(model.joints, "Left"),
            ]
        )

    if dont_block:
        break
