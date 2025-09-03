from abc import ABC, abstractmethod
from dataclasses import dataclass

import numpy as np

from ..joint import Joint
from ..link import Link
from ..matrix import Matrix


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
class Angles(Primitive):
    matrix: Matrix
    alpha: float | None = None
    beta: float | None = None
    gamma: float | None = None
    alpha_limit: tuple[float, float] | None = None
    beta_limit: tuple[float, float] | None = None
    gamma_limit: tuple[float, float] | None = None
    scale: float = 1.0
    mirror: bool = False

    def __str__(self) -> str:
        key_values = [
            '"type":"angles"',
            f'"xyz":{_xyz(self.matrix.xyz)}',
            f'"quaternion":{_quaternion(self.matrix.quaternion)}',
            f'"alpha":{_number(self.alpha)}' if self.alpha is not None else None,
            f'"beta":{_number(self.beta)}' if self.beta is not None else None,
            f'"gamma":{_number(self.gamma)}' if self.gamma is not None else None,
            f'"alpha_limit":[{_number(self.alpha_limit[0])},{_number(self.alpha_limit[1])}]' if self.alpha_limit else None,
            f'"beta_limit":[{_number(self.beta_limit[0])},{_number(self.beta_limit[1])}]' if self.beta_limit else None,
            f'"gamma_limit":[{_number(self.gamma_limit[0])},{_number(self.gamma_limit[1])}]' if self.gamma_limit else None,
            f'"scale":{_number(self.scale)}',
            '"mirror":true' if self.mirror else None,
        ]

        return "{" + ",".join([k for k in key_values if k]) + "}"


@dataclass(frozen=True)
class Label(Primitive):
    xyz: np.ndarray
    text: str

    def __str__(self) -> str:
        return f'{{"type":"label","xyz":{_xyz(self.xyz)},"text":"{self.text}"}}'


@dataclass(frozen=True)
class Pedestal(Primitive):
    xyz: np.ndarray

    def __str__(self) -> str:
        return f'{{"type":"pedestal","xyz":{_xyz(self.xyz)}}}'


def _number(value: float) -> str:
    string = f"{value:.6f}".rstrip("0").rstrip(".")

    return "0" if string == "-0" else string


def _xyz(xyz: np.ndarray) -> str:
    return f"[{_number(xyz[0])},{_number(xyz[1])},{_number(xyz[2])}]"


def _quaternion(quaternion: np.ndarray) -> str:
    return f"[{_number(quaternion[0])},{_number(quaternion[1])},{_number(quaternion[2])},{_number(quaternion[3])}]"


def link_to_primitives(root: Link) -> list[Primitive]:
    primitives = [Pedestal(root.get_joint_world().xyz)]

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


def joints_to_primitives(
    joints: dict[str, Joint],
    mirror: str | None = None,  # angles are mirrored if the joint name contains this string
) -> list[Primitive]:
    primitives = []

    for name, joint in joints.items():
        alpha, beta, gamma = joint.get()

        alpha_limit = joint.alpha_limit
        beta_limit = joint.beta_limit
        gamma_limit = joint.gamma_limit

        joint_world = Matrix(xyz=joint.link.get_joint_world().xyz, rotation=joint.link.origin.rotation)

        primitives.append(
            Angles(
                joint_world * joint.alignment,
                gamma=None if gamma_limit == (0, 0) else gamma,
                beta=None if beta_limit == (0, 0) else beta,
                alpha=None if alpha_limit == (0, 0) else alpha,
                gamma_limit=None if gamma_limit == (0, 0) else gamma_limit,
                beta_limit=None if beta_limit == (0, 0) else beta_limit,
                alpha_limit=None if alpha_limit == (0, 0) else alpha_limit,
                scale=joint.link.length / 3,
                mirror=mirror in name if mirror else False,
            )
        )

        primitives.append(Label(joint_world.xyz, name))

    return primitives
