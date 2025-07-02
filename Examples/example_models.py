from abc import ABC, abstractmethod

from imumocap import Joint, Link, Matrix

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
I_LENGTH = 0.11
II_LENGTH = 0.17
III_LENGTH = 0.18
IV_LENGTH = 0.17
V_LENGTH = 0.14
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
        self.left_forearm = Link("Left Forearm", Matrix(y=FOREARM_LENGTH))  # left hand/carpus connected in class constructor
        self.left_upper_arm = Link("Left Upper Arm", Matrix(y=UPPER_ARM_LENGTH)).connect(self.left_forearm)
        self.left_shoulder = Link("Left Shoulder", Matrix(y=SHOULDER_LENGTH)).connect(self.left_upper_arm)

        # Right arm
        self.right_hand = Link("Right Hand", Matrix(y=-HAND_LENGTH))
        self.right_forearm = Link("Right Forearm", Matrix(y=-FOREARM_LENGTH))  # right hand/carpus connected in class constructor
        self.right_upper_arm = Link("Right Upper Arm", Matrix(y=-UPPER_ARM_LENGTH)).connect(self.right_forearm)
        self.right_shoulder = Link("Right Shoulder", Matrix(y=-SHOULDER_LENGTH)).connect(self.right_upper_arm)

        # Upper torso
        self.upper_torso = Link("Upper Torso", Matrix(z=TORSO_LENGTH / 2))
        self.upper_torso.connect(self.neck)
        self.upper_torso.connect(self.left_shoulder, Matrix(y=TORSO_WIDTH / 2, z=-SHOULDER_OFFSET))
        self.upper_torso.connect(self.right_shoulder, Matrix(y=-TORSO_WIDTH / 2, z=-SHOULDER_OFFSET))

        # Lower torso and lumbar
        self.lower_torso = Link("Lower Torso", Matrix(z=TORSO_LENGTH / 2))  # upper torso connected in class constructor
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
        self.pelvis.connect(self.left_upper_leg, Matrix(y=PELVIS_WIDTH / 2, z=-PELVIS_LENGTH))
        self.pelvis.connect(self.right_upper_leg, Matrix(y=-PELVIS_WIDTH / 2, z=-PELVIS_LENGTH))

        # Wheelchair
        self.left_wheel = Link("Left Wheel", Matrix(z=WHEEL_RADIUS), Matrix(y=1))
        self.right_wheel = Link("Right Wheel", Matrix(z=WHEEL_RADIUS), Matrix(y=1))
        self.seat = Link("Seat", Matrix(z=SEAT_HEIGHT))  # pelvis connected in class constructor
        self.seat.connect(self.left_wheel, Matrix(y=-SEAT_WIDTH / 2, z=-SEAT_HEIGHT))
        self.seat.connect(self.right_wheel, Matrix(y=SEAT_WIDTH / 2, z=-SEAT_HEIGHT))

        # Left I phalangeal and metacarpal
        self.left_i_distal = Link("Left I Distal", Matrix(y=I_LENGTH * (MIDDLE_RATIO + DISTAL_RATIO)))
        self.left_i_proximal = Link("Left I Proximal", Matrix(y=I_LENGTH * PROXIMAL_RATIO)).connect(self.left_i_distal)
        self.left_i_metacarpal = Link("Left I Metacarpal", Matrix(y=I_LENGTH * METACARPAL_RATIO)).connect(self.left_i_proximal)

        # Left II phalangeal and metacarpal
        self.left_ii_distal = Link("Left II Distal", Matrix(y=II_LENGTH * DISTAL_RATIO))
        self.left_ii_middle = Link("Left II Middle", Matrix(y=II_LENGTH * MIDDLE_RATIO)).connect(self.left_ii_distal)
        self.left_ii_proximal = Link("Left II Proximal", Matrix(y=II_LENGTH * PROXIMAL_RATIO)).connect(self.left_ii_middle)
        self.left_ii_metacarpal = Link("Left II Metacarpal", Matrix(y=II_LENGTH * METACARPAL_RATIO)).connect(self.left_ii_proximal)

        # Left III phalangeal and metacarpal
        self.left_iii_distal = Link("Left III Distal", Matrix(y=III_LENGTH * DISTAL_RATIO))
        self.left_iii_middle = Link("Left III Middle", Matrix(y=III_LENGTH * MIDDLE_RATIO)).connect(self.left_iii_distal)
        self.left_iii_proximal = Link("Left III Proximal", Matrix(y=III_LENGTH * PROXIMAL_RATIO)).connect(self.left_iii_middle)
        self.left_iii_metacarpal = Link("Left III Metacarpal", Matrix(y=III_LENGTH * METACARPAL_RATIO)).connect(self.left_iii_proximal)

        # Left IV phalangeal and metacarpal
        self.left_iv_distal = Link("Left IV Distal", Matrix(y=IV_LENGTH * DISTAL_RATIO))
        self.left_iv_middle = Link("Left IV Middle", Matrix(y=IV_LENGTH * MIDDLE_RATIO)).connect(self.left_iv_distal)
        self.left_iv_proximal = Link("Left IV Proximal", Matrix(y=IV_LENGTH * PROXIMAL_RATIO)).connect(self.left_iv_middle)
        self.left_iv_metacarpal = Link("Left IV Metacarpal", Matrix(y=IV_LENGTH * METACARPAL_RATIO)).connect(self.left_iv_proximal)

        # Left V phalangeal and metacarpal
        self.left_v_distal = Link("Left V Distal", Matrix(y=V_LENGTH * DISTAL_RATIO))
        self.left_v_middle = Link("Left V Middle", Matrix(y=V_LENGTH * MIDDLE_RATIO)).connect(self.left_v_distal)
        self.left_v_proximal = Link("Left V Proximal", Matrix(y=V_LENGTH * PROXIMAL_RATIO)).connect(self.left_v_middle)
        self.left_v_metacarpal = Link("Left V Metacarpal", Matrix(y=V_LENGTH * METACARPAL_RATIO)).connect(self.left_v_proximal)

        # Left carpus
        self.left_carpus = Link("Left Carpus", Matrix(y=CARPUS_LENGTH))
        self.left_carpus.connect(self.left_i_metacarpal, Matrix(x=CARPUS_WIDTH * 0.5, rot_z=-45))
        self.left_carpus.connect(self.left_ii_metacarpal, Matrix(x=CARPUS_WIDTH * 0.25))
        self.left_carpus.connect(self.left_iii_metacarpal)
        self.left_carpus.connect(self.left_iv_metacarpal, Matrix(x=CARPUS_WIDTH * -0.25))
        self.left_carpus.connect(self.left_v_metacarpal, Matrix(x=CARPUS_WIDTH * -0.5))

        # Right I phalangeal and metacarpal
        self.right_i_distal = Link("Right I Distal", Matrix(y=-I_LENGTH * (MIDDLE_RATIO + DISTAL_RATIO)))
        self.right_i_proximal = Link("Right I Proximal", Matrix(y=-I_LENGTH * PROXIMAL_RATIO)).connect(self.right_i_distal)
        self.right_i_metacarpal = Link("Right I Metacarpal", Matrix(y=-I_LENGTH * METACARPAL_RATIO)).connect(self.right_i_proximal)

        # Right II phalangeal and metacarpal
        self.right_ii_distal = Link("Right II Distal", Matrix(y=-II_LENGTH * DISTAL_RATIO))
        self.right_ii_middle = Link("Right II Middle", Matrix(y=-II_LENGTH * MIDDLE_RATIO)).connect(self.right_ii_distal)
        self.right_ii_proximal = Link("Right II Proximal", Matrix(y=-II_LENGTH * PROXIMAL_RATIO)).connect(self.right_ii_middle)
        self.right_ii_metacarpal = Link("Right II Metacarpal", Matrix(y=-II_LENGTH * METACARPAL_RATIO)).connect(self.right_ii_proximal)

        # Right III phalangeal and metacarpal
        self.right_iii_distal = Link("Right III Distal", Matrix(y=-III_LENGTH * DISTAL_RATIO))
        self.right_iii_middle = Link("Right III Middle", Matrix(y=-III_LENGTH * MIDDLE_RATIO)).connect(self.right_iii_distal)
        self.right_iii_proximal = Link("Right III Proximal", Matrix(y=-III_LENGTH * PROXIMAL_RATIO)).connect(self.right_iii_middle)
        self.right_iii_metacarpal = Link("Right III Metacarpal", Matrix(y=-III_LENGTH * METACARPAL_RATIO)).connect(self.right_iii_proximal)

        # Right IV phalangeal and metacarpal
        self.right_iv_distal = Link("Right IV Distal", Matrix(y=-IV_LENGTH * DISTAL_RATIO))
        self.right_iv_middle = Link("Right IV Middle", Matrix(y=-IV_LENGTH * MIDDLE_RATIO)).connect(self.right_iv_distal)
        self.right_iv_proximal = Link("Right IV Proximal", Matrix(y=-IV_LENGTH * PROXIMAL_RATIO)).connect(self.right_iv_middle)
        self.right_iv_metacarpal = Link("Right IV Metacarpal", Matrix(y=-IV_LENGTH * METACARPAL_RATIO)).connect(self.right_iv_proximal)

        # Right V phalangeal and metacarpal
        self.right_v_distal = Link("Right V Distal", Matrix(y=-V_LENGTH * DISTAL_RATIO))
        self.right_v_middle = Link("Right V Middle", Matrix(y=-V_LENGTH * MIDDLE_RATIO)).connect(self.right_v_distal)
        self.right_v_proximal = Link("Right V Proximal", Matrix(y=-V_LENGTH * PROXIMAL_RATIO)).connect(self.right_v_middle)
        self.right_v_metacarpal = Link("Right V Metacarpal", Matrix(y=-V_LENGTH * METACARPAL_RATIO)).connect(self.right_v_proximal)

        # Right carpus
        self.right_carpus = Link("Right Carpus", Matrix(y=-CARPUS_LENGTH))
        self.right_carpus.connect(self.right_i_metacarpal, Matrix(x=CARPUS_WIDTH * 0.5, rot_z=45))
        self.right_carpus.connect(self.right_ii_metacarpal, Matrix(x=CARPUS_WIDTH * 0.25))
        self.right_carpus.connect(self.right_iii_metacarpal)
        self.right_carpus.connect(self.right_iv_metacarpal, Matrix(x=CARPUS_WIDTH * -0.25))
        self.right_carpus.connect(self.right_v_metacarpal, Matrix(x=CARPUS_WIDTH * -0.5))

        # Joints
        self.__joints = {
            # Head
            "Head": Joint(self.head, Matrix.align_nz_nx_py()),
            "Neck": Joint(self.neck, Matrix.align_nz_nx_py()),
            # Left arm
            "Left Wrist": Joint(self.left_hand, Matrix.align_py_pz_px()),
            "Left Elbow": Joint(self.left_forearm, Matrix.align_py_px_nz()),
            "Left Shoulder": Joint(self.left_upper_arm, Matrix.align_px_ny_nz()),
            "Left Clavicle": Joint(self.left_shoulder, Matrix.align_px_ny_nz()),
            # Right arm
            "Right Wrist": Joint(self.right_hand, Matrix.align_py_nz_nx()),
            "Right Elbow": Joint(self.right_forearm, Matrix.align_py_nx_pz()),
            "Right Shoulder": Joint(self.right_upper_arm, Matrix.align_nx_ny_pz()),
            "Right Clavicle": Joint(self.right_shoulder, Matrix.align_nx_ny_pz()),
            # Torso
            "Upper Torso": Joint(self.upper_torso, Matrix.align_nz_nx_py()),
            "Lower Torso": Joint(self.lower_torso, Matrix.align_nz_nx_py()),
            "Upper Lumbar": Joint(self.upper_lumbar, Matrix.align_nz_nx_py()),
            "Lower Lumbar": Joint(self.lower_lumbar, Matrix.align_nz_nx_py()),
            # Left leg
            "Left Toe": Joint(self.left_toe, Matrix.align_px_nz_py()),
            "Left Ankle": Joint(self.left_foot, Matrix.align_nz_px_ny()),
            "Left Knee": Joint(self.left_lower_leg, Matrix.align_nz_nx_py()),
            "Left Hip": Joint(self.left_upper_leg, Matrix.align_nz_px_ny()),
            # Right leg
            "Right Toe": Joint(self.right_toe, Matrix.align_nx_pz_py()),
            "Right Ankle": Joint(self.right_foot, Matrix.align_pz_nx_ny()),
            "Right Knee": Joint(self.right_lower_leg, Matrix.align_pz_px_py()),
            "Right Hip": Joint(self.right_upper_leg, Matrix.align_pz_nx_ny()),
            # Pelvis
            "Pelvis": Joint(self.pelvis, Matrix.align_py_nx_pz()),
            # Wheelchair
            "Left Wheel": Joint(self.left_wheel, Matrix.align_py_nx_pz()),
            "Right Wheel": Joint(self.right_wheel, Matrix.align_py_px_nz()),
            "Seat": Joint(self.seat, Matrix.align_py_nx_pz()),
            # Left hand
            "Left I Distal": Joint(self.left_i_distal, Matrix.align_py_nz_nx()),
            "Left I Proximal": Joint(self.left_i_proximal, Matrix.align_py_nz_nx()),
            "Left I Metacarpal": Joint(self.left_i_metacarpal, Matrix.align_py_nz_nx()),
            "Left II Distal": Joint(self.left_ii_distal, Matrix.align_py_nz_nx()),
            "Left II Middle": Joint(self.left_ii_middle, Matrix.align_py_nz_nx()),
            "Left II Proximal": Joint(self.left_ii_proximal, Matrix.align_py_nz_nx()),
            "Left II Metacarpal": Joint(self.left_ii_metacarpal, Matrix.align_py_nz_nx()),
            "Left III Distal": Joint(self.left_iii_distal, Matrix.align_py_nz_nx()),
            "Left III Middle": Joint(self.left_iii_middle, Matrix.align_py_nz_nx()),
            "Left III Proximal": Joint(self.left_iii_proximal, Matrix.align_py_nz_nx()),
            "Left III Metacarpal": Joint(self.left_iii_metacarpal, Matrix.align_py_nz_nx()),
            "Left IV Distal": Joint(self.left_iv_distal, Matrix.align_py_nz_nx()),
            "Left IV Middle": Joint(self.left_iv_middle, Matrix.align_py_nz_nx()),
            "Left IV Proximal": Joint(self.left_iv_proximal, Matrix.align_py_nz_nx()),
            "Left IV Metacarpal": Joint(self.left_iv_metacarpal, Matrix.align_py_nz_nx()),
            "Left V Distal": Joint(self.left_v_distal, Matrix.align_py_nz_nx()),
            "Left V Middle": Joint(self.left_v_middle, Matrix.align_py_nz_nx()),
            "Left V Proximal": Joint(self.left_v_proximal, Matrix.align_py_nz_nx()),
            "Left V Metacarpal": Joint(self.left_v_metacarpal, Matrix.align_py_nz_nx()),
            "Left Carpus": Joint(self.left_carpus, Matrix.align_py_pz_px()),
            # Right hand
            "Right I Distal": Joint(self.right_i_distal, Matrix.align_py_pz_px()),
            "Right I Proximal": Joint(self.right_i_proximal, Matrix.align_py_pz_px()),
            "Right I Metacarpal": Joint(self.right_i_metacarpal, Matrix.align_py_pz_px()),
            "Right II Distal": Joint(self.right_ii_distal, Matrix.align_py_pz_px()),
            "Right II Middle": Joint(self.right_ii_middle, Matrix.align_py_pz_px()),
            "Right II Proximal": Joint(self.right_ii_proximal, Matrix.align_py_pz_px()),
            "Right II Metacarpal": Joint(self.right_ii_metacarpal, Matrix.align_py_pz_px()),
            "Right III Distal": Joint(self.right_iii_distal, Matrix.align_py_pz_px()),
            "Right III Middle": Joint(self.right_iii_middle, Matrix.align_py_pz_px()),
            "Right III Proximal": Joint(self.right_iii_proximal, Matrix.align_py_pz_px()),
            "Right III Metacarpal": Joint(self.right_iii_metacarpal, Matrix.align_py_pz_px()),
            "Right IV Distal": Joint(self.right_iv_distal, Matrix.align_py_pz_px()),
            "Right IV Middle": Joint(self.right_iv_middle, Matrix.align_py_pz_px()),
            "Right IV Proximal": Joint(self.right_iv_proximal, Matrix.align_py_pz_px()),
            "Right IV Metacarpal": Joint(self.right_iv_metacarpal, Matrix.align_py_pz_px()),
            "Right V Distal": Joint(self.right_v_distal, Matrix.align_py_pz_px()),
            "Right V Middle": Joint(self.right_v_middle, Matrix.align_py_pz_px()),
            "Right V Proximal": Joint(self.right_v_proximal, Matrix.align_py_pz_px()),
            "Right V Metacarpal": Joint(self.right_v_metacarpal, Matrix.align_py_pz_px()),
            "Right Carpus": Joint(self.right_carpus, Matrix.align_py_nz_nx()),
        }

    @property
    @abstractmethod
    def root(self) -> Link:
        pass

    def _remove_unused_joints(self) -> None:
        links = [l.name for l in self.root.flatten()]

        self.__joints = {n: j for n, j in self.joints.items() if j.link.name in links}

    def _connect_hands_to_arms(self) -> None:
        self.left_forearm.connect(self.left_hand)
        self.right_forearm.connect(self.right_hand)

    def _connect_lumbar_to_pelvis(self) -> None:
        self.pelvis.connect(self.lower_lumbar)

    def _connect_torso(self) -> None:
        self.lower_torso.connect(self.upper_torso)

    def _connect_pelvis_to_seat(self) -> None:
        self.seat.connect(self.pelvis)

    def _connect_carpi_to_arms(self) -> None:
        self.left_forearm.connect(self.left_carpus)
        self.right_forearm.connect(self.right_carpus)

    @property
    def joints(self) -> dict[str, Joint]:
        return self.__joints


