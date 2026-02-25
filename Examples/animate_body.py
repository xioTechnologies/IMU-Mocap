import sys
import time

import imumocap
import imumocap.solvers
import imumocap.viewer
import numpy as np

import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = models.Factory().body()

# Create animation frames
frames: list[imumocap.Pose] = []

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

    model.joints["Upper Torso"].set(a * 15)
    model.joints["Lower Torso"].set(a * 15)
    model.joints["Upper Lumbar"].set(a * 15)
    model.joints["Lower Lumbar"].set(a * 15)

    model.joints["Left Toe"].set(a * -45)
    model.joints["Left Ankle"].set(a * 45)
    model.joints["Left Knee"].set(a * 160)
    model.joints["Left Hip"].set(alpha=a * 45, beta=a * 20, gamma=a * -30)

    model.joints["Right Toe"].set(a * -45)
    model.joints["Right Ankle"].set(a * 45)
    model.joints["Right Knee"].set(a * 160)
    model.joints["Right Hip"].set(alpha=a * 45, beta=a * 20, gamma=a * -30)

    model.joints["Pelvis"].set(gamma=a * -25)  # root joint connects the model to the world

    imumocap.solvers.floor(model)

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
