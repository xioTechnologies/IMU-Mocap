import time

import example_models
import imumocap
import imumocap.solvers
import imumocap.viewer
import ximu3s
from imumocap.solvers import Mounting

# Load model
model = example_models.Body()

# Connect to and configure IMUs
ignored = [
    model.neck.name,
    model.left_hand.name,
    model.left_shoulder.name,
    model.right_hand.name,
    model.right_shoulder.name,
    model.lower_torso.name,
    model.upper_lumbar.name,
    model.lower_lumbar.name,
    model.left_toe.name,
    model.right_toe.name,
]  # there are no IMUs on these parts of the body

imus = ximu3s.setup([l.name for l in model.root.flatten() if l.name not in ignored])

# Stream to IMU Mocap Viewer
viewer_connection = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        print("Please hold the calibration pose")

        time.sleep(2)

        imumocap.solvers.calibrate(model.root, {n: i.matrix for n, i in imus.items()}, mounting=Mounting.Z_BACKWARDS)

        print("Calibrated")

    imumocap.set_pose_from_imus(model.root, {n: i.matrix for n, i in imus.items()})

    imumocap.solvers.interpolate([model.pelvis, model.lower_lumbar, model.upper_lumbar, model.lower_torso, model.upper_torso])
    imumocap.solvers.interpolate([model.upper_torso, model.neck, model.head])

    imumocap.solvers.floor(model.root)

    viewer_connection.send(
        [
            *imumocap.viewer.link_to_primitives(model.root),
            *imumocap.viewer.joints_to_primitives(model.joints, "Left"),
        ]
    )
