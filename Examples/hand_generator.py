import imumocap.file
from imumocap import Joint, Link, Matrix, Model

# Segment lengths
I_LENGTH = 0.11
II_LENGTH = 0.17
III_LENGTH = 0.18
IV_LENGTH = 0.17
V_LENGTH = 0.14

METACARPAL_RATIO = 0.35
PROXIMAL_RATIO = 0.30
MIDDLE_RATIO = 0.20
DISTAL_RATIO = 0.15

CARPUS_LENGTH = 0.03
CARPUS_WIDTH = 0.08

# Joint limits
PHALANGEAL_ALPHA = None
PHALANGEAL_BETA = (0, 0)
PHALANGEAL_GAMMA = (0, 0)

PROXIMAL_ALPHA = None
PROXIMAL_BETA = (-20, 20)
PROXIMAL_GAMMA = (0, 0)

METACARPAL_ALPHA = (-20, 20)
METACARPAL_BETA = (-20, 20)
METACARPAL_GAMMA = (0, 0)

# Special case for the thumb
I_PROXIMAL_ALPHA = None
I_PROXIMAL_BETA = (-20, 20)
I_PROXIMAL_GAMMA = (0, 0)

I_METACARPAL_ALPHA = (-20, 20)
I_METACARPAL_BETA = (-20, 20)
I_METACARPAL_GAMMA = (0, 0)

finger_alignment = Matrix.align_py_nz_nx()  # finger joints
carpus_alignment = Matrix.align_py_nz_nx()  # carpus joint

right_finger_alignment = Matrix.align_ny_pz_nx()  # finger joints
right_carpus_alignment = Matrix.align_ny_pz_nx()  # carpus joint

