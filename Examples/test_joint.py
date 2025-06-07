from __future__ import annotations

import time

import imumocap
import models
import numpy as np
from imumocap import Joint, Label, Matrix

model = models.BodyWithHands()

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
    "Left I Distal": Joint(model.left_i_distal, Matrix(rot_x=-90, rot_z=90)),
    "Left I Proximal": Joint(model.left_i_proximal, Matrix(rot_x=-90, rot_z=90)),
    "Left I Metacarpal": Joint(model.left_i_metacarpal, Matrix(rot_x=-90, rot_z=90)),
    "Left II Distal": Joint(model.left_ii_distal, Matrix(rot_x=-90, rot_z=90)),
    "Left II Middle": Joint(model.left_ii_middle, Matrix(rot_x=-90, rot_z=90)),
    "Left II Proximal": Joint(model.left_ii_proximal, Matrix(rot_x=-90, rot_z=90)),
    "Left II Metacarpal": Joint(model.left_ii_metacarpal, Matrix(rot_x=-90, rot_z=90)),
    "Left III Distal": Joint(model.left_iii_distal, Matrix(rot_x=-90, rot_z=90)),
    "Left III Middle": Joint(model.left_iii_middle, Matrix(rot_x=-90, rot_z=90)),
    "Left III Proximal": Joint(model.left_iii_proximal, Matrix(rot_x=-90, rot_z=90)),
    "Left III Metacarpal": Joint(model.left_iii_metacarpal, Matrix(rot_x=-90, rot_z=90)),
    "Left IV Distal": Joint(model.left_iv_distal, Matrix(rot_x=-90, rot_z=90)),
    "Left IV Middle": Joint(model.left_iv_middle, Matrix(rot_x=-90, rot_z=90)),
    "Left IV Proximal": Joint(model.left_iv_proximal, Matrix(rot_x=-90, rot_z=90)),
    "Left IV Metacarpal": Joint(model.left_iv_metacarpal, Matrix(rot_x=-90, rot_z=90)),
    "Left V Distal": Joint(model.left_v_distal, Matrix(rot_x=-90, rot_z=90)),
    "Left V Middle": Joint(model.left_v_middle, Matrix(rot_x=-90, rot_z=90)),
    "Left V Proximal": Joint(model.left_v_proximal, Matrix(rot_x=-90, rot_z=90)),
    "Left V Metacarpal": Joint(model.left_v_metacarpal, Matrix(rot_x=-90, rot_z=90)),
    "Left Carpus": Joint(model.left_carpus, Matrix(rot_x=90, rot_z=90)),
    # Right hand
    "Right I Distal": Joint(model.right_i_distal, Matrix(rot_x=90, rot_z=90)),
    "Right I Proximal": Joint(model.right_i_proximal, Matrix(rot_x=90, rot_z=90)),
    "Right I Metacarpal": Joint(model.right_i_metacarpal, Matrix(rot_x=90, rot_z=90)),
    "Right II Distal": Joint(model.right_ii_distal, Matrix(rot_x=90, rot_z=90)),
    "Right II Middle": Joint(model.right_ii_middle, Matrix(rot_x=90, rot_z=90)),
    "Right II Proximal": Joint(model.right_ii_proximal, Matrix(rot_x=90, rot_z=90)),
    "Right II Metacarpal": Joint(model.right_ii_metacarpal, Matrix(rot_x=90, rot_z=90)),
    "Right III Distal": Joint(model.right_iii_distal, Matrix(rot_x=90, rot_z=90)),
    "Right III Middle": Joint(model.right_iii_middle, Matrix(rot_x=90, rot_z=90)),
    "Right III Proximal": Joint(model.right_iii_proximal, Matrix(rot_x=90, rot_z=90)),
    "Right III Metacarpal": Joint(model.right_iii_metacarpal, Matrix(rot_x=90, rot_z=90)),
    "Right IV Distal": Joint(model.right_iv_distal, Matrix(rot_x=90, rot_z=90)),
    "Right IV Middle": Joint(model.right_iv_middle, Matrix(rot_x=90, rot_z=90)),
    "Right IV Proximal": Joint(model.right_iv_proximal, Matrix(rot_x=90, rot_z=90)),
    "Right IV Metacarpal": Joint(model.right_iv_metacarpal, Matrix(rot_x=90, rot_z=90)),
    "Right V Distal": Joint(model.right_v_distal, Matrix(rot_x=90, rot_z=90)),
    "Right V Middle": Joint(model.right_v_middle, Matrix(rot_x=90, rot_z=90)),
    "Right V Proximal": Joint(model.right_v_proximal, Matrix(rot_x=90, rot_z=90)),
    "Right V Metacarpal": Joint(model.right_v_metacarpal, Matrix(rot_x=90, rot_z=90)),
    "Right Carpus": Joint(model.right_carpus, Matrix(rot_x=-90, rot_z=90)),
}

connection = imumocap.viewer.Connection()

while True:
    for angle_name in ["bend", "tilt", "twist"]:
        for angle in [60 * np.sin(x) for x in np.linspace(0, np.pi, 50)]:
            time.sleep(1 / 30)  # 30 fps

            joint_name = "Carpus"  # replace this with joint to inspect

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
                    Label(joint.link.get_joint_world().xyz, f"{joint_name} {angle_name}={angle:.1f}"),
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
