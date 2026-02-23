import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
import ximu3s
from imumocap.solvers import Mounting

# Load model
root, joints = imumocap.file.load_model("stream_model_file.json")

calibration_pose = imumocap.get_pose(root)

# Connect to and configure IMUs
imus = ximu3s.setup([l.name for l in root.flatten() if l.name])

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(root, {n: i.matrix for n, i in imus.items()}, calibration_pose, Mounting.Z_FORWARD)

        viewer.send_text("Calibrated", 2)

    imumocap.set_pose_from_imus(root, {n: i.matrix for n, i in imus.items()}, -calibrated_heading)

    imumocap.solvers.translate(root, [0, 0, 0.5])

    viewer.send_frame(
        [
            *imumocap.viewer.link_to_primitives(root),
            *imumocap.viewer.joints_to_primitives(joints, mirror="Left"),
        ]
    )
