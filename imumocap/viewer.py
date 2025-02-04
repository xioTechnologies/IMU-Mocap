import socket
from abc import ABC
from typing import List

import numpy as np

from .link import Link
from .matrix import Matrix


class Primitive(ABC):
    def __init__(self) -> None:
        self._json = ""

    def __str__(self) -> str:
        return self._json

    @staticmethod
    def _json_xyz(xyz: np.ndarray) -> str:
        return f'{{"x":{xyz[0]:.6},"y":{xyz[1]:.6},"z":{xyz[2]:.6}}}'

    @staticmethod
    def _json_quaternion(quaternion: np.ndarray) -> str:
        return f'{{"w":{quaternion[0]:.6},"x":{quaternion[1]:.6},"y":{quaternion[2]:.6},"z":{quaternion[3]:.6}}}'


class Line(Primitive):
    def __init__(self, start: np.ndarray, end: np.ndarray) -> None:
        super().__init__()

        self._json = f'{{"type":"line","start":{Primitive._json_xyz(start)},"end":{Primitive._json_xyz(end)}}}'


class Circle(Primitive):
    def __init__(self, xyz: np.ndarray, axis: np.ndarray, radius: float) -> None:
        super().__init__()

        self._json = f'{{"type":"circle","xyz":{Primitive._json_xyz(xyz)},"axis":{Primitive._json_xyz(axis)},"radius":{radius}}}'


class Dot(Primitive):
    def __init__(self, xyz: np.ndarray, size: int = 1) -> None:
        super().__init__()

        self._json = f'{{"type":"dot","xyz":{Primitive._json_xyz(xyz)},"size":{size}}}'


class Axes(Primitive):
    def __init__(self, matrix: Matrix, scale: int = 1) -> None:
        super().__init__()

        xyz = matrix.xyz
        quaternion = matrix.quaternion

        self._json = f'{{"type":"axes","xyz":{Primitive._json_xyz(xyz)},"quaternion":{Primitive._json_quaternion(quaternion)},"scale":{scale}}}'


class Label(Primitive):
    def __init__(self, xyz: np.ndarray, text: str) -> None:
        super().__init__()

        self._json = f'{{"type":"label","xyz":{Primitive._json_xyz(xyz)},"text":"{text}"}}'


def link_to_primitives(root: Link) -> List[Primitive]:
    primitives = []

    for link in root.flatten():
        joint = link.get_joint_global()
        end = link.get_end_global()

        primitives.append(Line(joint.xyz, end.xyz))
        primitives.append(Dot(joint.xyz))
        primitives.append(Axes(joint, 0.5 * link.length))

        imu = link.get_imu_global()

        primitives.append(Dot(imu.xyz, 0.5))
        primitives.append(Axes(imu, 0.25 * link.length))
        primitives.append(Label(imu.xyz, link.name))

        for next_link, _ in link.links:
            next_joint = next_link.get_joint_global()

            primitives.append(Line(joint.xyz, next_joint.xyz))
            primitives.append(Line(end.xyz, next_joint.xyz))

        wheel_axis = link.get_wheel_axis_global()

        if any(wheel_axis.xyz != 0):
            primitives.append(Circle(joint.xyz, wheel_axis.xyz, link.length))

    return primitives


class Connection:
    def __init__(self, ip_address: str = "localhost", port: int = 6000) -> None:
        self.__address = (ip_address, port)

        self.__socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

        self.__socket.setsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF, 65535)

        self.__buffer_size = self.__socket.getsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF)

    def __del__(self) -> None:
        self.__socket.close()

    def send(self, primitives: List[Primitive]) -> None:
        json = "[" + ",".join([str(p) for p in primitives]) + "]"

        data = json.encode("ascii")

        if len(data) > self.__buffer_size:
            raise ValueError(f"The data size is {len(data)}, which exceeds the buffer size of {self.__buffer_size}.")

        self.__socket.sendto(data, self.__address)
