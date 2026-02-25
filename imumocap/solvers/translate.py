import numpy as np

from ..matrix import Matrix
from ..model import Model

# Translates the root link relative to the world.


def translate(model: Model, xyz: np.ndarray) -> None:
    model.root.joint = Matrix(xyz=xyz, rotation=model.root.joint.rotation)
