import sys
import time

import imumocap
import imumocap.solvers
import imumocap.viewer
import models
import numpy as np

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.BodyWithWheelchairAndHands()

# Create animation frames
frames = []

for a in [np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    model.joints["Head"].set(a * 15)
    model.joints["Neck"].set(a * 15)

    model.joints["Left Carpus"].set(a * -45)
    model.joints["Left Elbow"].set(bend=a * 60, twist=a * -120)
    model.joints["Left Shoulder"].set(bend=a * 10, tilt=a * -30, twist=a * 60)
    model.joints["Left Clavicle"].set(a * -15)

    model.joints["Right Carpus"].set(a * -45)
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

    model.joints["Seat"].set(tilt=a * 30)  # root joint connects the model to the world

    model.joints["Left I Distal"].set(-45 * a)
    model.joints["Left I Proximal"].set(-45 * a)
    model.joints["Left I Metacarpal"].set(-45 * a)

    model.joints["Left II Distal"].set(-90 * a)
    model.joints["Left II Middle"].set(-90 * a)
    model.joints["Left II Proximal"].set(-90 * a)

    model.joints["Left III Distal"].set(-90 * a)
    model.joints["Left III Middle"].set(-90 * a)
    model.joints["Left III Proximal"].set(-90 * a)

    model.joints["Left IV Distal"].set(-90 * a)
    model.joints["Left IV Middle"].set(-90 * a)
    model.joints["Left IV Proximal"].set(-90 * a)

    model.joints["Left V Distal"].set(-90 * a)
    model.joints["Left V Middle"].set(-90 * a)
    model.joints["Left V Proximal"].set(-90 * a)

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
