import sys
import time

import imumocap
import imumocap.solvers
import models
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.Body()

# Create animation frames
frames = []

for y in [np.sin(x) for x in np.linspace(0, np.pi, 100)]:
    model.joints["Head"].set(y * 15)
    model.joints["Neck"].set(y * 15)

    model.joints["Left Wrist"].set(y * -45)
    model.joints["Left Elbow"].set(bend=y * 60, twist=y * -120)
    model.joints["Left Shoulder"].set(bend=y * 10, tilt=y * -30, twist=y * 60)
    model.joints["Left Clavicle"].set(y * -15)

    model.joints["Right Wrist"].set(y * -45)
    model.joints["Right Elbow"].set(bend=y * 60, twist=y * -120)
    model.joints["Right Shoulder"].set(bend=y * 10, tilt=y * -30, twist=y * 60)
    model.joints["Right Clavicle"].set(y * -15)

    model.joints["Upper Torso"].set(y * 15)
    model.joints["Lower Torso"].set(y * 15)
    model.joints["Upper Lumbar"].set(y * 15)
    model.joints["Lower Lumbar"].set(y * 15)

    model.joints["Left Toe"].set(y * -45)
    model.joints["Left Ankle"].set(y * 45)
    model.joints["Left Knee"].set(y * 160)
    model.joints["Left Hip"].set(bend=y * 45, tilt=y * 20, twist=y * -30)

    model.joints["Right Toe"].set(y * -45)
    model.joints["Right Ankle"].set(y * 45)
    model.joints["Right Knee"].set(y * 160)
    model.joints["Right Hip"].set(bend=y * 45, tilt=y * 20, twist=y * -30)

    model.joints["Pelvis"].set(y * -25)  # root joint connects the model to the world

    imumocap.solvers.floor(model.root)

    frames.append({l.name: l.joint for l in model.root.flatten()})  # each frame is a dictionary of joint matrices

# Plot
model.root.plot(frames, block=not dont_block)

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()

while True:
    for frame in frames:
        time.sleep(1 / 30)  # 30 fps

        for name, joint in frame.items():
            model.root.dictionary()[name].joint = joint

        connection.send(imumocap.viewer.link_to_primitives(model.root))

    if dont_block:
        break
