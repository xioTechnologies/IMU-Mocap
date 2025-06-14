from __future__ import annotations

import time

import imumocap
import models
import numpy as np
from imumocap import Joint, Label, Matrix

model = models.LeftHand()

# Create animation frames
frames = []

joints = {
    # Head
    "Head": Joint(model.head, Matrix(rot_y=90, rot_z=90)),
    "Neck": Joint(model.neck, Matrix(rot_y=90, rot_z=90)),
    # Left arm
    "Left Wrist": Joint(model.left_hand, Matrix(rot_x=90, rot_z=90)),
    "Left Elbow": Joint(model.left_forearm, Matrix(rot_y=180, rot_z=-90)),
    "Left Shoulder": Joint(model.left_upper_arm, Matrix(rot_y=90)),
    "Left Clavicle": Joint(model.left_shoulder, Matrix(rot_y=90)),
    # Right arm
    "Right Wrist": Joint(model.right_hand, Matrix(rot_x=-90, rot_z=90)),
    "Right Elbow": Joint(model.right_forearm, Matrix(rot_z=90)),
    "Right Shoulder": Joint(model.right_upper_arm, Matrix(rot_y=-90)),
    "Right Clavicle": Joint(model.right_shoulder, Matrix(rot_y=-90)),
    # Torso
    "Upper Torso": Joint(model.upper_torso, Matrix(rot_x=-90, rot_y=90)),
    "Lower Torso": Joint(model.lower_torso, Matrix(rot_x=-90, rot_y=90)),
    "Upper Lumbar": Joint(model.upper_lumbar, Matrix(rot_x=-90, rot_y=90)),
    "Lower Lumbar": Joint(model.lower_lumbar, Matrix(rot_x=-90, rot_y=90)),
    # Left leg
    "Left Toe": Joint(model.left_toe, Matrix(rot_x=-90)),
    "Left Ankle": Joint(model.left_foot, Matrix(rot_x=90, rot_y=90)),
    "Left Knee": Joint(model.left_lower_leg, Matrix(rot_x=-90, rot_y=90)),
    "Left Hip": Joint(model.left_upper_leg, Matrix(rot_x=90, rot_y=90)),
    # Right leg
    "Right Toe": Joint(model.right_toe, Matrix(rot_x=90, rot_z=180)),
    "Right Ankle": Joint(model.right_foot, Matrix(rot_x=90, rot_y=-90)),
    "Right Knee": Joint(model.right_lower_leg, Matrix(rot_x=-90, rot_y=-90)),
    "Right Hip": Joint(model.right_upper_leg, Matrix(rot_x=90, rot_y=-90)),
    # Pelvis
    "Pelvis": Joint(model.pelvis, Matrix(rot_y=90, rot_z=90)),
    # Wheelchair
    "Left Wheel": Joint(model.left_wheel, Matrix(rot_x=-90, rot_y=90)),
    "Right Wheel": Joint(model.right_wheel, Matrix(rot_x=-90, rot_y=-90)),
    "Seat": Joint(model.seat, Matrix(rot_y=90, rot_z=90)),
    # Left hand
    "Left Second Distal": Joint(model.left_second_distal, Matrix(rot_x=-90, rot_z=90)),
    "Left Second Middle": Joint(model.left_second_middle, Matrix(rot_x=-90, rot_z=90)),
    "Left Second Proximal": Joint(model.left_second_proximal, Matrix(rot_x=-90, rot_z=90)),
    "Left Second Metacarpal": Joint(model.left_second_metacarpal, Matrix(rot_x=-90, rot_z=90)),
    "Left Carpus": Joint(model.left_carpus, Matrix(rot_x=90, rot_z=90)),
    # Right hand
    "Right Carpus": Joint(model.right_carpus, Matrix(rot_x=-90, rot_z=90)),
}

connection = imumocap.viewer.Connection()

