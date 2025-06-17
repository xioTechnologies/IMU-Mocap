import sys
import time

import imumocap
import imumocap.solvers
import models
import numpy as np
from imumocap import Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.BodyWithHands()

# Create animation frames
frames = []

for y in [np.sin(x) for x in np.linspace(0, np.pi, 100)]:
    model.head.joint = Matrix(rot_y=y * 15)
    model.neck.joint = Matrix(rot_y=y * 15)

    model.left_forearm.joint = Matrix(rot_y=y * -90, rot_z=y * -60)
    model.left_upper_arm.joint = Matrix(rot_x=y * 10, rot_z=y * -60)
    model.left_shoulder.joint = Matrix(rot_x=y * -10)

    model.right_forearm.joint = Matrix(rot_y=y * -90, rot_z=y * 60)
    model.right_upper_arm.joint = Matrix(rot_x=y * -10, rot_z=y * 60)
    model.right_shoulder.joint = Matrix(rot_x=y * -10)

    model.upper_torso.joint = Matrix(rot_y=y * 15)
    model.lower_torso.joint = Matrix(rot_y=y * 15)
    model.upper_lumbar.joint = Matrix(rot_y=y * 15)
    model.lower_lumbar.joint = Matrix(rot_y=y * 15)

    model.left_toe.joint = Matrix(rot_y=y * -45)
    model.left_foot.joint = Matrix(rot_y=y * -45)
    model.left_lower_leg.joint = Matrix(rot_y=y * 160)
    model.left_upper_leg.joint = Matrix(rot_y=y * -45)

    model.right_toe.joint = Matrix(rot_y=y * -45)
    model.right_foot.joint = Matrix(rot_y=y * -45)
    model.right_lower_leg.joint = Matrix(rot_y=y * 160)
    model.right_upper_leg.joint = Matrix(rot_y=y * -45)

    model.pelvis.joint = Matrix(rot_y=y * -25)  # root joint connects the model to the world

    model.left_i_distal.joint = Matrix(rot_x=-45 * y)
    model.left_i_proximal.joint = Matrix(rot_x=-45 * y)
    model.left_i_metacarpal.joint = Matrix(rot_x=-45 * y)

    model.left_ii_distal.joint = Matrix(rot_x=-90 * y)
    model.left_ii_middle.joint = Matrix(rot_x=-90 * y)
    model.left_ii_proximal.joint = Matrix(rot_x=-90 * y)

    model.left_iii_distal.joint = Matrix(rot_x=-90 * y)
    model.left_iii_middle.joint = Matrix(rot_x=-90 * y)
    model.left_iii_proximal.joint = Matrix(rot_x=-90 * y)

    model.left_iv_distal.joint = Matrix(rot_x=-90 * y)
    model.left_iv_middle.joint = Matrix(rot_x=-90 * y)
    model.left_iv_proximal.joint = Matrix(rot_x=-90 * y)

    model.left_v_distal.joint = Matrix(rot_x=-90 * y)
    model.left_v_middle.joint = Matrix(rot_x=-90 * y)
    model.left_v_proximal.joint = Matrix(rot_x=-90 * y)

    model.right_i_distal.joint = Matrix(rot_x=45 * y)
    model.right_i_proximal.joint = Matrix(rot_x=45 * y)
    model.right_i_metacarpal.joint = Matrix(rot_x=45 * y)

    model.right_ii_distal.joint = Matrix(rot_x=90 * y)
    model.right_ii_middle.joint = Matrix(rot_x=90 * y)
    model.right_ii_proximal.joint = Matrix(rot_x=90 * y)

    model.right_iii_distal.joint = Matrix(rot_x=90 * y)
    model.right_iii_middle.joint = Matrix(rot_x=90 * y)
    model.right_iii_proximal.joint = Matrix(rot_x=90 * y)

    model.right_iv_distal.joint = Matrix(rot_x=90 * y)
    model.right_iv_middle.joint = Matrix(rot_x=90 * y)
    model.right_iv_proximal.joint = Matrix(rot_x=90 * y)

    model.right_v_distal.joint = Matrix(rot_x=90 * y)
    model.right_v_middle.joint = Matrix(rot_x=90 * y)
    model.right_v_proximal.joint = Matrix(rot_x=90 * y)

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
