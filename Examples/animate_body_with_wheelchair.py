import sys
import time

import imumocap
import imumocap.solvers
import imumocap.viewer
import models
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.BodyWithWheelchair()

# Create animation frames
frames = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Head"].set(a * 15)
    model.joints["Neck"].set(a * 15)

    model.joints["Left Wrist"].set(a * -45)
    model.joints["Left Elbow"].set(bend=a * 60, twist=a * -120)
    model.joints["Left Shoulder"].set(bend=a * 10, tilt=a * -30, twist=a * 60)
    model.joints["Left Clavicle"].set(a * -15)

    model.joints["Right Wrist"].set(a * -45)
    model.joints["Right Elbow"].set(a * 60, twist=a * -120)
    model.joints["Right Shoulder"].set(bend=a * 10, tilt=a * -30, twist=a * 60)
    model.joints["Right Clavicle"].set(a * -15)

    model.joints["Upper Torso"].set(a * 15)
    model.joints["Lower Torso"].set(a * 15)
    model.joints["Upper Lumbar"].set(a * 15)
    model.joints["Lower Lumbar"].set(a * 15)

    model.joints["Left Knee"].set(90)
    model.joints["Left Hip"].set(90)

    model.joints["Right Knee"].set(90)
    model.joints["Right Hip"].set(90)

    model.joints["Left Wheel"].set(a * 360)
    model.joints["Right Wheel"].set(a * 360)

    model.joints["Seat"].set(tilt=a * 30)  # root joint connects the model to the world

    imumocap.solvers.translate(model.root, [a * 2 * np.pi * model.left_wheel.length, 0, 0])

    imumocap.solvers.floor(model.root)

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
