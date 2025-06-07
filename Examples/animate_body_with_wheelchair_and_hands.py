import sys
import time

import imumocap
import imumocap.solvers
import models
import numpy as np
from imumocap import Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.BodyWithWheelchairAndHands()

# Create animation frames
frames = []

for y in [np.sin(x) for x in np.linspace(0, np.pi, 100)]:
    model.joints["Head"].set(y * 15)
    model.joints["Neck"].set(y * 15)

    model.joints["Left Carpus"].set(y * -45)
    model.joints["Left Elbow"].set(bend=y * 60, twist=y * -120)
    model.joints["Left Shoulder"].set(bend=y * 10, tilt=y * -30, twist=y * 60)
    model.joints["Left Clavicle"].set(y * -15)

    model.joints["Right Carpus"].set(y * -45)
    model.joints["Right Elbow"].set(y * 60, twist=y * -120)
    model.joints["Right Shoulder"].set(bend=y * 10, tilt=y * -30, twist=y * 60)
    model.joints["Right Clavicle"].set(y * -15)

    model.joints["Upper Torso"].set(y * 15)
    model.joints["Lower Torso"].set(y * 15)
    model.joints["Upper Lumbar"].set(y * 15)
    model.joints["Lower Lumbar"].set(y * 15)

    model.joints["Left Knee"].set(90)
    model.joints["Left Hip"].set(90)

    model.joints["Right Knee"].set(90)
    model.joints["Right Hip"].set(90)

    model.left_wheel.joint = Matrix(rot_y=y * 360)
    model.right_wheel.joint = Matrix(rot_y=y * 360)
    model.seat.joint = Matrix(x=y * 2 * np.pi * model.left_wheel.length, rot_x=y * 30)  # root joint connects the model to the world

    model.left_first_distal.joint = model.left_first_transformation(Matrix(rot_x=-45 * y))
    model.left_first_proximal.joint = model.left_first_transformation(Matrix(rot_x=-45 * y))
    model.left_first_metacarpal.joint = model.left_first_transformation(Matrix(rot_x=-45 * y))

    model.left_second_distal.joint = Matrix(rot_x=-90 * y)
    model.left_second_middle.joint = Matrix(rot_x=-90 * y)
    model.left_second_proximal.joint = Matrix(rot_x=-90 * y)

    model.left_third_distal.joint = Matrix(rot_x=-90 * y)
    model.left_third_middle.joint = Matrix(rot_x=-90 * y)
    model.left_third_proximal.joint = Matrix(rot_x=-90 * y)

    model.left_forth_distal.joint = Matrix(rot_x=-90 * y)
    model.left_forth_middle.joint = Matrix(rot_x=-90 * y)
    model.left_forth_proximal.joint = Matrix(rot_x=-90 * y)

    model.left_fifth_distal.joint = Matrix(rot_x=-90 * y)
    model.left_fifth_middle.joint = Matrix(rot_x=-90 * y)
    model.left_fifth_proximal.joint = Matrix(rot_x=-90 * y)

    model.right_first_distal.joint = model.right_first_transformation(Matrix(rot_x=45 * y))
    model.right_first_proximal.joint = model.right_first_transformation(Matrix(rot_x=45 * y))
    model.right_first_metacarpal.joint = model.right_first_transformation(Matrix(rot_x=45 * y))

    model.right_second_distal.joint = Matrix(rot_x=90 * y)
    model.right_second_middle.joint = Matrix(rot_x=90 * y)
    model.right_second_proximal.joint = Matrix(rot_x=90 * y)

    model.right_third_distal.joint = Matrix(rot_x=90 * y)
    model.right_third_middle.joint = Matrix(rot_x=90 * y)
    model.right_third_proximal.joint = Matrix(rot_x=90 * y)

    model.right_forth_distal.joint = Matrix(rot_x=90 * y)
    model.right_forth_middle.joint = Matrix(rot_x=90 * y)
    model.right_forth_proximal.joint = Matrix(rot_x=90 * y)

    model.right_fifth_distal.joint = Matrix(rot_x=90 * y)
    model.right_fifth_middle.joint = Matrix(rot_x=90 * y)
    model.right_fifth_proximal.joint = Matrix(rot_x=90 * y)

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
