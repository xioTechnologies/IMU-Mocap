import numpy as np

from ..link import Link
from ..matrix import Matrix

# Translates the root link relative to the world.


def translate(root: Link, xyz: np.ndarray) -> None:
    if not root.is_root:
        raise ValueError(f"{root.name} is not the root")

    root.joint = Matrix(xyz=xyz, rotation=root.joint.rotation)
