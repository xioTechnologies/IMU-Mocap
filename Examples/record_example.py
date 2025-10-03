import time
import csv

import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
import ximu3s
from imumocap.solvers import Mounting

# Load model
root, joints = imumocap.file.load_model("model.json")

calibration_pose = imumocap.get_pose(root)

# Connect to and configure IMUs
imus = ximu3s.setup([l.name for l in root.flatten() if l.name])

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

# Prepare CSV writer
fieldnames = [
    "timestamp",
    *[c for link in root.flatten() for c in (f"{link.name}.w", f"{link.name}.x", f"{link.name}.y", f"{link.name}.z")],
]
csv_file = open("pose_frames.csv", "w", newline="")
csv_writer = csv.DictWriter(csv_file, fieldnames=fieldnames)
csv_writer.writeheader()
start_time = time.perf_counter()

calibrated_heading = 0
calibrated = False

while True:
    time.sleep(1 / 30)  # 30 fps

    if any([i.button_pressed for i in imus.values()]):
        print("Please hold the calibration pose")

        time.sleep(2)

        calibrated_heading = imumocap.solvers.calibrate(root, {n: i.matrix for n, i in imus.items()}, calibration_pose, Mounting.Z_FORWARDS)

        print("Calibrated")

        calibrated = True

    imumocap.set_pose_from_imus(root, {n: i.matrix for n, i in imus.items()}, -calibrated_heading)

    if (calibrated):
        row = {"timestamp": time.perf_counter() - start_time}

        pose = imumocap.get_pose(root)

        for name, link in pose.items():        
            quaternion = link.quaternion
            row[f"{name}.w"] = quaternion[0]
            row[f"{name}.x"] = quaternion[1]
            row[f"{name}.y"] = quaternion[2]
            row[f"{name}.z"] = quaternion[3]                    

        csv_writer.writerow(row)
        csv_file.flush()

    imumocap.solvers.translate(root, [0, 0, 0.5])
    
    viewer.send(
        [
            *imumocap.viewer.link_to_primitives(root),
            *imumocap.viewer.joints_to_primitives(joints, "Left"),
        ]
    )        

