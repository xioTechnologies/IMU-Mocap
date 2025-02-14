from __future__ import annotations

import time
from typing import Dict, Tuple

import imumocap
import models
import numpy as np
from imumocap import Label, Link, Matrix

model = models.Body()


# An interface to get and set Link joint matrix rotations through three angular
# quantities: bend, tilt, and twist. Bend and twist angles may be between
# +/-180 degrees, tilt angles must not exceed or approach +/-90 degrees.
#
# Flexion vs. Extension:
#     Flexion (bending) is usually positive.
#     Extension (straightening) is usually negative.
# Abduction vs. Adduction:
#     Abduction (moving away from the body's midline) is typically positive.
#     Adduction (moving toward the midline) is typically negative.
# Internal vs. External Rotation:
#     Internal (medial) rotation is often positive.
#     External (lateral) rotation is often negative.


class Joint:
    def __init__(self, link: Link, alignment: Matrix = Matrix()) -> None:
        self.__link = link
        self.__alignment = alignment

    @property
    def link(self) -> Link:
        return self.__link

    def get(self) -> Tuple[float, float, float]:
        return (self.__alignment.T * self.__link.joint * self.__alignment).rot_xyz

    def set(self, bend: float = 0, tilt: float = 0, twist: float = 0) -> None:
        self.__link.joint = self.__alignment * Matrix(rot_x=twist, rot_y=tilt, rot_z=bend) * self.__alignment.T

    @staticmethod
    def to_json(joints: Dict[Joint]) -> str:
        return ""

    @staticmethod
    def get_angles_as_json(joints: Dict[Joint]) -> str:
        return "{Head : {bend=0, tilt=0, twist=0},\
                 Neck : {bend=0, tilt=0, twist=0}}"

    @staticmethod
    def set_angles_from_json(json: str) -> None:
        pass


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
    "Left Toe": Joint(model.left_toe, Matrix(rot_x=90)),
    "Left Ankle": Joint(model.left_foot, Matrix(rot_x=90, rot_y=90)),
    "Left Knee": Joint(model.left_lower_leg, Matrix(rot_x=-90, rot_y=90)),
    "Left Hip": Joint(model.left_upper_leg, Matrix(rot_x=90, rot_y=90)),
    # Right leg
    "Right Toe": Joint(model.right_toe, Matrix(rot_x=-90, rot_z=180)),
    "Right Ankle": Joint(model.right_foot, Matrix(rot_x=90, rot_y=-90)),
    "Right Knee": Joint(model.right_lower_leg, Matrix(rot_x=-90, rot_y=-90)),
    "Right Hip": Joint(model.right_upper_leg, Matrix(rot_x=90, rot_y=-90)),
}

connection = imumocap.viewer.Connection()

while True:
    for name in ["bend", "tilt", "twist"]:
        for angle in [60 * np.sin(x) for x in np.linspace(0, np.pi, 50)]:
            time.sleep(1 / 30)  # 30 fps

            for joint in [joints["Left Shoulder"], joints["Right Shoulder"]]:
                # for joint in [joints[list(joints)[-1]]]:
                match name:
                    case "bend":
                        joint.set(bend=angle)
                    case "tilt":
                        joint.set(tilt=angle)
                    case "twist":
                        joint.set(twist=angle)

                connection.send(
                    [
                        *imumocap.viewer.link_to_primitives(model.root),
                        Label(joint.link.get_joint_global().xyz, f"{name}={angle:.1f}"),
                    ]
                )
