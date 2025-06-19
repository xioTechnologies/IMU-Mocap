from __future__ import annotations

import numpy as np

from .matrix import Matrix


class Link:
    def __init__(self, name, end: Matrix, wheel_axis: Matrix | None = None) -> None:
        self.__name = str(name)
        self.__origin = Matrix()  # link origin relative to the world (root origin is always coincident with world origin)
        self.__joint = Matrix()  # joint rotation relative to origin
        self.__end = end  # link end relative to origin
        self.__imu = Matrix(xyz=end.xyz / 2)  # IMU relative to origin
        self.__wheel_axis = Matrix(xyz=wheel_axis.xyz) if wheel_axis else None  # direction defined by wheel_axis.xyz
        self.__links = []  # [(link, matrix), ...] where matrix is the origin of the next link relative to the end of this link
        self.__is_root = True

        if wheel_axis and not np.isclose(np.dot(self.__end.xyz, self.__wheel_axis.xyz), 0):
            raise ValueError(f"Invalid values for {name}. Link end {self.__end.xyz} must be orthogonal to wheel_axis {self.__wheel_axis.xyz}.")

    @property
    def name(self) -> str:
        return self.__name

    @property
    def origin(self) -> Matrix:
        return self.__origin.copy()

    @property
    def joint(self) -> Matrix:
        return self.__joint.copy()

    @joint.setter
    def joint(self, joint: Matrix) -> None:
        if self.__is_root:
            self.__joint = joint
        else:
            self.__joint = Matrix(xyz=self.__joint.xyz, rotation=joint.rotation)  # ignore joint.xyz
        self.__update()

    @property
    def end(self) -> Matrix:
        return self.__end.copy()

    @property
    def imu(self) -> Matrix:
        return self.__imu.copy()

    @imu.setter
    def imu(self, imu: Matrix) -> None:
        self.__imu = Matrix(xyz=self.__imu.xyz, rotation=imu.rotation)  # ignore imu.xyz

    @property
    def wheel_axis(self) -> Matrix | None:
        return self.__wheel_axis.copy() if self.__wheel_axis else None

    @property
    def links(self) -> list[tuple[Link, Matrix]]:
        return self.__links

    @property
    def length(self) -> float:
        return np.linalg.norm(self.__end.xyz)

    @property
    def is_root(self) -> bool:
        return self.__is_root

    def __update(self, origin: Matrix | None = None) -> None:
        if origin is not None:
            self.__origin = origin

        for link, matrix in self.__links:
            link.__update(self.__origin * self.joint * self.__end * matrix)

    def connect(self, link: Link, matrix: Matrix = Matrix()) -> Link:  # matrix is the origin of the next link relative to the end of this link
        link.__is_root = False
        self.__links.append((link, matrix))
        self.__update()
        return self

    def get_joint_world(self) -> Matrix:
        return self.__origin * self.__joint

    def set_joint_world(self, joint_world: Matrix) -> None:
        self.joint = self.__origin.T * joint_world  # transpose can be used instead of inverse because joint.xyz ignored

    def get_end_world(self) -> Matrix:
        return self.__origin * self.__joint * self.__end

    def get_imu_world(self) -> Matrix:
        return self.__origin * self.__joint * self.__imu

    def set_imu_world(self, imu_world: Matrix) -> None:
        self.imu = self.__joint.T * self.__origin.T * imu_world  # transpose can be used instead of inverse because imu.xyz ignored

    def set_joint_from_imu_world(self, imu_world: Matrix) -> None:
        self.joint = self.__origin.T * imu_world * self.__imu.T  # transpose can be used instead of inverse because joint.xyz ignored

    def get_wheel_axis_world(self) -> Matrix | None:
        return Matrix(rotation=(self.__origin * self.__joint).rotation) * self.__wheel_axis if self.__wheel_axis else None

    def flatten(self) -> list[Link]:
        links = [self]

        for link, _ in self.__links:
            links += link.flatten()

        return links
