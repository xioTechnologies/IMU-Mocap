from imumocap import Joint, Link, Matrix, Model

# Head
_HEAD_LENGTH = 0.20
_NECK_LENGTH = 0.10

# Arms
_HAND_LENGTH = 0.20
_FOREARM_LENGTH = 0.25
_UPPER_ARM_LENGTH = 0.30
_SHOULDER_LENGTH = 0.15

# Torso
_TORSO_LENGTH = 0.30
_TORSO_WIDTH = 0.10
_SHOULDER_OFFSET = 0.05
_LUMBAR_LENGTH = 0.30

# Legs
_TOE_LENGTH = 0.05
_FOOT_HEIGHT = 0.10
_FOOT_LENGTH = 0.15
_UPPER_LEG_LENGTH = 0.45
_LOWER_LEG_LENGTH = 0.45

# Pelvis
_PELVIS_LENGTH = 0.15
_PELVIS_WIDTH = 0.3

# Wheelchair
_WHEEL_RADIUS = 0.4
_SEAT_HEIGHT = 0.2
_SEAT_WIDTH = 0.8

# Hands
_I_LENGTH = 0.11
_II_LENGTH = 0.17
_III_LENGTH = 0.18
_IV_LENGTH = 0.17
_V_LENGTH = 0.14
_METACARPAL_RATIO = 0.35
_PROXIMAL_RATIO = 0.3
_MIDDLE_RATIO = 0.2
_DISTAL_RATIO = 0.15
_CARPUS_WIDTH = 0.08
_CARPUS_LENGTH = 0.03


