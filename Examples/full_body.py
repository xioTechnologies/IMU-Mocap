import imumocap
import matplotlib.pyplot as pyplot
import numpy

# Crate kinematic model
HEAD_LENGTH = 2
SHOULDER_WIDTH = 2
UPPER_ARM_LENGTH = 3
LOWER_ARM_LENGTH = 3
HAND_LENGTH = 1
SPINE_LENGTH = 4
PELVIS_LENGTH = 1
PELVIS_WIDTH = 2
UPPER_LEG_LENGTH = 4
LOWER_LEG_LENGTH = 4
FOOT_LENGTH = 1

head = imumocap.Link("head", HEAD_LENGTH)

left_hand = imumocap.Link("left_hand",  HAND_LENGTH)
left_lower_arm = imumocap.Link("left_lower_arm", LOWER_ARM_LENGTH, [(left_hand, imumocap.Link.matrix(x=LOWER_ARM_LENGTH))])
left_upper_arm = imumocap.Link("left_upper_arm", UPPER_ARM_LENGTH, [(left_lower_arm, imumocap.Link.matrix(x=UPPER_ARM_LENGTH))])

right_hand = imumocap.Link("right_hand", HAND_LENGTH)
right_lower_arm = imumocap.Link("right_lower_arm", LOWER_ARM_LENGTH, [(right_hand, imumocap.Link.matrix(x=LOWER_ARM_LENGTH))])
right_upper_arm = imumocap.Link("right_upper_arm", UPPER_ARM_LENGTH, [(right_lower_arm, imumocap.Link.matrix(x=UPPER_ARM_LENGTH))])

spine = imumocap.Link("spine", SPINE_LENGTH, [(head, imumocap.Link.matrix(x=SPINE_LENGTH)),
                                              (left_upper_arm, imumocap.Link.matrix(x=0.9 * SPINE_LENGTH, y=SHOULDER_WIDTH / 2, roll=90, yaw=90)),
                                              (right_upper_arm, imumocap.Link.matrix(x=0.9 * SPINE_LENGTH, y=-SHOULDER_WIDTH / 2, roll=-90, yaw=-90))])

left_foot = imumocap.Link("left_foot", FOOT_LENGTH)
left_lower_leg = imumocap.Link("left_lower_leg", LOWER_LEG_LENGTH, [(left_foot, imumocap.Link.matrix(pitch=-90, x=LOWER_LEG_LENGTH))])
left_upper_leg = imumocap.Link("left_upper_leg", UPPER_LEG_LENGTH, [(left_lower_leg, imumocap.Link.matrix(x=UPPER_LEG_LENGTH))])

right_foot = imumocap.Link("right_foot", FOOT_LENGTH)
right_lower_leg = imumocap.Link("right_lower_leg", LOWER_LEG_LENGTH, [(right_foot, imumocap.Link.matrix(pitch=-90, x=LOWER_LEG_LENGTH))])
right_upper_leg = imumocap.Link("right_upper_leg", UPPER_LEG_LENGTH, [(right_lower_leg, imumocap.Link.matrix(x=UPPER_LEG_LENGTH))])

pelvis = imumocap.Link("pelvis", PELVIS_LENGTH, [(spine, imumocap.Link.matrix(x=PELVIS_LENGTH)),
                                                 (left_upper_leg, imumocap.Link.matrix(y=PELVIS_WIDTH / 2, roll=180, yaw=180)),
                                                 (right_upper_leg, imumocap.Link.matrix(y=-PELVIS_WIDTH / 2, roll=180, yaw=180))])

# Set root joint relative to global frame
pelvis.joint = imumocap.Link.matrix(pitch=-90)

imumocap.plot(pelvis, azim=-45)
pyplot.show()

# Create animation
frames = []

for angle in [10 * (1 + numpy.sin(x)) for x in numpy.linspace(0, 2 * numpy.pi, 200)]:
    head.joint = imumocap.Link.matrix(pitch=angle)
    left_hand.joint = imumocap.Link.matrix(yaw=-2 * angle)
    left_lower_arm .joint = imumocap.Link.matrix(yaw=-6 * angle)
    left_upper_arm.joint = imumocap.Link.matrix(roll=-2 * angle, yaw=-2 * angle)
    right_hand.joint = imumocap.Link.matrix(yaw=2 * angle)
    right_lower_arm.joint = imumocap.Link.matrix(yaw=6 * angle)
    right_upper_arm.joint = imumocap.Link.matrix(roll=2 * angle, yaw=2 * angle)
    spine.joint = imumocap.Link.matrix(pitch=angle)
    left_foot.joint = imumocap.Link.matrix(pitch=-3 * angle)
    left_lower_leg.joint = imumocap.Link.matrix(pitch=8 * angle)
    left_upper_leg.joint = imumocap.Link.matrix(pitch=-6 * angle)
    right_foot.joint = imumocap.Link.matrix(pitch=-3 * angle)
    right_lower_leg.joint = imumocap.Link.matrix(pitch=8 * angle)
    right_upper_leg.joint = imumocap.Link.matrix(pitch=-6 * angle)
    pelvis.joint = imumocap.Link.matrix(pitch=angle - 90)

    frames.append([l.joint.copy() for l in imumocap.Link.flatten(pelvis)])

imumocap.plot(pelvis, frames, fps=30, file_name="full_body.gif", figsize=(16, 9), dpi=120)
