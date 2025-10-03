import time
import csv

import imumocap
import imumocap.file
import imumocap.viewer
import imumocap.solvers

from imumocap.matrix import Matrix

# Load model
root, joints = imumocap.file.load_model("model.json")

csv_path = "pose_frames.csv"

# Stream to IMU Mocap Viewer
viewer = imumocap.viewer.Connection()

link_names = [link.name for link in root.flatten()]

# Read CSV into memory
with open(csv_path, newline="") as f:
    reader = csv.DictReader(f)
    frames = list(reader)
    
while (True): 
    start_wall = time.perf_counter()
    first_timestamp = float(frames[0]["timestamp"])

    for i, frame in enumerate(frames):
        frame_time = float(frame["timestamp"]) - first_timestamp

        # Sleep until it's time to show this frame
        now = time.perf_counter() - start_wall
        delay = frame_time - now
        if delay > 0:
            time.sleep(delay)

        pose = {}
        for name in link_names:
            try:
                q = [
                    float(frame.get(f"{name}.w", 1)),
                    float(frame.get(f"{name}.x", 0)),
                    float(frame.get(f"{name}.y", 0)),
                    float(frame.get(f"{name}.z", 0)),
                ]
            except ValueError:
                continue

            pose[name] = Matrix(quaternion=q)

        imumocap.set_pose(root, pose)

        imumocap.solvers.translate(root, [0, 0, 0.5])

        # Send to viewer
        viewer.send(
            [
                *imumocap.viewer.link_to_primitives(root),
                *imumocap.viewer.joints_to_primitives(joints, "Left"),
            ]
        )
