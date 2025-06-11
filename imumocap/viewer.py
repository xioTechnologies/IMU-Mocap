import socket
from abc import ABC, abstractmethod
from dataclasses import dataclass

import numpy as np

from .joint import Joint
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
class Angle(Primitive):
    matrix: Matrix
    angle: float
    limit: tuple[float, float] | None = None
    scale: float = 1.0

    def __str__(self) -> str:
        key_values = [
            '"type":"angle"',
            f'"xyz":{_xyz(self.matrix.xyz)}',
            f'"quaternion":{_quaternion(self.matrix.quaternion)}',
            f'"angle":{_number(self.angle)}',
            f'"limit":[{_number(self.limit[0])},{_number(self.limit[1])}]' if self.limit else None,
            f'"scale":{_number(self.scale)}',
        ]

        return "{" + ",".join([k for k in key_values if k]) + "}"


@dataclass(frozen=True)
class Euler(Primitive):
    matrix: Matrix
    rot_x: float | None = None
    rot_y: float | None = None
    rot_z: float | None = None
    limit_x: tuple[float, float] | None = None
    limit_y: tuple[float, float] | None = None
    limit_z: tuple[float, float] | None = None
    scale: float = 1.0
    flipped: bool = False

    def __str__(self) -> str:
        key_values = [
            '"type":"euler"',
            f'"xyz":{_xyz(self.matrix.xyz)}',
            f'"quaternion":{_quaternion(self.matrix.quaternion)}',
            f'"rot_x":{_number(self.rot_x)}' if self.rot_x is not None else None,
            f'"rot_y":{_number(self.rot_y)}' if self.rot_y is not None else None,
            f'"rot_z":{_number(self.rot_z)}' if self.rot_z is not None else None,
            f'"limit_x":[{_number(self.limit_x[0])},{_number(self.limit_x[1])}]' if self.limit_x else None,
            f'"limit_y":[{_number(self.limit_y[0])},{_number(self.limit_y[1])}]' if self.limit_y else None,
            f'"limit_z":[{_number(self.limit_z[0])},{_number(self.limit_z[1])}]' if self.limit_z else None,
            f'"scale":{_number(self.scale)}',
            '"flipped":true' if self.flipped else None,
        ]

        return "{" + ",".join([k for k in key_values if k]) + "}"


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

        if wheel_axis:
            primitives.append(Circle(joint.xyz, wheel_axis.xyz, link.length))

    return primitives


def joints_to_primitives(joints: dict[str, Joint], labels: bool = True) -> list[Primitive]:
    def conform_arguments(rotation: float, limit: tuple[float, float] | None = None) -> tuple[float | None, tuple[float, float] | None]:
        if rotation is None or (limit and limit[0] == 0 and limit[1] == 0):
            return None, None
        return rotation, limit if limit else None

    primitives = []

    for name, joint in joints.items():
        bend, tilt, twist = joint.get()

        rot_x, limit_x = conform_arguments(twist, joint.twist_limit)
        rot_y, limit_y = conform_arguments(tilt, joint.tilt_limit)
        rot_z, limit_z = conform_arguments(bend, joint.bend_limit)

        joint_global = joint.link.get_joint_global()

        primitives.append(
            Euler(
                joint_global * joint.alignment,
                rot_x=rot_x,
                rot_y=rot_y,
                rot_z=rot_z,
                limit_x=limit_x,
                limit_y=limit_y,
                limit_z=limit_z,
                scale=joint.link.length / 3,
                flipped=joint.flipped,
            )
        )

        if labels:
            primitives.append(Label(joint_global.xyz, name))

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
