import sys
import time

import example_models
import imumocap
import imumocap.viewer
import imumocap.solvers
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = example_models.UpperBody()

# Create animation frames
frames = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Head"].set(a * 15)
    model.joints["Neck"].set(a * 15)

    model.joints["Left Wrist"].set(a * -45)
    model.joints["Left Elbow"].set(alpha=a * 60, gamma=a * -120)
    model.joints["Left Shoulder"].set(alpha=a * 60, beta=a * 30, gamma=a * 10)
    model.joints["Left Clavicle"].set(gamma=a * -15)

    model.joints["Right Wrist"].set(a * -45)
    model.joints["Right Elbow"].set(alpha=a * 60, gamma=a * -120)
    model.joints["Right Shoulder"].set(alpha=a * 60, beta=a * 30, gamma=a * 10)
    model.joints["Right Clavicle"].set(gamma=a * -15)

    model.joints["Upper Torso"].set(a * 15)  # root joint connects the model to the world

    imumocap.solvers.translate(model.root, [0, 0, 0.5])

    frames.append(imumocap.get_pose(model.root))

# Plot
imumocap.plot(model.root, frames, block=not dont_block)

# Stream to IMU Mocap Viewer
viewer_connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        imumocap.set_pose(model.root, frame)

        viewer_connection.send(
            [
                *imumocap.viewer.link_to_primitives(model.root),
                *imumocap.viewer.joints_to_primitives(model.joints, "Left"),
            ]
        )

    if dont_block:
        break