class UpperBody(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_hands_to_arms()
        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.upper_torso


class LowerBody(Model):
    def __init__(self) -> None:
        super().__init__()

        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.pelvis


class Body(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_hands_to_arms()
        self._connect_torso()
        self._connect_lumbar_to_pelvis()
        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.pelvis


class Wheelchair(Model):
    def __init__(self) -> None:
        super().__init__()

        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.seat


class BodyWithWheelchair(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_hands_to_arms()
        self._connect_torso()
        self._connect_lumbar_to_pelvis()
        self._connect_pelvis_to_seat()
        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.seat


class LeftHand(Model):
    def __init__(self) -> None:
        super().__init__()

        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.left_carpus


class RightHand(Model):
    def __init__(self) -> None:
        super().__init__()

        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.right_carpus


class UpperBodyWithHands(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_carpi_to_arms()
        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.upper_torso


class BodyWithHands(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_carpi_to_arms()
        self._connect_torso()
        self._connect_lumbar_to_pelvis()
        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.pelvis


class BodyWithWheelchairAndHands(Model):
    def __init__(self) -> None:
        super().__init__()

        self._connect_carpi_to_arms()
        self._connect_torso()
        self._connect_lumbar_to_pelvis()
        self._connect_pelvis_to_seat()
        self._remove_unused_joints()

    @property
    def root(self) -> Link:
        return self.seat
