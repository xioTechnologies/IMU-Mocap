from typing import Any

import colorama
import numpy as np
import ximu3
from imumocap import Link, Matrix


class Ximu3s:
    def __init__(self, root: Link, ignored: list[str]) -> None:
        pass

    @property
    def imus(self) -> dict[str, Matrix]:
        pass

    @property
    def button_pressed(self) -> bool:
        pass


class Twintig:
    def __init__(self, root: Link) -> None:
        pass

    @property
    def imus(self) -> dict[str, Matrix]:
        pass
