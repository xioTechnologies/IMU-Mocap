import json
from typing import Any

import numpy as np

from ..joint import Joint
from ..link import Link
from ..matrix import Matrix


def load_model(path: str) -> tuple[Link, dict[str, Joint] | None]:
    model = _load_model(path)

    root = _load_link(model["root"])

    joints = _load_joints(model["joints"], root) if "joints" in model else None

    if "pose" in model:
        _load_pose(model["pose"], joints)

    return root, joints


def load_pose(path: str, joints: dict[str, Joint]) -> None:
    model = _load_model(path)

    _load_pose(model["pose"], joints)


def _load_model(path: str) -> dict[str, Any]:
    try:
        with open(path) as file:
            model = json.load(file)
    except Exception as e:
        raise ValueError(f"Unable to load {path}. {e}")

    if not isinstance(model, dict):
        raise ValueError(f"{path} is not a JSON object")

    return model


def _load_link(value: dict[str, Any]) -> Link:
    root = Link(
        value["name"],
        _matrix(value["end"]),
        _matrix(value["wheel_axis"]) if "wheel_axis" in value else None,
    )

    for link, matrix in value["links"]:
        root.connect(_load_link(link), _matrix(matrix))

    return root


def _matrix(value: list) -> Matrix:
    return Matrix(np.array(value))


def _load_joints(value: dict[str, Any], root: Link) -> dict[str, Joint]:
    links = {l.name: l for l in root.flatten()}

    return {
        n: Joint(
            links[j["link"]],
            _matrix(j["alignment"]),
            j["bend_limit"],
            j["tilt_limit"],
            j["twist_limit"],
        )
        for n, j in value.items()
    }


def _load_pose(value: dict[str, Any], joints: dict[str, Joint]) -> None:
    pose = {n: (a["bend"], a["tilt"], a["twist"]) for n, a in value.items()}

    for name, angles in pose.items():
        joints[name].set(*angles)
