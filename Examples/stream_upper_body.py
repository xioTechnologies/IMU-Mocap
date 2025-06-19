import time

import hardware
import imumocap
import imumocap.solvers
import models

# Load example model
model = models.UpperBody()

# Connect to and configure IMUs
ignored = [
    model.neck.name,
    model.left_shoulder.name,
    model.right_shoulder.name,
]  # there are no IMUs on these parts of the body

imus = hardware.setup([l.name for l in model.root.flatten() if l.name not in ignored])

# Stream to IMU Mocap Viewer
connection = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        print("Please hold the calibration pose")

        time.sleep(2)

        imumocap.solvers.calibrate(model.root, {n: i.matrix for n, i in imus.items()})

        print("Calibrated")

    imumocap.set_pose_from_imus(model.root, {n: i.matrix for n, i in imus.items()})

    imumocap.solvers.interpolate([model.upper_torso, model.neck, model.head])

    connection.send(
        [
            *imumocap.viewer.link_to_primitives(model.root),
            *imumocap.viewer.joints_to_primitives(model.joints, ["Left"]),
        ]
    )