while True:
    for angle_name in ["bend", "tilt", "twist"]:
        for angle in [60 * np.sin(x) for x in np.linspace(0, np.pi, 50)]:
            time.sleep(1 / 30)  # 30 fps

            joint_name = "Second Distal"  # replace this with joint to inspect

            for joint_name in [f"Left {joint_name}", f"Right {joint_name}", joint_name]:
                if joint_name not in joints:
                    continue

                joint = joints[joint_name]

                match angle_name:
                    case "bend":
                        joint.set(bend=angle)
                    case "tilt":
                        joint.set(tilt=angle)
                    case "twist":
                        joint.set(twist=angle)

            connection.send(
                [
                    *imumocap.viewer.link_to_primitives(model.root),
                    Label(joint.link.get_joint_global().xyz, f"{joint_name} {angle_name}={angle:.1f}"),
                ]
            )

# An interface to get and set Link joint matrix rotations as the three angles:
# bend, tilt, and twist. Bend and twist angles may be between +/-180 degrees,
# tilt angles must not exceed or approach +/-90 degrees.
#
# The bend, tilt, and twist axes are intended to be alignment to rotations most
# intuitive for parlance of this terms. For example, a knee is said to bend,
# and the neck is said to twist or tilt the head. The tilt angle must only be
# assigned to a rotation with a range less than +/-90 degrees. The conventions
# for positive and negative rotations are summarised below.
#
# Flexion vs. extension:
#     Flexion (bending) is positive
#     Extension (straightening) is negative
#
# Abduction vs. adduction:
#     Abduction (moving away from the body's midline) is positive
#     Adduction (moving toward the midline) is negative
#
# Pronation vs. supination:
#     Pronation (palms or soles facing down) is positive
#     Supination (palms or soles facing up) is negative

array = [
    ("Matrix(rot_y=90, rot_z=90))", Matrix(rot_y=90, rot_z=90)),
    ("Matrix(rot_y=90, rot_z=90))", Matrix(rot_y=90, rot_z=90)),
    ("Matrix(rot_x=90, rot_z=90))", Matrix(rot_x=90, rot_z=90)),
    ("Matrix(rot_y=180, rot_z=-90))", Matrix(rot_y=180, rot_z=-90)),
    ("Matrix(rot_y=90))", Matrix(rot_y=90)),
    ("Matrix(rot_y=90))", Matrix(rot_y=90)),
    ("Matrix(rot_x=-90, rot_z=90))", Matrix(rot_x=-90, rot_z=90)),
    ("Matrix(rot_z=90))", Matrix(rot_z=90)),
    ("Matrix(rot_y=-90))", Matrix(rot_y=-90)),
    ("Matrix(rot_y=-90))", Matrix(rot_y=-90)),
    ("Matrix(rot_x=-90, rot_y=90))", Matrix(rot_x=-90, rot_y=90)),
    ("Matrix(rot_x=-90, rot_y=90))", Matrix(rot_x=-90, rot_y=90)),
    ("Matrix(rot_x=-90, rot_y=90))", Matrix(rot_x=-90, rot_y=90)),
    ("Matrix(rot_x=-90, rot_y=90))", Matrix(rot_x=-90, rot_y=90)),
    ("Matrix(rot_x=-90))", Matrix(rot_x=-90)),
    ("Matrix(rot_x=90, rot_y=90))", Matrix(rot_x=90, rot_y=90)),
    ("Matrix(rot_x=-90, rot_y=90))", Matrix(rot_x=-90, rot_y=90)),
    ("Matrix(rot_x=90, rot_y=90))", Matrix(rot_x=90, rot_y=90)),
    ("Matrix(rot_x=90, rot_z=180))", Matrix(rot_x=90, rot_z=180)),
    ("Matrix(rot_x=90, rot_y=-90))", Matrix(rot_x=90, rot_y=-90)),
    ("Matrix(rot_x=-90, rot_y=-90))", Matrix(rot_x=-90, rot_y=-90)),
    ("Matrix(rot_x=90, rot_y=-90))", Matrix(rot_x=90, rot_y=-90)),
    ("Matrix(rot_y=90, rot_z=90))", Matrix(rot_y=90, rot_z=90)),
]


for a in array:
    for b in array:
        if np.isclose(np.linalg.norm(a[1].quaternion - b[1].quaternion), 0):
            if a[0] != b[0]:
                print(a)
                print(b)
                print()
