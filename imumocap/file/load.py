import json
from typing import Any

import numpy as np

from ..joint import Joint
from ..link import Link
from ..matrix import Matrix
from ..model import Joints, Model, Pose


def load_model(path: str) -> Model:
    key_values = _load_model(path)

    root = _load_link(key_values["root"])

    joints = _load_joints(key_values["joints"], root) if "joints" in key_values else None

    if "pose" in key_values:
        _load_pose(key_values["pose"], {l.name: l for l in Model.flatten(root)})

    return Model(root, joints)


def load_pose(path: str, model: Model) -> Pose:
    key_values = _load_model(path)

    _load_pose(key_values["pose"], model.links)

    return model.get_pose()


def _load_model(path: str) -> dict[str, Any]:
    try:
        with open(path) as file:
            key_values = json.load(file)

    except Exception as ex:
        raise ValueError(f"Unable to load {path}. {ex}")

    if not isinstance(key_values, dict):
        raise ValueError(f"{path} is not a JSON object")

    return key_values


def _load_link(key_values: dict[str, Any]) -> Link:
    parent = Link(
        key_values["name"],
        _matrix(key_values["end"]),
        _matrix(key_values["wheel_axis"]) if "wheel_axis" in key_values else None,
    )

    for child, matrix in key_values["links"]:
        parent.connect(_load_link(child), _matrix(matrix))

    return parent


def _matrix(array: list) -> Matrix:
    return Matrix(np.array(array))


def _load_joints(key_values: dict[str, Any], root: Link) -> Joints:
    links = {l.name: l for l in Model.flatten(root)}

    return {
        n: Joint(
            links[j["link"]],
            _matrix(j["alignment"]),
            j["alpha_limit"],
            j["beta_limit"],
            j["gamma_limit"],
        )
        for n, j in key_values.items()
    }


def _load_pose(key_values: dict[str, Any], links: dict[str, Link]) -> None:
    pose = {n: _matrix(a) for n, a in key_values.items()}

    for name, matrix in pose.items():
        links[name].joint = matrix
