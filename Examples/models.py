from abc import ABC, abstractmethod

from imumocap import Link, Matrix

# Head
HEAD_LENGTH = 0.20
NECK_LENGTH = 0.10

# Arms
HAND_LENGTH = 0.20
FOREARM_LENGTH = 0.25
UPPER_ARM_LENGTH = 0.30
SHOULDER_LENGTH = 0.15

# Torso
TORSO_LENGTH = 0.30
TORSO_WIDTH = 0.10
SHOULDER_OFFSET = 0.05
LUMBAR_LENGTH = 0.30

# Legs
TOE_LENGTH = 0.05
FOOT_HEIGHT = 0.10
FOOT_LENGTH = 0.15
UPPER_LEG_LENGTH = 0.45
LOWER_LEG_LENGTH = 0.45

# Pelvis
PELVIS_LENGTH = 0.15
PELVIS_WIDTH = 0.3

# Wheelchair
WHEEL_RADIUS = 0.4
SEAT_HEIGHT = 0.2
SEAT_WIDTH = 0.8

# Hands
FIRST_LENGTH = 0.11
SECOND_LENGTH = 0.17
THIRD_LENGTH = 0.18
FORTH_LENGTH = 0.17
FIFTH_LENGTH = 0.14
METACARPAL_RATIO = 0.35
PROXIMAL_RATIO = 0.3
MIDDLE_RATIO = 0.2
DISTAL_RATIO = 0.15
CARPUS_WIDTH = 0.08
CARPUS_LENGTH = 0.03


