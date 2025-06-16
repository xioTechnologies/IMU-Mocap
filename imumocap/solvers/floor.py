import numpy as np

from ..link import Link
from ..matrix import Matrix

# Sets the height of the root so that the lowest part of the model is in
# contact with the floor.


def floor(root: Link) -> None:
    links = root.flatten()

    if not root.is_root:
        raise ValueError(f"{root.name} is not the root")

    joints_z = np.array([l.get_joint_world().z for l in links])

    ends_z = np.array([l.get_end_world().z for l in links])

    wheels_z = np.array([_wheel_lowest_point(l)[2] for l in links if l.get_wheel_axis_world()])

    min_z = np.min(np.concatenate((joints_z, ends_z, wheels_z)))

    root.joint = Matrix(xyz=root.joint.xyz - [0, 0, min_z], rotation=root.joint.rotation)


def _wheel_lowest_point(link: Link) -> np.ndarray:
    axis = link.get_wheel_axis_world().xyz

    lowest_spoke = np.cross(axis, np.cross(axis, np.array([0, 0, 1])))

    if np.isclose(lowest_spoke, 0).all():
        return link.get_joint_world().xyz

    lowest_spoke /= np.linalg.norm(lowest_spoke)

    return link.get_joint_world().xyz + (link.length * lowest_spoke)
