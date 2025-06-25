import time

import imumocap
import imumocap.file
import imumocap.solvers
import ximu3s
from imumocap.solvers import Mounting

# Load model
root, joints = imumocap.file.load_model("model.json")

calibration_pose = imumocap.get_pose(root)

# Connect to and configure IMUs
imus = ximu3s.setup([l.name for l in root.flatten() if l.name])

# Stream to IMU Mocap Viewer
viewer_connection = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        print("Please hold the calibration pose")

        time.sleep(2)

        imumocap.solvers.calibrate(root, {n: i.matrix for n, i in imus.items()}, calibration_pose, Mounting.Z_FORWARDS)

        print("Calibrated")

    imumocap.set_pose_from_imus(root, {n: i.matrix for n, i in imus.items()})

    imumocap.solvers.translate(root, [0, 0, 0.5])

    viewer_connection.send(
        [
            *imumocap.viewer.link_to_primitives(root),
            *imumocap.viewer.joints_to_primitives(joints, "Left"),
        ]
    )
