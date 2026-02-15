import time

import example_models
import imumocap
import imumocap.solvers
import imumocap.viewer
import ximu3s
from imumocap.solvers import Mounting

# Load model
model = example_models.LowerBody()

# Connect to and configure IMUs
ignored = [
    model.left_toe.name,
    model.right_toe.name,
]  # there are no IMUs on the toes

imus = ximu3s.setup([l.name for l in model.root.flatten() if l.name not in ignored])

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(model.root, {n: i.matrix for n, i in imus.items()}, mounting=Mounting.Z_BACKWARD)

        viewer.send_text("Calibrated", 2)

    imumocap.set_pose_from_imus(model.root, {n: i.matrix for n, i in imus.items()}, -calibrated_heading)

    imumocap.solvers.floor(model.root)

    viewer.send_frame(
        [
            *imumocap.viewer.link_to_primitives(model.root),
            *imumocap.viewer.joints_to_primitives(model.joints, "Left"),
        ]
    )
