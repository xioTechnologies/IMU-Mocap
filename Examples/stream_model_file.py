import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
from imumocap.solvers import Mounting

import hardware

# Load model
model = imumocap.file.load_model("stream_model_file.json")

calibration_pose = model.get_pose()

# Connect to and configure IMUs
suit = hardware.Ximu3s(model)

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if suit.get_button_pressed():
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(model, suit.get_imus(), calibration_pose, Mounting.Z_FORWARD)

        viewer.send_text("Calibrated", 2)

    model.set_pose_from_imus(suit.get_imus(), -calibrated_heading)

    imumocap.solvers.translate(model, [0, 0, 0.5])

    viewer.send_frame(imumocap.viewer.model_to_primitives(model, mirror="Left"))
