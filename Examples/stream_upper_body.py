import time

import imumocap
import imumocap.solvers
import imumocap.viewer
from imumocap.solvers import Mounting

import models
import ximu3s

# Load model
model = models.Factory().upper_body()

# Connect to and configure IMUs
ignored = [
    "Neck",
    "Left Shoulder",
    "Right Shoulder",
]  # there are no IMUs on these parts of the body

imus = ximu3s.setup([l.name for l in model.links.values() if l.name not in ignored])

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(model, {n: i.matrix for n, i in imus.items()}, mounting=Mounting.Z_FORWARD)

        viewer.send_text("Calibrated", 2)

    model.set_pose_from_imus({n: i.matrix for n, i in imus.items()}, -calibrated_heading)

    imumocap.solvers.interpolate(
        [
            model.links["Upper Torso"],
            model.links["Neck"],
            model.links["Head"],
        ]
    )

    imumocap.solvers.translate(model, [0, 0, 0.5])

    viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))
