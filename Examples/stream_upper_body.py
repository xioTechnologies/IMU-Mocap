import time

import imumocap
import imumocap.solvers
import imumocap.viewer
from imumocap.solvers import Mounting

import hardware
import models

# Load model
model = models.Factory().upper_body()

# Connect to and configure IMUs
suit = hardware.Ximu3s(
    model,
    ignored=[
        "Neck",
        "Left Shoulder",
        "Right Shoulder",
    ],  # there are no IMUs on these links
)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if suit.get_button_pressed():
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(model, suit.get_imus(), mounting=Mounting.Z_FORWARD)

        viewer.send_text("Calibrated", 2)

    model.set_pose_from_imus(suit.get_imus(), -calibrated_heading)

    imumocap.solvers.interpolate(
        [
            model.links["Upper Torso"],
            model.links["Neck"],
            model.links["Head"],
        ]
    )

    imumocap.solvers.translate(model, [0, 0, 0.5])

    viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))
