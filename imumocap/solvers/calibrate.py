from enum import Enum

from ..link import Link
from ..matrix import Matrix

# Calibrates the alignment of all IMUs by comparing a predefined calibration
# pose with the IMU measurements while the subject replicates the pose.
#
# Mounting describes the orientation of the IMU attached to the root link. If
# mounting is specified then this IMU must be physically aligned so that one of
# its principal axes points precisely forwards or backwards. This axis may be
# inclined (e.g. tilted up or down) but must not have any component pointing
# left or right. If mounting is not specified then the heading of the
# replicated pose must match the heading of the predefined calibration pose.


class Mounting(Enum):
    X_FORWARDS = Matrix.align_px_py_pz()
    X_BACKWARDS = Matrix.align_nx_ny_pz()
    Y_FORWARDS = Matrix.align_py_nx_pz()
    Y_BACKWARDS = Matrix.align_ny_px_pz()
    Z_FORWARDS = Matrix.align_pz_ny_px()
    Z_BACKWARDS = Matrix.align_nz_py_px()


def calibrate(
    root: Link,
    imus: dict[str, Matrix],  # {<link name>: <IMU measurment>, ...}
    pose: dict[str, Matrix] = {},  # {<link name>: <link joint matrix>, ...}
    mounting: Mounting | None = None,
) -> None:
    if not root.is_root:
        raise ValueError(f"{root.name} is not the root")

    links = {l.name: l for l in root.flatten()}

    for link in links.values():
        link.joint = Matrix()

    for name, matrix in pose.items():
        links[name].joint = matrix

    if mounting:
        heading = (imus[root.name] * mounting.value).rot_xyz[2]

        root.joint = Matrix(rotation=(Matrix(rot_z=heading) * root.joint).rotation, xyz=root.joint.xyz)

    for name, matrix in imus.items():
        links[name].set_imu_world(matrix)
