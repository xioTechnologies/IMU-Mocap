import numpy as np
from scipy.optimize import minimize
from scipy.spatial.transform import Rotation as R

from ..matrix import Matrix
from ..model import Imus, Model

# Compensates for IMU heading drift when magnetometers are unavailable.

type _HeadingTrims = dict[str, Matrix]  # {<link name>: <heading trim>, ...}


class Heading:
    def __init__(self, imus: Imus) -> None:
        self.__trims = {n: Matrix() for n in imus.keys()}

    def zero(self, model: Model, imus_a: Imus, imus_b: Imus) -> None:
        # TODO: exception if rot_y > 80 for any IMU (or root only?)
        # TODO: exception if imus_a.keys() != imus_b.keys()
        # TODO: exception if root.name not in imus_a.keys()

        # TODO: zero all IMUs first (or root only?)

        self.__trims = {n: Matrix(rot_z=Heading.__find_heading(model.root.name, n, imus_a, imus_b)) for n in imus_a.keys()}

    @staticmethod
    def __find_heading(root_name: str, imu_name: str, frame_a: Imus, frame_b: Imus) -> float:
        root_a, root_b = frame_a[root_name], frame_b[root_name]
        link_a, link_b = frame_a[imu_name], frame_b[imu_name]

        return minimize(
            lambda x: np.rad2deg((R.from_matrix((root_a.inverse * Matrix(rot_z=x[0]) * link_a).rotation) * R.from_matrix((root_b.inverse * Matrix(rot_z=x[0]) * link_b).rotation).inv()).magnitude()),
            [0],
        ).x[0]

    def apply(self, imus: Imus) -> Imus:
        return {n: self.__trims[n] * i for n, i in imus.items()}

    def update(self, model: Model, imus: Imus) -> None:
        names = list(self.__trims.keys())

        og_heading_trims = self.__trims

        def objective(x: list[float]) -> float:
            offset_trims: _HeadingTrims = {n: Matrix(rot_z=x_val) for n, x_val in zip(names, x)}

            candidate_trims: _HeadingTrims = {n: offset_trims[n] * og_heading_trims[n] for n in names}  # combine with og_heading _trim

            model.set_pose_from_imus({n: candidate_trims[n] * i for n, i in imus.items()})

            return sum(j.get_error() for j in model.joints.values())

        x0 = [self.__trims[n].rot_xyz[2] for n in names]

        result = minimize(objective, x0)  # valid only when combined with og_heading _trim

        self.__trims = {n: Matrix(rot_z=x) * og_heading_trims[n] for n, x in zip(names, result.x)}
