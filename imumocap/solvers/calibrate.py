from ..link import Link
from ..matrix import Matrix

# Calibrates the alignment of all IMUs by comparing a predefined calibration
# pose with the IMU measurements while the subject recreates the pose.


def calibrate(
    root: Link,
    imus: dict[str, Matrix],  # {<link name>: <IMU measurment>, ...}
    calibraiton_pose: dict[str, Matrix] = {},  # {<link name>: <joint matrix>, ...}
) -> None:
    links = {l.name: l for l in root.flatten()}

    for link in links.values():
        link.joint = Matrix()

    for name, matrix in calibraiton_pose.items():
        links[name].joint = matrix

    for name, matrix in imus.items():
        links[name].set_imu_global(matrix)
