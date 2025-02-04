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

for angle in [np.sin(x) for x in np.linspace(0, np.pi, 100)]:
    model.head.joint = Matrix(rot_y=angle * 15)
    model.neck.joint = Matrix(rot_y=angle * 15)

    model.left_forearm.joint = Matrix(rot_y=angle * -90, rot_z=angle * -60)
    model.left_upper_arm.joint = Matrix(rot_x=angle * 10, rot_z=angle * -60)
    model.left_shoulder.joint = Matrix(rot_x=angle * -10)

    model.right_forearm.joint = Matrix(rot_y=angle * -90, rot_z=angle * 60)
    model.right_upper_arm.joint = Matrix(rot_x=angle * -10, rot_z=angle * 60)
    model.right_shoulder.joint = Matrix(rot_x=angle * -10)

    model.upper_torso.joint = Matrix(rot_y=angle * 15)
    model.lower_torso.joint = Matrix(rot_y=angle * 15)
    model.upper_lumbar.joint = Matrix(rot_y=angle * 15)
    model.lower_lumbar.joint = Matrix(rot_y=angle * 15)

    model.left_foot.joint = Matrix(rot_y=angle * 60)
    model.left_lower_leg.joint = Matrix(rot_y=(angle * 45) + 90)
    model.left_upper_leg.joint = Matrix(rot_y=(angle * -15) - 90)

    model.right_foot.joint = Matrix(rot_y=angle * 60)
    model.right_lower_leg.joint = Matrix(rot_y=(angle * 45) + 90)
    model.right_upper_leg.joint = Matrix(rot_y=(angle * -15) - 90)

    model.pelvis.joint = Matrix(rot_y=angle * -25)

    model.left_wheel.joint = Matrix(rot_y=angle * 360)
    model.right_wheel.joint = Matrix(rot_y=angle * 360)
    model.seat.joint = Matrix(x=angle * 2 * np.pi * model.left_wheel.length, rot_x=angle * 30)

    model.left_first_distal.joint = model.left_first_transformation(Matrix(rot_x=-45 * angle))
    model.left_first_proximal.joint = model.left_first_transformation(Matrix(rot_x=-45 * angle))
    model.left_first_metacarpal.joint = model.left_first_transformation(Matrix(rot_x=-45 * angle))

    model.left_second_distal.joint = Matrix(rot_x=-90 * angle)
    model.left_second_middle.joint = Matrix(rot_x=-90 * angle)
    model.left_second_proximal.joint = Matrix(rot_x=-90 * angle)

    model.left_third_distal.joint = Matrix(rot_x=-90 * angle)
    model.left_third_middle.joint = Matrix(rot_x=-90 * angle)
    model.left_third_proximal.joint = Matrix(rot_x=-90 * angle)

    model.left_forth_distal.joint = Matrix(rot_x=-90 * angle)
    model.left_forth_middle.joint = Matrix(rot_x=-90 * angle)
    model.left_forth_proximal.joint = Matrix(rot_x=-90 * angle)

    model.left_fifth_distal.joint = Matrix(rot_x=-90 * angle)
    model.left_fifth_middle.joint = Matrix(rot_x=-90 * angle)
    model.left_fifth_proximal.joint = Matrix(rot_x=-90 * angle)

    model.right_first_distal.joint = model.right_first_transformation(Matrix(rot_x=45 * angle))
    model.right_first_proximal.joint = model.right_first_transformation(Matrix(rot_x=45 * angle))
    model.right_first_metacarpal.joint = model.right_first_transformation(Matrix(rot_x=45 * angle))

    model.right_second_distal.joint = Matrix(rot_x=90 * angle)
    model.right_second_middle.joint = Matrix(rot_x=90 * angle)
    model.right_second_proximal.joint = Matrix(rot_x=90 * angle)

    model.right_third_distal.joint = Matrix(rot_x=90 * angle)
    model.right_third_middle.joint = Matrix(rot_x=90 * angle)
    model.right_third_proximal.joint = Matrix(rot_x=90 * angle)

    model.right_forth_distal.joint = Matrix(rot_x=90 * angle)
    model.right_forth_middle.joint = Matrix(rot_x=90 * angle)
    model.right_forth_proximal.joint = Matrix(rot_x=90 * angle)

    model.right_fifth_distal.joint = Matrix(rot_x=90 * angle)
    model.right_fifth_middle.joint = Matrix(rot_x=90 * angle)
    model.right_fifth_proximal.joint = Matrix(rot_x=90 * angle)

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
