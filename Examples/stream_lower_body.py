import time

import imumocap
import imumocap.solvers
import imumocap.viewer
from imumocap.solvers import Mounting

import hardware
import models

# Load model
model = models.Factory().lower_body()

# Connect to and configure IMUs
suit = hardware.Ximu3s(
    model,
    ignored=[
        "Left Toe",
        "Right Toe",
    ],  # there are no IMUs on the toes
)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if suit.get_button_pressed():
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(model, suit.get_imus(), mounting=Mounting.Z_BACKWARD)

        viewer.send_text("Calibrated", 2)

    model.set_pose_from_imus(suit.get_imus(), -calibrated_heading)

    imumocap.solvers.floor(model)

    viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))