class Model(ABC):
    def __init__(self) -> None:
        # Head
        self.head = Link("Head", Matrix(z=HEAD_LENGTH))
        self.neck = Link("Neck", Matrix(z=NECK_LENGTH)).connect(self.head)

        # Left arm
        self.left_hand = Link("Left Hand", Matrix(y=HAND_LENGTH))
        self.left_forearm = Link("Left Forearm", Matrix(y=FOREARM_LENGTH))
        self.left_upper_arm = Link("Left Upper Arm", Matrix(y=UPPER_ARM_LENGTH)).connect(self.left_forearm)
        self.left_shoulder = Link("Left Shoulder", Matrix(y=SHOULDER_LENGTH)).connect(self.left_upper_arm)

        # Right arm
        self.right_hand = Link("Right Hand", Matrix(y=-HAND_LENGTH))
        self.right_forearm = Link("Right Forearm", Matrix(y=-FOREARM_LENGTH))
        self.right_upper_arm = Link("Right Upper Arm", Matrix(y=-UPPER_ARM_LENGTH)).connect(self.right_forearm)
        self.right_shoulder = Link("Right Shoulder", Matrix(y=-SHOULDER_LENGTH)).connect(self.right_upper_arm)

        # Torso
        self.upper_torso = Link("Upper Torso", Matrix(z=TORSO_LENGTH / 2))
        self.upper_torso.connect(self.neck)
        self.upper_torso.connect(self.left_shoulder, Matrix(y=TORSO_WIDTH / 2, z=-SHOULDER_OFFSET))
        self.upper_torso.connect(self.right_shoulder, Matrix(y=-TORSO_WIDTH / 2, z=-SHOULDER_OFFSET))
        self.lower_torso = Link("Lower Torso", Matrix(z=TORSO_LENGTH / 2)).connect(self.upper_torso)
        self.upper_lumbar = Link("Upper Lumbar", Matrix(z=LUMBAR_LENGTH / 2)).connect(self.lower_torso)
        self.lower_lumbar = Link("Lower Lumbar", Matrix(z=LUMBAR_LENGTH / 2)).connect(self.upper_lumbar)

        # Left leg
        self.left_toe = Link("Left Toe", Matrix(x=TOE_LENGTH))
        self.left_foot = Link("Left Foot", Matrix(z=-FOOT_HEIGHT)).connect(self.left_toe, Matrix(x=FOOT_LENGTH))
        self.left_lower_leg = Link("Left Lower Leg", Matrix(z=-LOWER_LEG_LENGTH)).connect(self.left_foot)
        self.left_upper_leg = Link("Left Upper Leg", Matrix(z=-UPPER_LEG_LENGTH)).connect(self.left_lower_leg)

        # Right leg
        self.right_toe = Link("Right Toe", Matrix(x=TOE_LENGTH))
        self.right_foot = Link("Right Foot", Matrix(z=-FOOT_HEIGHT)).connect(self.right_toe, Matrix(x=FOOT_LENGTH))
        self.right_lower_leg = Link("Right Lower Leg", Matrix(z=-LOWER_LEG_LENGTH)).connect(self.right_foot)
        self.right_upper_leg = Link("Right Upper Leg", Matrix(z=-UPPER_LEG_LENGTH)).connect(self.right_lower_leg)

        # Pelvis
        self.pelvis = Link("Pelvis", Matrix(z=PELVIS_LENGTH))

        # Wheelchair
        self.left_wheel = Link("Left Wheel", Matrix(z=WHEEL_RADIUS), Matrix(y=1))
        self.right_wheel = Link("Right Wheel", Matrix(z=WHEEL_RADIUS), Matrix(y=1))
        self.seat = Link("Seat", Matrix(z=SEAT_HEIGHT))
        self.seat.connect(self.left_wheel, Matrix(y=-SEAT_WIDTH / 2, z=-SEAT_HEIGHT))
        self.seat.connect(self.right_wheel, Matrix(y=SEAT_WIDTH / 2, z=-SEAT_HEIGHT))

        # Left first phalangeal and metacarpal
        self.left_first_distal = Link("Left First Distal", self.left_first_transformation(Matrix(y=FIRST_LENGTH * (MIDDLE_RATIO + DISTAL_RATIO))))
        self.left_first_proximal = Link("Left First Proximal", self.left_first_transformation(Matrix(y=FIRST_LENGTH * PROXIMAL_RATIO))).connect(self.left_first_distal)
        self.left_first_metacarpal = Link("Left First Metacarpal", self.left_first_transformation(Matrix(y=FIRST_LENGTH * METACARPAL_RATIO))).connect(self.left_first_proximal)

        # Left second phalangeal and metacarpal
        self.left_second_distal = Link("Left Second Distal", Matrix(y=SECOND_LENGTH * DISTAL_RATIO))
        self.left_second_middle = Link("Left Second Middle", Matrix(y=SECOND_LENGTH * MIDDLE_RATIO)).connect(self.left_second_distal)
        self.left_second_proximal = Link("Left Second Proximal", Matrix(y=SECOND_LENGTH * PROXIMAL_RATIO)).connect(self.left_second_middle)
        self.left_second_metacarpal = Link("Left Second Metacarpal", Matrix(y=SECOND_LENGTH * METACARPAL_RATIO)).connect(self.left_second_proximal)

        # Left third phalangeal and metacarpal
        self.left_third_distal = Link("Left Third Distal", Matrix(y=THIRD_LENGTH * DISTAL_RATIO))
        self.left_third_middle = Link("Left Third Middle", Matrix(y=THIRD_LENGTH * MIDDLE_RATIO)).connect(self.left_third_distal)
        self.left_third_proximal = Link("Left Third Proximal", Matrix(y=THIRD_LENGTH * PROXIMAL_RATIO)).connect(self.left_third_middle)
        self.left_third_metacarpal = Link("Left Third Metacarpal", Matrix(y=THIRD_LENGTH * METACARPAL_RATIO)).connect(self.left_third_proximal)

        # Left forth phalangeal and metacarpal
        self.left_forth_distal = Link("Left Forth Distal", Matrix(y=FORTH_LENGTH * DISTAL_RATIO))
        self.left_forth_middle = Link("Left Forth Middle", Matrix(y=FORTH_LENGTH * MIDDLE_RATIO)).connect(self.left_forth_distal)
        self.left_forth_proximal = Link("Left Forth Proximal", Matrix(y=FORTH_LENGTH * PROXIMAL_RATIO)).connect(self.left_forth_middle)
        self.left_forth_metacarpal = Link("Left Forth Metacarpal", Matrix(y=FORTH_LENGTH * METACARPAL_RATIO)).connect(self.left_forth_proximal)

        # Left fifth phalangeal and metacarpal
        self.left_fifth_distal = Link("Left Fith Distal", Matrix(y=FIFTH_LENGTH * DISTAL_RATIO))
        self.left_fifth_middle = Link("Left Fith Middle", Matrix(y=FIFTH_LENGTH * MIDDLE_RATIO)).connect(self.left_fifth_distal)
        self.left_fifth_proximal = Link("Left Fith Proximal", Matrix(y=FIFTH_LENGTH * PROXIMAL_RATIO)).connect(self.left_fifth_middle)
        self.left_fifth_metacarpal = Link("Left Fith Metacarpal", Matrix(y=FIFTH_LENGTH * METACARPAL_RATIO)).connect(self.left_fifth_proximal)

        # Left carpus
        self.left_carpus = Link("Left Carpus", Matrix(y=CARPUS_LENGTH))
        self.left_carpus.connect(self.left_first_metacarpal, Matrix(x=CARPUS_WIDTH * 0.5))
        self.left_carpus.connect(self.left_second_metacarpal, Matrix(x=CARPUS_WIDTH * 0.25))
        self.left_carpus.connect(self.left_third_metacarpal)
        self.left_carpus.connect(self.left_forth_metacarpal, Matrix(x=CARPUS_WIDTH * -0.25))
        self.left_carpus.connect(self.left_fifth_metacarpal, Matrix(x=CARPUS_WIDTH * -0.5))

        # Right first phalangeal and metacarpal
        self.right_first_distal = Link("Right First Distal", self.right_first_transformation(Matrix(y=-FIRST_LENGTH * (MIDDLE_RATIO + DISTAL_RATIO))))
        self.right_first_proximal = Link("Right First Proximal", self.right_first_transformation(Matrix(y=-FIRST_LENGTH * PROXIMAL_RATIO))).connect(self.right_first_distal)
        self.right_first_metacarpal = Link("Right First Metacarpal", self.right_first_transformation(Matrix(y=-FIRST_LENGTH * METACARPAL_RATIO))).connect(self.right_first_proximal)

        # Right second phalangeal and metacarpal
        self.right_second_distal = Link("Right Second Distal", Matrix(y=-SECOND_LENGTH * DISTAL_RATIO))
        self.right_second_middle = Link("Right Second Middle", Matrix(y=-SECOND_LENGTH * MIDDLE_RATIO)).connect(self.right_second_distal)
        self.right_second_proximal = Link("Right Second Proximal", Matrix(y=-SECOND_LENGTH * PROXIMAL_RATIO)).connect(self.right_second_middle)
        self.right_second_metacarpal = Link("Right Second Metacarpal", Matrix(y=-SECOND_LENGTH * METACARPAL_RATIO)).connect(self.right_second_proximal)

        # Right third phalangeal and metacarpal
        self.right_third_distal = Link("Right Third Distal", Matrix(y=-THIRD_LENGTH * DISTAL_RATIO))
        self.right_third_middle = Link("Right Third Middle", Matrix(y=-THIRD_LENGTH * MIDDLE_RATIO)).connect(self.right_third_distal)
        self.right_third_proximal = Link("Right Third Proximal", Matrix(y=-THIRD_LENGTH * PROXIMAL_RATIO)).connect(self.right_third_middle)
        self.right_third_metacarpal = Link("Right Third Metacarpal", Matrix(y=-THIRD_LENGTH * METACARPAL_RATIO)).connect(self.right_third_proximal)

        # Right forth phalangeal and metacarpal
        self.right_forth_distal = Link("Right Forth Distal", Matrix(y=-FORTH_LENGTH * DISTAL_RATIO))
        self.right_forth_middle = Link("Right Forth Middle", Matrix(y=-FORTH_LENGTH * MIDDLE_RATIO)).connect(self.right_forth_distal)
        self.right_forth_proximal = Link("Right Forth Proximal", Matrix(y=-FORTH_LENGTH * PROXIMAL_RATIO)).connect(self.right_forth_middle)
        self.right_forth_metacarpal = Link("Right Forth Metacarpal", Matrix(y=-FORTH_LENGTH * METACARPAL_RATIO)).connect(self.right_forth_proximal)

        # Right fifth phalangeal and metacarpal
        self.right_fifth_distal = Link("Right Fith Distal", Matrix(y=-FIFTH_LENGTH * DISTAL_RATIO))
        self.right_fifth_middle = Link("Right Fith Middle", Matrix(y=-FIFTH_LENGTH * MIDDLE_RATIO)).connect(self.right_fifth_distal)
        self.right_fifth_proximal = Link("Right Fith Proximal", Matrix(y=-FIFTH_LENGTH * PROXIMAL_RATIO)).connect(self.right_fifth_middle)
        self.right_fifth_metacarpal = Link("Right Fith Metacarpal", Matrix(y=-FIFTH_LENGTH * METACARPAL_RATIO)).connect(self.right_fifth_proximal)

        # Right carpus
        self.right_carpus = Link("Right Carpus", Matrix(y=-CARPUS_LENGTH))
        self.right_carpus.connect(self.right_first_metacarpal, Matrix(x=CARPUS_WIDTH * 0.5))
        self.right_carpus.connect(self.right_second_metacarpal, Matrix(x=CARPUS_WIDTH * 0.25))
        self.right_carpus.connect(self.right_third_metacarpal)
        self.right_carpus.connect(self.right_forth_metacarpal, Matrix(x=CARPUS_WIDTH * -0.25))
        self.right_carpus.connect(self.right_fifth_metacarpal, Matrix(x=CARPUS_WIDTH * -0.5))

    @property
    @abstractmethod
    def root(self) -> Link:
        pass

    def left_first_transformation(self, end: Matrix) -> Matrix:
        alignment = Matrix(rot_y=30, rot_z=-40)

        return alignment * end * alignment.T

    def right_first_transformation(self, end: Matrix) -> Matrix:
        alignment = Matrix(rot_y=30, rot_z=40)

        return alignment * end * alignment.T

    def _connect_hands_to_arms(self) -> None:
        self.left_forearm.connect(self.left_hand)
        self.right_forearm.connect(self.right_hand)

    def _connect_legs_to_pelvis(self) -> None:
        self.pelvis.connect(self.left_upper_leg, Matrix(y=PELVIS_WIDTH / 2, z=-PELVIS_LENGTH))
        self.pelvis.connect(self.right_upper_leg, Matrix(y=-PELVIS_WIDTH / 2, z=-PELVIS_LENGTH))

    def _connect_lumbar_to_pelvis(self) -> None:
        self.pelvis.connect(self.lower_lumbar)

    def _connect_pelvis_to_seat(self) -> None:
        self.seat.connect(self.pelvis)

    def _connect_carpi_to_arms(self) -> None:
        self.left_forearm.connect(self.left_carpus)
        self.right_forearm.connect(self.right_carpus)


