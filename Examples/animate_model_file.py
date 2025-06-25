import sys
import time

import imumocap
import imumocap.file
import imumocap.viewer
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
root, joints = imumocap.file.load_model("model.json")

# Create animation frames
frames = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    joints["Neck"].set(a * 15)

    joints["Left Elbow"].set(bend=a * 60, twist=a * -120)
    joints["Left Shoulder"].set(bend=a * 10, tilt=a * -30, twist=a * 60)
    joints["Right Elbow"].set(bend=a * 60, twist=a * -120)
    joints["Right Shoulder"].set(bend=a * 10, tilt=a * -30, twist=a * 60)

    joints["Upper Torso"].set(a * 15)  # root joint connects the model to the world

    frames.append(imumocap.get_pose(root))

# Plot
imumocap.plot(root, frames, block=not dont_block)

# Stream to IMU Mocap Viewer
viewer_connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        imumocap.set_pose(root, frame)

        viewer_connection.send(
            [
                *imumocap.viewer.link_to_primitives(root),
                *imumocap.viewer.joints_to_primitives(joints, "Left"),
            ]
        )

    if dont_block:
        break