def left_hand() -> Model:

    # I (thumb) — no middle phalanx
    i_distal = Link("I Distal IMU", Matrix(y=I_LENGTH * (MIDDLE_RATIO + DISTAL_RATIO)))
    i_proximal = Link("I Proximal IMU", Matrix(y=I_LENGTH * PROXIMAL_RATIO)).connect(i_distal)
    i_metacarpal = Link("I Metacarpal IMU", Matrix(y=I_LENGTH * METACARPAL_RATIO)).connect(i_proximal)

    # II
    ii_distal = Link("II Distal IMU", Matrix(y=II_LENGTH * DISTAL_RATIO))
    ii_middle = Link("II Middle IMU", Matrix(y=II_LENGTH * MIDDLE_RATIO)).connect(ii_distal)
    ii_proximal = Link("II Proximal IMU", Matrix(y=II_LENGTH * PROXIMAL_RATIO)).connect(ii_middle)
    ii_metacarpal = Link("II Metacarpal IMU", Matrix(y=II_LENGTH * METACARPAL_RATIO)).connect(ii_proximal)

    # III
    iii_distal = Link("III Distal IMU", Matrix(y=III_LENGTH * DISTAL_RATIO))
    iii_middle = Link("III Middle IMU", Matrix(y=III_LENGTH * MIDDLE_RATIO)).connect(iii_distal)
    iii_proximal = Link("III Proximal IMU", Matrix(y=III_LENGTH * PROXIMAL_RATIO)).connect(iii_middle)
    iii_metacarpal = Link("III Metacarpal IMU", Matrix(y=III_LENGTH * METACARPAL_RATIO)).connect(iii_proximal)

    # IV
    iv_distal = Link("IV Distal IMU", Matrix(y=IV_LENGTH * DISTAL_RATIO))
    iv_middle = Link("IV Middle IMU", Matrix(y=IV_LENGTH * MIDDLE_RATIO)).connect(iv_distal)
    iv_proximal = Link("IV Proximal IMU", Matrix(y=IV_LENGTH * PROXIMAL_RATIO)).connect(iv_middle)
    iv_metacarpal = Link("IV Metacarpal IMU", Matrix(y=IV_LENGTH * METACARPAL_RATIO)).connect(iv_proximal)

    # V
    v_distal = Link("V Distal IMU", Matrix(y=V_LENGTH * DISTAL_RATIO))
    v_middle = Link("V Middle IMU", Matrix(y=V_LENGTH * MIDDLE_RATIO)).connect(v_distal)
    v_proximal = Link("V Proximal IMU", Matrix(y=V_LENGTH * PROXIMAL_RATIO)).connect(v_middle)
    v_metacarpal = Link("V Metacarpal IMU", Matrix(y=V_LENGTH * METACARPAL_RATIO)).connect(v_proximal)

    # Carpus
    carpus = Link("Carpus IMU", Matrix(y=CARPUS_LENGTH))
    carpus.connect(i_metacarpal, Matrix(x=CARPUS_WIDTH * 0.50))
    carpus.connect(ii_metacarpal, Matrix(x=CARPUS_WIDTH * 0.25))
    carpus.connect(iii_metacarpal, Matrix(x=0))
    carpus.connect(iv_metacarpal, Matrix(x=CARPUS_WIDTH * -0.25))
    carpus.connect(v_metacarpal, Matrix(x=CARPUS_WIDTH * -0.50))

    return Model(
        carpus,
        {
            "Carpus IMU": Joint(carpus, carpus_alignment),
            "I Distal IMU": Joint(
                i_distal,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "I Proximal IMU": Joint(
                i_proximal,
                finger_alignment,
                alpha_limit=I_PROXIMAL_ALPHA,
                beta_limit=I_PROXIMAL_BETA,
                gamma_limit=I_PROXIMAL_GAMMA,
            ),
            "I Metacarpal IMU": Joint(
                i_metacarpal,
                finger_alignment,
                alpha_limit=I_METACARPAL_ALPHA,
                beta_limit=I_METACARPAL_BETA,
                gamma_limit=I_METACARPAL_GAMMA,
            ),
            "II Distal IMU": Joint(
                ii_distal,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "II Middle IMU": Joint(
                ii_middle,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "II Proximal IMU": Joint(
                ii_proximal,
                finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "II Metacarpal IMU": Joint(
                ii_metacarpal,
                finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
            "III Distal IMU": Joint(
                iii_distal,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "III Middle IMU": Joint(
                iii_middle,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "III Proximal IMU": Joint(
                iii_proximal,
                finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "III Metacarpal IMU": Joint(
                iii_metacarpal,
                finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
            "IV Distal IMU": Joint(
                iv_distal,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "IV Middle IMU": Joint(
                iv_middle,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "IV Proximal IMU": Joint(
                iv_proximal,
                finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "IV Metacarpal IMU": Joint(
                iv_metacarpal,
                finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
            "V Distal IMU": Joint(
                v_distal,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "V Middle IMU": Joint(
                v_middle,
                finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "V Proximal IMU": Joint(
                v_proximal,
                finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "V Metacarpal IMU": Joint(
                v_metacarpal,
                finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
        },
    )

def right_hand() -> Model:
    # Head

    # I phalangeal and metacarpal
    i_distal = Link("I Distal IMU", Matrix(y=-I_LENGTH * (MIDDLE_RATIO + DISTAL_RATIO)))
    i_proximal = Link("I Proximal IMU", Matrix(y=-I_LENGTH * PROXIMAL_RATIO)).connect(i_distal)
    i_metacarpal = Link("I Metacarpal IMU", Matrix(y=-I_LENGTH * METACARPAL_RATIO)).connect(i_proximal)

    # II phalangeal and metacarpal
    ii_distal = Link("II Distal IMU", Matrix(y=-II_LENGTH * DISTAL_RATIO))
    ii_middle = Link("II Middle IMU", Matrix(y=-II_LENGTH * MIDDLE_RATIO)).connect(ii_distal)
    ii_proximal = Link("II Proximal IMU", Matrix(y=-II_LENGTH * PROXIMAL_RATIO)).connect(ii_middle)
    ii_metacarpal = Link("II Metacarpal IMU", Matrix(y=-II_LENGTH * METACARPAL_RATIO)).connect(ii_proximal)

    # III phalangeal and metacarpal
    iii_distal = Link("III Distal IMU", Matrix(y=-III_LENGTH * DISTAL_RATIO))
    iii_middle = Link("III Middle IMU", Matrix(y=-III_LENGTH * MIDDLE_RATIO)).connect(iii_distal)
    iii_proximal = Link("III Proximal IMU", Matrix(y=-III_LENGTH * PROXIMAL_RATIO)).connect(iii_middle)
    iii_metacarpal = Link("III Metacarpal IMU", Matrix(y=-III_LENGTH * METACARPAL_RATIO)).connect(iii_proximal)

    # IV phalangeal and metacarpal
    iv_distal = Link("IV Distal IMU", Matrix(y=-IV_LENGTH * DISTAL_RATIO))
    iv_middle = Link("IV Middle IMU", Matrix(y=-IV_LENGTH * MIDDLE_RATIO)).connect(iv_distal)
    iv_proximal = Link("IV Proximal IMU", Matrix(y=-IV_LENGTH * PROXIMAL_RATIO)).connect(iv_middle)
    iv_metacarpal = Link("IV Metacarpal IMU", Matrix(y=-IV_LENGTH * METACARPAL_RATIO)).connect(iv_proximal)

    # V phalangeal and metacarpal
    v_distal = Link("V Distal IMU", Matrix(y=-V_LENGTH * DISTAL_RATIO))
    v_middle = Link("V Middle IMU", Matrix(y=-V_LENGTH * MIDDLE_RATIO)).connect(v_distal)
    v_proximal = Link("V Proximal IMU", Matrix(y=-V_LENGTH * PROXIMAL_RATIO)).connect(v_middle)
    v_metacarpal = Link("V Metacarpal IMU", Matrix(y=-V_LENGTH * METACARPAL_RATIO)).connect(v_proximal)

    # carpus
    carpus = Link("Carpus IMU", Matrix(y=-CARPUS_LENGTH))
    carpus.connect(i_metacarpal, Matrix(x=CARPUS_WIDTH * 0.5, rot_z=45))
    carpus.connect(ii_metacarpal, Matrix(x=CARPUS_WIDTH * 0.25))
    carpus.connect(iii_metacarpal)
    carpus.connect(iv_metacarpal, Matrix(x=CARPUS_WIDTH * -0.25))
    carpus.connect(v_metacarpal, Matrix(x=CARPUS_WIDTH * -0.5))


    return Model(
        carpus,
        {
            "Carpus IMU": Joint(carpus, right_carpus_alignment),
            "I Distal IMU": Joint(
                i_distal,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "I Proximal IMU": Joint(
                i_proximal,
                right_finger_alignment,
                alpha_limit=I_PROXIMAL_ALPHA,
                beta_limit=I_PROXIMAL_BETA,
                gamma_limit=I_PROXIMAL_GAMMA,
            ),
            "I Metacarpal IMU": Joint(
                i_metacarpal,
                right_finger_alignment,
                alpha_limit=I_METACARPAL_ALPHA,
                beta_limit=I_METACARPAL_BETA,
                gamma_limit=I_METACARPAL_GAMMA,
            ),
            "II Distal IMU": Joint(
                ii_distal,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "II Middle IMU": Joint(
                ii_middle,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "II Proximal IMU": Joint(
                ii_proximal,
                right_finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "II Metacarpal IMU": Joint(
                ii_metacarpal,
                right_finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
            "III Distal IMU": Joint(
                iii_distal,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "III Middle IMU": Joint(
                iii_middle,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "III Proximal IMU": Joint(
                iii_proximal,
                right_finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "III Metacarpal IMU": Joint(
                iii_metacarpal,
                right_finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
            "IV Distal IMU": Joint(
                iv_distal,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "IV Middle IMU": Joint(
                iv_middle,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "IV Proximal IMU": Joint(
                iv_proximal,
                right_finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "IV Metacarpal IMU": Joint(
                iv_metacarpal,
                right_finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
            "V Distal IMU": Joint(
                v_distal,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "V Middle IMU": Joint(
                v_middle,
                right_finger_alignment,
                alpha_limit=PHALANGEAL_ALPHA,
                beta_limit=PHALANGEAL_BETA,
                gamma_limit=PHALANGEAL_GAMMA,
            ),
            "V Proximal IMU": Joint(
                v_proximal,
                right_finger_alignment,
                alpha_limit=PROXIMAL_ALPHA,
                beta_limit=PROXIMAL_BETA,
                gamma_limit=PROXIMAL_GAMMA,
            ),
            "V Metacarpal IMU": Joint(
                v_metacarpal,
                right_finger_alignment,
                alpha_limit=METACARPAL_ALPHA,
                beta_limit=METACARPAL_BETA,
                gamma_limit=METACARPAL_GAMMA,
            ),
        },        
    ) 

    return


if __name__ == "__main__":
    imumocap.file.save_model("right_hand_model_new.json", right_hand())
