import socket
from abc import ABC, abstractmethod
from dataclasses import dataclass

import numpy as np

from .link import Link
from .matrix import Matrix


class Primitive(ABC):
    @abstractmethod
    def __str__(self) -> str:
        pass


@dataclass(frozen=True)
class Line(Primitive):
    start: np.ndarray
    end: np.ndarray

    def __str__(self) -> str:
        return f'{{"type":"line","start":{_xyz(self.start)},"end":{_xyz(self.end)}}}'


@dataclass(frozen=True)
class Circle(Primitive):
    xyz: np.ndarray
    axis: np.ndarray
    radius: float

    def __str__(self) -> str:
        return f'{{"type":"circle","xyz":{_xyz(self.xyz)},"axis":{_xyz(self.axis)},"radius":{_number(self.radius)}}}'


@dataclass(frozen=True)
class Dot(Primitive):
    xyz: np.ndarray
    size: float = 1.0

    def __str__(self) -> str:
        return f'{{"type":"dot","xyz":{_xyz(self.xyz)},"size":{_number(self.size)}}}'


@dataclass(frozen=True)
class Axes(Primitive):
    matrix: Matrix
    scale: float = 1.0

    def __str__(self) -> str:
        return f'{{"type":"axes","xyz":{_xyz(self.matrix.xyz)},"quaternion":{_quaternion(self.matrix.quaternion)},"scale":{_number(self.scale)}}}'


@dataclass(frozen=True)
class Label(Primitive):
    xyz: np.ndarray
    text: str

    def __str__(self) -> str:
        return f'{{"type":"label","xyz":{_xyz(self.xyz)},"text":"{self.text}"}}'


def _number(value: float) -> str:
    string = f"{value:.6f}".rstrip("0").rstrip(".")

    return "0" if string == "-0" else string


def _xyz(xyz: np.ndarray) -> str:
    return f"[{_number(xyz[0])},{_number(xyz[1])},{_number(xyz[2])}]"


def _quaternion(quaternion: np.ndarray) -> str:
    return f"[{_number(quaternion[0])},{_number(quaternion[1])},{_number(quaternion[2])},{_number(quaternion[3])}]"


def link_to_primitives(root: Link) -> list[Primitive]:
    primitives = []

    for link in root.flatten():
        joint = link.get_joint_world()
        end = link.get_end_world()

        primitives.append(Line(joint.xyz, end.xyz))
        primitives.append(Dot(joint.xyz))
        primitives.append(Axes(joint, 0.5 * link.length))

        imu = link.get_imu_world()

        primitives.append(Dot(imu.xyz, 0.5))
        primitives.append(Axes(imu, 0.25 * link.length))
        primitives.append(Label(imu.xyz, link.name))

        for next_link, _ in link.links:
            next_joint = next_link.get_joint_world()

            primitives.append(Line(joint.xyz, next_joint.xyz))
            primitives.append(Line(end.xyz, next_joint.xyz))

        wheel_axis = link.get_wheel_axis_world()

        if wheel_axis:
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

    def send(self, primitives: list[Primitive]) -> None:
        json = "[" + ",".join([str(p) for p in primitives]) + "]"

        data = json.encode("ascii")

        if len(data) > self.__buffer_size:
            raise ValueError(f"The data size is {len(data)}, which exceeds the buffer size of {self.__buffer_size}.")

        self.__socket.sendto(data, self.__address)
