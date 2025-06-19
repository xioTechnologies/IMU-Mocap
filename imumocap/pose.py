from .link import Link
from .matrix import Matrix


def get_pose(root: Link) -> dict[str, Matrix]:
    return {l.name: l.joint for l in root.flatten()}


def set_pose(
    root: Link,
    pose: dict[str, Matrix],  # {<link name>: <link joint matrix>, ...}
) -> None:
    links = {l.name: l for l in root.flatten()}

    for name, matrix in pose.items():
        links[name].joint = matrix


def set_pose_from_imus(
    root: Link,
    imus: dict[str, Matrix],  # {<link name>: <IMU measurement>, ...}
) -> None:
    links = {l.name: l for l in root.flatten()}

    for name, matrix in imus.items():
        links[name].set_joint_from_imu_world(matrix)
