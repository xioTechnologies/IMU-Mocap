from imumocap import Matrix
from imumocap.solvers import Mounting


class SetNorth:
    def __init__(self, mounting: Mounting):
        self.__mounting = mounting
        self.__alignment = Matrix()

    def set(self, root_imu: Matrix):
        heading = (root_imu * self.__mounting.value).rot_xyz[2]

        self.__alignment = Matrix(rot_z=-heading)  # inverse heading

    def apply(
        self,
        imus: dict[str, Matrix],  # {<link name>: <IMU measurement>, ...}
    ) -> dict[str, Matrix]:
        return {n: self.__alignment * m for n, m in imus}
