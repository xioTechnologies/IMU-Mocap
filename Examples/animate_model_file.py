import sys
import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = imumocap.file.load_model("animate_model_file.json")

# Create animation frames
frames: list[imumocap.Pose] = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Neck"].set(a * 15)

    model.joints["Left Elbow"].set(alpha=a * 60, gamma=a * -120)
    model.joints["Left Shoulder"].set(alpha=a * 60, beta=a * 30, gamma=a * 10)
    model.joints["Right Elbow"].set(alpha=a * 60, gamma=a * -120)
    model.joints["Right Shoulder"].set(alpha=a * 60, beta=a * 30, gamma=a * 10)

    model.joints["Upper Torso"].set(a * 15)  # root joint connects the model to the world

    imumocap.solvers.translate(model, [0, 0, 0.5])

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
