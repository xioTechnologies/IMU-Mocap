from .link import Link
from .matrix import Matrix

# TODO: Copy the comments/documentation from text_joint.py once finalised


class Joint:
    def __init__(
        self,
        link: Link,
        alignment: Matrix = Matrix(),
        bend_limit: tuple[float, float] | None = None,  # (<min>, <max>) or None if unlimited
        tilt_limit: tuple[float, float] | None = None,  # (<min>, <max>) or None if unlimited
        twist_limit: tuple[float, float] | None = None,  # (<min>, <max>) or None if unlimited
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
    def bend_limit(self) -> tuple[float, float] | None:
        return self.__bend_limit

    @property
    def tilt_limit(self) -> tuple[float, float] | None:
        return self.__tilt_limit

    @property
    def twist_limit(self) -> tuple[float, float] | None:
        return self.__twist_limit

    def get(self) -> tuple[float, float, float]:
        twist, tilt, bend = (self.__alignment.T * self.__link.joint * self.__alignment).rot_xyz

        return bend, tilt, twist

    def set(self, bend: float = 0, tilt: float = 0, twist: float = 0) -> None:
        self.__link.joint = self.__alignment * Matrix(rot_x=twist, rot_y=tilt, rot_z=bend) * self.__alignment.T
