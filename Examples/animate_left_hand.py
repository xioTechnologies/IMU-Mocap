import sys
import time

import imumocap
import models
import numpy as np
from imumocap import Joint, Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.LeftHand()

# Create animation frames
frames = []

alignment = Matrix(rot_y=30, rot_z=-40)

j = Joint(model.left_first_proximal, alignment)

for a in [np.sin(x) for x in np.linspace(0, np.pi, 100)]:
    j.set(twist=a * -45)

    # model.left_first_distal.joint = model.left_first_transformation(Matrix(rot_x=-45 * a))
    # model.left_first_proximal.joint = model.left_first_transformation(Matrix(rot_x=-45 * a))
    # model.left_first_metacarpal.joint = model.left_first_transformation(Matrix(rot_x=-45 * a))

    # model.left_second_distal.joint = Matrix(rot_x=-90 * a)
    # model.left_second_middle.joint = Matrix(rot_x=-90 * a)
    # model.left_second_proximal.joint = Matrix(rot_x=-90 * a)

    # model.left_third_distal.joint = Matrix(rot_x=-90 * a)
    # model.left_third_middle.joint = Matrix(rot_x=-90 * a)
    # model.left_third_proximal.joint = Matrix(rot_x=-90 * a)

    # model.left_forth_distal.joint = Matrix(rot_x=-90 * a)
    # model.left_forth_middle.joint = Matrix(rot_x=-90 * a)
    # model.left_forth_proximal.joint = Matrix(rot_x=-90 * a)

    # model.left_fifth_distal.joint = Matrix(rot_x=-90 * a)
    # model.left_fifth_middle.joint = Matrix(rot_x=-90 * a)
    # model.left_fifth_proximal.joint = Matrix(rot_x=-90 * a)

    frames.append({l.name: l.joint for l in model.root.flatten()})  # each frame is a dictionary of joint matrices

# Plot
model.root.plot(frames, block=not dont_block, elev=90)

# # Stream to IMU Mocap Viewer
# connection = imumocap.viewer.Connection()

# while True:
#     for frame in frames:
#         time.sleep(1 / 30)  # 30 fps

#         for name, joint in frame.items():
#             model.root.dictionary()[name].joint = joint

#         connection.send(imumocap.viewer.link_to_primitives(model.root))

#     if dont_block:
#         break