class Factory:
    def __init__(self) -> None:
        # Head
        self.__head = Link("Head", Matrix(z=_HEAD_LENGTH))
        self.__neck = Link("Neck", Matrix(z=_NECK_LENGTH)).connect(self.__head)

        # Left arm
        self.__left_hand = Link("Left Hand", Matrix(y=_HAND_LENGTH))
        self.__left_forearm = Link("Left Forearm", Matrix(y=_FOREARM_LENGTH))  # left hand/carpus not connected yet
        self.__left_upper_arm = Link("Left Upper Arm", Matrix(y=_UPPER_ARM_LENGTH)).connect(self.__left_forearm)
        self.__left_shoulder = Link("Left Shoulder", Matrix(y=_SHOULDER_LENGTH)).connect(self.__left_upper_arm)

        # Right arm
        self.__right_hand = Link("Right Hand", Matrix(y=-_HAND_LENGTH))
        self.__right_forearm = Link("Right Forearm", Matrix(y=-_FOREARM_LENGTH))  # right and/carpus not connected yet
        self.__right_upper_arm = Link("Right Upper Arm", Matrix(y=-_UPPER_ARM_LENGTH)).connect(self.__right_forearm)
        self.__right_shoulder = Link("Right Shoulder", Matrix(y=-_SHOULDER_LENGTH)).connect(self.__right_upper_arm)

        # Upper torso
        self.__upper_torso = Link("Upper Torso", Matrix(z=_TORSO_LENGTH / 2))
        self.__upper_torso.connect(self.__neck)
        self.__upper_torso.connect(self.__left_shoulder, Matrix(y=_TORSO_WIDTH / 2, z=-_SHOULDER_OFFSET))
        self.__upper_torso.connect(self.__right_shoulder, Matrix(y=-_TORSO_WIDTH / 2, z=-_SHOULDER_OFFSET))

        # Lower torso and lumbar
        self.__lower_torso = Link("Lower Torso", Matrix(z=_TORSO_LENGTH / 2))  # upper torso not connected yet
        self.__upper_lumbar = Link("Upper Lumbar", Matrix(z=_LUMBAR_LENGTH / 2)).connect(self.__lower_torso)
        self.__lower_lumbar = Link("Lower Lumbar", Matrix(z=_LUMBAR_LENGTH / 2)).connect(self.__upper_lumbar)

        # Left leg
        self.__left_toe = Link("Left Toe", Matrix(x=_TOE_LENGTH))
        self.__left_foot = Link("Left Foot", Matrix(z=-_FOOT_HEIGHT)).connect(self.__left_toe, Matrix(x=_FOOT_LENGTH))
        self.__left_lower_leg = Link("Left Lower Leg", Matrix(z=-_LOWER_LEG_LENGTH)).connect(self.__left_foot)
        self.__left_upper_leg = Link("Left Upper Leg", Matrix(z=-_UPPER_LEG_LENGTH)).connect(self.__left_lower_leg)

        # Right leg
        self.__right_toe = Link("Right Toe", Matrix(x=_TOE_LENGTH))
        self.__right_foot = Link("Right Foot", Matrix(z=-_FOOT_HEIGHT)).connect(self.__right_toe, Matrix(x=_FOOT_LENGTH))
        self.__right_lower_leg = Link("Right Lower Leg", Matrix(z=-_LOWER_LEG_LENGTH)).connect(self.__right_foot)
        self.__right_upper_leg = Link("Right Upper Leg", Matrix(z=-_UPPER_LEG_LENGTH)).connect(self.__right_lower_leg)

        # Pelvis
        self.__pelvis = Link("Pelvis", Matrix(z=_PELVIS_LENGTH))
        self.__pelvis.connect(self.__left_upper_leg, Matrix(y=_PELVIS_WIDTH / 2, z=-_PELVIS_LENGTH))
        self.__pelvis.connect(self.__right_upper_leg, Matrix(y=-_PELVIS_WIDTH / 2, z=-_PELVIS_LENGTH))

        # Wheelchair
        self.__left_wheel = Link("Left Wheel", Matrix(z=_WHEEL_RADIUS), Matrix(y=1))
        self.__right_wheel = Link("Right Wheel", Matrix(z=_WHEEL_RADIUS), Matrix(y=1))
        self.__seat = Link("Seat", Matrix(z=_SEAT_HEIGHT))  # pelvis not connected yet
        self.__seat.connect(self.__left_wheel, Matrix(y=-_SEAT_WIDTH / 2, z=-_SEAT_HEIGHT))
        self.__seat.connect(self.__right_wheel, Matrix(y=_SEAT_WIDTH / 2, z=-_SEAT_HEIGHT))

        # Left I phalangeal and metacarpal
        self.__left_i_distal = Link("Left I Distal", Matrix(y=_I_LENGTH * (_MIDDLE_RATIO + _DISTAL_RATIO)))
        self.__left_i_proximal = Link("Left I Proximal", Matrix(y=_I_LENGTH * _PROXIMAL_RATIO)).connect(self.__left_i_distal)
        self.__left_i_metacarpal = Link("Left I Metacarpal", Matrix(y=_I_LENGTH * _METACARPAL_RATIO)).connect(self.__left_i_proximal)

        # Left II phalangeal and metacarpal
        self.__left_ii_distal = Link("Left II Distal", Matrix(y=_II_LENGTH * _DISTAL_RATIO))
        self.__left_ii_middle = Link("Left II Middle", Matrix(y=_II_LENGTH * _MIDDLE_RATIO)).connect(self.__left_ii_distal)
        self.__left_ii_proximal = Link("Left II Proximal", Matrix(y=_II_LENGTH * _PROXIMAL_RATIO)).connect(self.__left_ii_middle)
        self.__left_ii_metacarpal = Link("Left II Metacarpal", Matrix(y=_II_LENGTH * _METACARPAL_RATIO)).connect(self.__left_ii_proximal)

        # Left III phalangeal and metacarpal
        self.__left_iii_distal = Link("Left III Distal", Matrix(y=_III_LENGTH * _DISTAL_RATIO))
        self.__left_iii_middle = Link("Left III Middle", Matrix(y=_III_LENGTH * _MIDDLE_RATIO)).connect(self.__left_iii_distal)
        self.__left_iii_proximal = Link("Left III Proximal", Matrix(y=_III_LENGTH * _PROXIMAL_RATIO)).connect(self.__left_iii_middle)
        self.__left_iii_metacarpal = Link("Left III Metacarpal", Matrix(y=_III_LENGTH * _METACARPAL_RATIO)).connect(self.__left_iii_proximal)

        # Left IV phalangeal and metacarpal
        self.__left_iv_distal = Link("Left IV Distal", Matrix(y=_IV_LENGTH * _DISTAL_RATIO))
        self.__left_iv_middle = Link("Left IV Middle", Matrix(y=_IV_LENGTH * _MIDDLE_RATIO)).connect(self.__left_iv_distal)
        self.__left_iv_proximal = Link("Left IV Proximal", Matrix(y=_IV_LENGTH * _PROXIMAL_RATIO)).connect(self.__left_iv_middle)
        self.__left_iv_metacarpal = Link("Left IV Metacarpal", Matrix(y=_IV_LENGTH * _METACARPAL_RATIO)).connect(self.__left_iv_proximal)

        # Left V phalangeal and metacarpal
        self.__left_v_distal = Link("Left V Distal", Matrix(y=_V_LENGTH * _DISTAL_RATIO))
        self.__left_v_middle = Link("Left V Middle", Matrix(y=_V_LENGTH * _MIDDLE_RATIO)).connect(self.__left_v_distal)
        self.__left_v_proximal = Link("Left V Proximal", Matrix(y=_V_LENGTH * _PROXIMAL_RATIO)).connect(self.__left_v_middle)
        self.__left_v_metacarpal = Link("Left V Metacarpal", Matrix(y=_V_LENGTH * _METACARPAL_RATIO)).connect(self.__left_v_proximal)

        # Left carpus
        self.__left_carpus = Link("Left Carpus", Matrix(y=_CARPUS_LENGTH))
        self.__left_carpus.connect(self.__left_i_metacarpal, Matrix(x=_CARPUS_WIDTH * 0.5, rot_z=-45))
        self.__left_carpus.connect(self.__left_ii_metacarpal, Matrix(x=_CARPUS_WIDTH * 0.25))
        self.__left_carpus.connect(self.__left_iii_metacarpal)
        self.__left_carpus.connect(self.__left_iv_metacarpal, Matrix(x=_CARPUS_WIDTH * -0.25))
        self.__left_carpus.connect(self.__left_v_metacarpal, Matrix(x=_CARPUS_WIDTH * -0.5))

        # Right I phalangeal and metacarpal
        self.__right_i_distal = Link("Right I Distal", Matrix(y=-_I_LENGTH * (_MIDDLE_RATIO + _DISTAL_RATIO)))
        self.__right_i_proximal = Link("Right I Proximal", Matrix(y=-_I_LENGTH * _PROXIMAL_RATIO)).connect(self.__right_i_distal)
        self.__right_i_metacarpal = Link("Right I Metacarpal", Matrix(y=-_I_LENGTH * _METACARPAL_RATIO)).connect(self.__right_i_proximal)

        # Right II phalangeal and metacarpal
        self.__right_ii_distal = Link("Right II Distal", Matrix(y=-_II_LENGTH * _DISTAL_RATIO))
        self.__right_ii_middle = Link("Right II Middle", Matrix(y=-_II_LENGTH * _MIDDLE_RATIO)).connect(self.__right_ii_distal)
        self.__right_ii_proximal = Link("Right II Proximal", Matrix(y=-_II_LENGTH * _PROXIMAL_RATIO)).connect(self.__right_ii_middle)
        self.__right_ii_metacarpal = Link("Right II Metacarpal", Matrix(y=-_II_LENGTH * _METACARPAL_RATIO)).connect(self.__right_ii_proximal)

        # Right III phalangeal and metacarpal
        self.__right_iii_distal = Link("Right III Distal", Matrix(y=-_III_LENGTH * _DISTAL_RATIO))
        self.__right_iii_middle = Link("Right III Middle", Matrix(y=-_III_LENGTH * _MIDDLE_RATIO)).connect(self.__right_iii_distal)
        self.__right_iii_proximal = Link("Right III Proximal", Matrix(y=-_III_LENGTH * _PROXIMAL_RATIO)).connect(self.__right_iii_middle)
        self.__right_iii_metacarpal = Link("Right III Metacarpal", Matrix(y=-_III_LENGTH * _METACARPAL_RATIO)).connect(self.__right_iii_proximal)

        # Right IV phalangeal and metacarpal
        self.__right_iv_distal = Link("Right IV Distal", Matrix(y=-_IV_LENGTH * _DISTAL_RATIO))
        self.__right_iv_middle = Link("Right IV Middle", Matrix(y=-_IV_LENGTH * _MIDDLE_RATIO)).connect(self.__right_iv_distal)
        self.__right_iv_proximal = Link("Right IV Proximal", Matrix(y=-_IV_LENGTH * _PROXIMAL_RATIO)).connect(self.__right_iv_middle)
        self.__right_iv_metacarpal = Link("Right IV Metacarpal", Matrix(y=-_IV_LENGTH * _METACARPAL_RATIO)).connect(self.__right_iv_proximal)

        # Right V phalangeal and metacarpal
        self.__right_v_distal = Link("Right V Distal", Matrix(y=-_V_LENGTH * _DISTAL_RATIO))
        self.__right_v_middle = Link("Right V Middle", Matrix(y=-_V_LENGTH * _MIDDLE_RATIO)).connect(self.__right_v_distal)
        self.__right_v_proximal = Link("Right V Proximal", Matrix(y=-_V_LENGTH * _PROXIMAL_RATIO)).connect(self.__right_v_middle)
        self.__right_v_metacarpal = Link("Right V Metacarpal", Matrix(y=-_V_LENGTH * _METACARPAL_RATIO)).connect(self.__right_v_proximal)

        # Right carpus
        self.__right_carpus = Link("Right Carpus", Matrix(y=-_CARPUS_LENGTH))
        self.__right_carpus.connect(self.__right_i_metacarpal, Matrix(x=_CARPUS_WIDTH * 0.5, rot_z=45))
        self.__right_carpus.connect(self.__right_ii_metacarpal, Matrix(x=_CARPUS_WIDTH * 0.25))
        self.__right_carpus.connect(self.__right_iii_metacarpal)
        self.__right_carpus.connect(self.__right_iv_metacarpal, Matrix(x=_CARPUS_WIDTH * -0.25))
        self.__right_carpus.connect(self.__right_v_metacarpal, Matrix(x=_CARPUS_WIDTH * -0.5))

        # Joints
        self.__joints = {
            # Head
            "Head": Joint(self.__head, Matrix.align_nz_nx_py()),
            "Neck": Joint(self.__neck, Matrix.align_nz_nx_py()),
            # Left arm
            "Left Wrist": Joint(self.__left_hand, Matrix.align_py_pz_px()),
            "Left Elbow": Joint(self.__left_forearm, Matrix.align_py_px_nz()),
            "Left Shoulder": Joint(self.__left_upper_arm, Matrix.align_px_ny_nz()),
            "Left Clavicle": Joint(self.__left_shoulder, Matrix.align_px_ny_nz()),
            # Right arm
            "Right Wrist": Joint(self.__right_hand, Matrix.align_py_nz_nx()),
            "Right Elbow": Joint(self.__right_forearm, Matrix.align_py_nx_pz()),
            "Right Shoulder": Joint(self.__right_upper_arm, Matrix.align_nx_ny_pz()),
            "Right Clavicle": Joint(self.__right_shoulder, Matrix.align_nx_ny_pz()),
            # Torso
            "Upper Torso": Joint(self.__upper_torso, Matrix.align_nz_nx_py()),
            "Lower Torso": Joint(self.__lower_torso, Matrix.align_nz_nx_py()),
            "Upper Lumbar": Joint(self.__upper_lumbar, Matrix.align_nz_nx_py()),
            "Lower Lumbar": Joint(self.__lower_lumbar, Matrix.align_nz_nx_py()),
            # Left leg
            "Left Toe": Joint(self.__left_toe, Matrix.align_px_nz_py()),
            "Left Ankle": Joint(self.__left_foot, Matrix.align_nz_px_ny()),
            "Left Knee": Joint(self.__left_lower_leg, Matrix.align_nz_nx_py()),
            "Left Hip": Joint(self.__left_upper_leg, Matrix.align_nz_px_ny()),
            # Right leg
            "Right Toe": Joint(self.__right_toe, Matrix.align_nx_pz_py()),
            "Right Ankle": Joint(self.__right_foot, Matrix.align_pz_nx_ny()),
            "Right Knee": Joint(self.__right_lower_leg, Matrix.align_pz_px_py()),
            "Right Hip": Joint(self.__right_upper_leg, Matrix.align_pz_nx_ny()),
            # Pelvis
            "Pelvis": Joint(self.__pelvis, Matrix.align_py_nx_pz()),
            # Wheelchair
            "Left Wheel": Joint(self.__left_wheel, Matrix.align_py_nx_pz()),
            "Right Wheel": Joint(self.__right_wheel, Matrix.align_py_px_nz()),
            "Seat": Joint(self.__seat, Matrix.align_py_nx_pz()),
            # Left hand
            "Left I Distal": Joint(self.__left_i_distal, Matrix.align_py_nz_nx()),
            "Left I Proximal": Joint(self.__left_i_proximal, Matrix.align_py_nz_nx()),
            "Left I Metacarpal": Joint(self.__left_i_metacarpal, Matrix.align_py_nz_nx()),
            "Left II Distal": Joint(self.__left_ii_distal, Matrix.align_py_nz_nx()),
            "Left II Middle": Joint(self.__left_ii_middle, Matrix.align_py_nz_nx()),
            "Left II Proximal": Joint(self.__left_ii_proximal, Matrix.align_py_nz_nx()),
            "Left II Metacarpal": Joint(self.__left_ii_metacarpal, Matrix.align_py_nz_nx()),
            "Left III Distal": Joint(self.__left_iii_distal, Matrix.align_py_nz_nx()),
            "Left III Middle": Joint(self.__left_iii_middle, Matrix.align_py_nz_nx()),
            "Left III Proximal": Joint(self.__left_iii_proximal, Matrix.align_py_nz_nx()),
            "Left III Metacarpal": Joint(self.__left_iii_metacarpal, Matrix.align_py_nz_nx()),
            "Left IV Distal": Joint(self.__left_iv_distal, Matrix.align_py_nz_nx()),
            "Left IV Middle": Joint(self.__left_iv_middle, Matrix.align_py_nz_nx()),
            "Left IV Proximal": Joint(self.__left_iv_proximal, Matrix.align_py_nz_nx()),
            "Left IV Metacarpal": Joint(self.__left_iv_metacarpal, Matrix.align_py_nz_nx()),
            "Left V Distal": Joint(self.__left_v_distal, Matrix.align_py_nz_nx()),
            "Left V Middle": Joint(self.__left_v_middle, Matrix.align_py_nz_nx()),
            "Left V Proximal": Joint(self.__left_v_proximal, Matrix.align_py_nz_nx()),
            "Left V Metacarpal": Joint(self.__left_v_metacarpal, Matrix.align_py_nz_nx()),
            "Left Carpus": Joint(self.__left_carpus, Matrix.align_py_pz_px()),
            # Right hand
            "Right I Distal": Joint(self.__right_i_distal, Matrix.align_py_pz_px()),
            "Right I Proximal": Joint(self.__right_i_proximal, Matrix.align_py_pz_px()),
            "Right I Metacarpal": Joint(self.__right_i_metacarpal, Matrix.align_py_pz_px()),
            "Right II Distal": Joint(self.__right_ii_distal, Matrix.align_py_pz_px()),
            "Right II Middle": Joint(self.__right_ii_middle, Matrix.align_py_pz_px()),
            "Right II Proximal": Joint(self.__right_ii_proximal, Matrix.align_py_pz_px()),
            "Right II Metacarpal": Joint(self.__right_ii_metacarpal, Matrix.align_py_pz_px()),
            "Right III Distal": Joint(self.__right_iii_distal, Matrix.align_py_pz_px()),
            "Right III Middle": Joint(self.__right_iii_middle, Matrix.align_py_pz_px()),
            "Right III Proximal": Joint(self.__right_iii_proximal, Matrix.align_py_pz_px()),
            "Right III Metacarpal": Joint(self.__right_iii_metacarpal, Matrix.align_py_pz_px()),
            "Right IV Distal": Joint(self.__right_iv_distal, Matrix.align_py_pz_px()),
            "Right IV Middle": Joint(self.__right_iv_middle, Matrix.align_py_pz_px()),
            "Right IV Proximal": Joint(self.__right_iv_proximal, Matrix.align_py_pz_px()),
            "Right IV Metacarpal": Joint(self.__right_iv_metacarpal, Matrix.align_py_pz_px()),
            "Right V Distal": Joint(self.__right_v_distal, Matrix.align_py_pz_px()),
            "Right V Middle": Joint(self.__right_v_middle, Matrix.align_py_pz_px()),
            "Right V Proximal": Joint(self.__right_v_proximal, Matrix.align_py_pz_px()),
            "Right V Metacarpal": Joint(self.__right_v_metacarpal, Matrix.align_py_pz_px()),
            "Right Carpus": Joint(self.__right_carpus, Matrix.align_py_nz_nx()),
        }

    def __remove_unused_joints(self, root: Link) -> None:
        links = [link.name for link in root.flatten()]

        self.__joints = {n: j for n, j in self.__joints.items() if j.link.name in links}

    def upper_body(self) -> Model:
        self.__left_forearm.connect(self.__left_hand)
        self.__right_forearm.connect(self.__right_hand)

        root = self.__upper_torso

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def lower_body(self) -> Model:
        root = self.__pelvis

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def body(self) -> Model:
        self.__left_forearm.connect(self.__left_hand)
        self.__right_forearm.connect(self.__right_hand)

        self.__lower_torso.connect(self.__upper_torso)

        self.__pelvis.connect(self.__lower_lumbar)

        root = self.__pelvis

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def wheelchair(self) -> Model:
        root = self.__seat

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def body_with_wheelchair(self) -> Model:
        self.__left_forearm.connect(self.__left_hand)
        self.__right_forearm.connect(self.__right_hand)

        self.__lower_torso.connect(self.__upper_torso)

        self.__pelvis.connect(self.__lower_lumbar)

        self.__seat.connect(self.__pelvis)

        root = self.__pelvis

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def left_hand(self) -> Model:
        root = self.__left_carpus

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def right_hand(self) -> Model:
        root = self.__right_carpus

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def upper_body_with_hands(self) -> Model:
        root = self.__upper_torso

        self.__left_forearm.connect(self.__left_carpus)
        self.__right_forearm.connect(self.__right_carpus)

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def body_with_hands(self) -> Model:
        self.__left_forearm.connect(self.__left_carpus)
        self.__right_forearm.connect(self.__right_carpus)

        self.__lower_torso.connect(self.__upper_torso)

        self.__pelvis.connect(self.__lower_lumbar)

        root = self.__pelvis

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)

    def body_with_wheelchair_and_hands(self) -> Model:
        self.__left_forearm.connect(self.__left_carpus)
        self.__right_forearm.connect(self.__right_carpus)

        self.__lower_torso.connect(self.__upper_torso)

        self.__pelvis.connect(self.__lower_lumbar)

        self.__seat.connect(self.__pelvis)

        root = self.__pelvis

        self.__remove_unused_joints(root)

        return Model(root, self.__joints)
