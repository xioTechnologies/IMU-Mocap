from enum import Enum

from ..matrix import Matrix
from ..model import Imus, Model, Pose

# Calibrates the alignment of all IMUs by comparing a predefined calibration
# pose with the IMU measurements while the subject replicates the pose.
#
# If mounting is not specified then the heading of the replicated pose must
# match the heading of the predefined calibration pose. If mounting is
# specified then the replicated pose may have any heading and this function
# will return the measured heading of the pose.
#
# Mounting describes the orientation of the IMU attached to the root link. This
# IMU must be physically aligned so that one of its principal axes points
# precisely forward or backward. This axis may be inclined (e.g. tilted up or
# down) but must not have any component pointing left or right. The forward
# direction of the predefined calibration pose must be aligned with the world X
# axis.


class Mounting(Enum):
    X_FORWARD = Matrix.align_px_py_pz()
    X_BACKWARD = Matrix.align_nx_ny_pz()
    Y_FORWARD = Matrix.align_py_nx_pz()
    Y_BACKWARD = Matrix.align_ny_px_pz()
    Z_FORWARD = Matrix.align_pz_ny_px()
    Z_BACKWARD = Matrix.align_nz_py_px()


def calibrate(
    model: Model,
    imus: Imus,
    pose: Pose | None = None,
    mounting: Mounting | None = None,
) -> float | None:
    for link in model.links.values():
        link.joint = Matrix()

    pose = pose or {}

    for name, matrix in pose.items():
        model.links[name].joint = matrix

    heading = None

    if mounting:
        heading = (imus[model.root.name] * mounting.value).rot_xyz[2]

        model.root.joint = Matrix(rotation=(Matrix(rot_z=heading) * model.root.joint).rotation, xyz=model.root.joint.xyz)

    for name, matrix in imus.items():
        model.links[name].set_imu_world(matrix)

    return heading
