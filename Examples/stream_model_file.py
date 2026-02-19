import time

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
from imumocap.solvers import Mounting

import ximu3s

# Load model
root, joints = imumocap.file.load_model("model.json")

model = imumocap.Model(root, joints)

calibration_pose = model.get_pose()

# Connect to and configure IMUs
imus = ximu3s.setup([links.name for links in root.flatten() if links.name])

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

calibrated_heading = 0

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        viewer.send_text("Please Hold the Calibration Pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(model.root, {n: i.matrix for n, i in imus.items()}, calibration_pose, Mounting.Z_FORWARD)

        viewer.send_text("Calibrated", 2)

    model.set_pose_from_imus({n: i.matrix for n, i in imus.items()}, -calibrated_heading)

    imumocap.solvers.translate(model.root, [0, 0, 0.5])

    viewer.send_frame(
        [
            *imumocap.viewer.link_to_primitives(model.root),
            *imumocap.viewer.joints_to_primitives(model.joints, mirror="Left"),
        ]
    )