class UpperBody(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_hands_to_arms()

    @property
    def root(self) -> Link:
        return self.lower_lumbar


class LowerBody(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_legs_to_pelvis()

    @property
    def root(self) -> Link:
        return self.pelvis


class Body(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_hands_to_arms()
        self._connect_lumbar_to_pelvis()
        self._connect_legs_to_pelvis()

    @property
    def root(self) -> Link:
        return self.pelvis


class Wheelchair(Model):
    def __init__(self) -> None:
        super().__init__()

    @property
    def root(self) -> Link:
        return self.seat


class BodyWithWheelchair(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_hands_to_arms()
        self._connect_lumbar_to_pelvis()
        self._connect_legs_to_pelvis()
        self._connect_pelvis_to_seat()

    @property
    def root(self) -> Link:
        return self.seat


class LeftHand(Model):
    def __init__(self) -> None:
        super().__init__()

    @property
    def root(self) -> Link:
        return self.left_carpus


class RightHand(Model):
    def __init__(self) -> None:
        super().__init__()

    @property
    def root(self) -> Link:
        return self.right_carpus


class UpperBodyWithHands(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_carpi_to_arms()

    @property
    def root(self) -> Link:
        return self.lower_lumbar


class BodyWithHands(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_carpi_to_arms()
        self._connect_lumbar_to_pelvis()
        self._connect_legs_to_pelvis()

    @property
    def root(self) -> Link:
        return self.pelvis


class BodyWithWheelchairAndHands(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_carpi_to_arms()
        self._connect_lumbar_to_pelvis()
        self._connect_legs_to_pelvis()
        self._connect_pelvis_to_seat()

    @property
    def root(self) -> Link:
        return self.seat
