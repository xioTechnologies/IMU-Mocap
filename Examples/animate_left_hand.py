import sys
import time

import example_models
import imumocap
import imumocap.viewer
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = example_models.LeftHand()

# Create animation frames
frames: list[dict[str, imumocap.Matrix]] = []

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
imumocap.plot(model.root, frames, block=not dont_block)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        imumocap.set_pose(model.root, frame)

        viewer.send_frame(
            [
                *imumocap.viewer.link_to_primitives(model.root),
                *imumocap.viewer.joints_to_primitives(model.joints, mirror="Left"),
            ]
        )

    if dont_block:
        break
