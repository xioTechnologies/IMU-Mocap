import numpy as np

from ..link import Link
from ..matrix import Matrix

# Sets the height of the root so that the lowest part of the model is in
# contact with the floor.


def floor(root: Link) -> None:
    links = root.flatten()

    joints_z = np.array([l.get_joint_global().z for l in links])

    ends_z = np.array([l.get_end_global().z for l in links])

    wheels_z = np.array([_wheel_lowest_point(l)[2] for l in links if any(l.get_wheel_axis_global().xyz != 0)])

    min_z = np.min(np.concatenate((joints_z, ends_z, wheels_z)))

    root.joint = Matrix(x=root.joint.x, y=root.joint.y, z=root.joint.z - min_z, rotation=root.joint.rotation)


def _wheel_lowest_point(link: Link) -> np.ndarray:
    axis = link.get_wheel_axis_global().xyz

    lowest_spoke = np.cross(axis, np.cross(axis, np.array([0, 0, 1])))

    lowest_spoke /= np.linalg.norm(lowest_spoke)

    return link.get_joint_global().xyz + (link.length * lowest_spoke)
