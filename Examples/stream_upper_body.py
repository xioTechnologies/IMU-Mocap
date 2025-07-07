import time

import example_models
import imumocap
import imumocap.solvers
import imumocap.viewer
import ximu3s
from imumocap.solvers import Mounting

# Load model
model = example_models.UpperBody()

imus = ximu3s.setup(
    [
        model.upper_torso.name,
        model.left_upper_arm.name,
        model.left_forearm.name,
        model.right_upper_arm.name,
        model.right_forearm.name,
    ]
)

# Stream to IMU Mocap Viewer
viewer_connection = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        print("Please hold the calibration pose")

        time.sleep(2)

        imumocap.solvers.calibrate(model.root, {n: i.matrix for n, i in imus.items()}, mounting=Mounting.Z_FORWARDS)

        print("Calibrated")

    imumocap.set_pose_from_imus(model.root, {n: i.matrix for n, i in imus.items()})

    imumocap.solvers.interpolate([model.upper_torso, model.neck, model.head])

    imumocap.solvers.translate(model.root, [0, 0, 0.5])

    viewer_connection.send(
        [
            *imumocap.viewer.link_to_primitives(model.root),
            *imumocap.viewer.joints_to_primitives(model.joints, "Left"),
        ]
    )
