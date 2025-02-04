import time

import hardware
import imumocap.solvers
import models

# Load example model
model = models.LowerBody()

# Connect to and configure IMUs
ignored = [
    model.left_toe.name,
    model.right_toe.name,
]  # there are no IMUs on the toes

imus = hardware.setup([l.name for l in model.root.flatten() if l.name not in ignored])

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()


def calibrate() -> None:
    print("Calibrating in...")

    for countdown in [3, 2, 1]:
        print(countdown)

        time.sleep(0.5)

    imumocap.solvers.calibrate(model.root, {n: i.matrix for n, i in imus.items()})

    print("Calibrated")


while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        calibrate()

    for name, imu in imus.items():
        model.root.dictionary()[name].set_joint_from_imu_global(imu.matrix)

    imumocap.solvers.floor(model.root)

    connection.send(imumocap.viewer.link_to_primitives(model.root))
