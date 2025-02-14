from typing import Optional, Tuple

from .link import Link
from .matrix import Matrix

# An interface to get and set Link joint matrix rotations as the three
# angles: bend, tilt, and twist. Bend and twist angles may be between
# +/-180 degrees, tilt angles must not exceed or approach +/-90 degrees.


class Joint:
    def __init__(
        self,
        link: Link,
        alignment: Matrix = Matrix(),
        bend_limit: Optional[Tuple[float, float]] = None,
        tilt_limit: Optional[Tuple[float, float]] = None,
        twist_limit: Optional[Tuple[float, float]] = None,
    ) -> None:
        self.__link = link
        self.__alignment = alignment
        self.__bend_limit = bend_limit
        self.__tilt_limit = tilt_limit
        self.__twist_limit = twist_limit

    @property
    def link(self) -> Link:
        return self.__link

    @property
    def alignment(self) -> Matrix:
        return self.__alignment.copy()

    @property
    def bend_limit(self) -> Optional[Tuple[float, float]]:
        return self.__bend_limit

    @property
    def tilt_limit(self) -> Optional[Tuple[float, float]]:
        return self.__tilt_limit

    @property
    def twist_limit(self) -> Optional[Tuple[float, float]]:
        return self.__twist_limit

    def get(self) -> Tuple[float, float, float]:  # (twist, tilt, bend)
        return (self.__alignment.T * self.__link.joint * self.__alignment).rot_xyz

    def set(self, bend: float = 0, tilt: float = 0, twist: float = 0) -> None:
        self.__link.joint = self.__alignment * Matrix(rot_x=twist, rot_y=tilt, rot_z=bend) * self.__alignment.T
