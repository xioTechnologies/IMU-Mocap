from typing import Tuple

from .link import Link
from .matrix import Matrix

# An interface to get and set Link joint matrix rotations as the three
# angles: bend, tilt, and twist. Bend and twist angles may be between
# +/-180 degrees, tilt angles must not exceed or approach +/-90 degrees.


class Joint:
    def __init__(self, link: Link, alignment: Matrix = Matrix()) -> None:
        self.__link = link
        self.__alignment = alignment

    @property
    def link(self) -> Link:
        return self.__link

    def get(self) -> Tuple[float, float, float]:
        return (self.__alignment.T * self.__link.joint * self.__alignment).rot_xyz

    def set(self, bend: float = 0, tilt: float = 0, twist: float = 0) -> None:
        self.__link.joint = self.__alignment * Matrix(rot_x=twist, rot_y=tilt, rot_z=bend) * self.__alignment.T
