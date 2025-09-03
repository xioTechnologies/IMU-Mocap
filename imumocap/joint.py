from .link import Link
from .matrix import Matrix

# An interface to get and set Link joint matrix rotations as the three angles:
# alpha, beta, and gamma. The rotation follows the ZYX Euler sequence: alpha ->
# beta -> gamma. Alpha and gamma angles may range between +/-180 degrees; beta
# angles must not exceed or approach +/-90 degrees.
#
# The alignment of these angles should be chosen to best express the actual
# rotation of a given joint and to ensure that each angle does not exceed its
# permitted range.


class Joint:
    def __init__(
        self,
        link: Link,
        alignment: Matrix = Matrix(),  # if identity then alpha = rot_z, beta = rot_y, gamma = rot_x
        alpha_limit: tuple[float, float] | None = None,  # (<min>, <max>) or None if unlimited
        beta_limit: tuple[float, float] | None = None,  # (<min>, <max>) or None if unlimited
        gamma_limit: tuple[float, float] | None = None,  # (<min>, <max>) or None if unlimited
    ) -> None:
        self.__link = link
        self.__alignment = alignment
        self.__alpha_limit = alpha_limit
        self.__beta_limit = beta_limit
        self.__gamma_limit = gamma_limit

    @property
    def link(self) -> Link:
        return self.__link

    @property
    def alignment(self) -> Matrix:
        return self.__alignment.copy()

    @property
    def alpha_limit(self) -> tuple[float, float] | None:
        return self.__alpha_limit

    @property
    def beta_limit(self) -> tuple[float, float] | None:
        return self.__beta_limit

    @property
    def gamma_limit(self) -> tuple[float, float] | None:
        return self.__gamma_limit

    def get(self) -> tuple[float, float, float]:
        gamma, beta, alpha = (self.__alignment.T * self.__link.joint * self.__alignment).rot_xyz

        return alpha, beta, gamma

    def set(self, alpha: float = 0, beta: float = 0, gamma: float = 0) -> None:
        self.__link.joint = self.__alignment * Matrix(rot_x=gamma, rot_y=beta, rot_z=alpha) * self.__alignment.T
