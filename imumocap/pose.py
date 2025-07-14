from .link import Link
from .matrix import Matrix


def get_pose(root: Link) -> dict[str, Matrix]:
    return {l.name: l.joint for l in root.flatten()}


def set_pose(
    root: Link,
    pose: dict[str, Matrix],  # {<link name>: <link joint matrix>, ...}
    heading_offset: float = 0.0,
) -> None:
    links = {l.name: l for l in root.flatten()}

    for name, matrix in pose.items():
        links[name].joint = matrix

    root.joint = Matrix(xyz=root.joint.xyz, rotation=(Matrix(rot_z=heading_offset) * root.joint).rotation)


def set_pose_from_imus(
    root: Link,
    imus: dict[str, Matrix],  # {<link name>: <IMU measurement>, ...}
    heading_offset: float = 0.0,
) -> None:
    alignment = Matrix(rot_z=heading_offset)

    links = {l.name: l for l in root.flatten()}

    for name, matrix in imus.items():
        links[name].set_joint_from_imu_world(alignment * matrix)
