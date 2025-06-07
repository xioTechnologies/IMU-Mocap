import json
from typing import Any

from .joint import Joint
from .link import Link
from .matrix import Matrix


def load_model(path: str) -> tuple[Link, dict[str, Joint] | None, dict[str, Matrix] | None]:
    try:
        with open(path) as file:
            model = json.load(file)
    except Exception as e:
        raise ValueError(f"Unable to load {path}. {e}")

    if not isinstance(model, dict):
        raise ValueError(f"{path} is not a JSON object")

    root = __load_root(model["root"])

    joints = __load_joints(model["joints"]) if "joints" in model else None

    pose = __load_pose(model["pose"], joints) if "pose" in model else None

    return root, joints, pose


def load_calibration(path: str, joints: dict[str, Joint]) -> dict[str, Matrix]:
    return __load_pose(None)


def __load_root(value: dict[str, Any]) -> Link:
    print("----------------------------------------------")
    print(value)
    return None


def __load_joints(value: dict[str, Any]) -> Link:
    print("----------------------------------------------")
    print(value)
    return None


def __load_pose(value: dict[str, Any], joints: dict[str, Joint]) -> dict[str, Matrix]:
    print("----------------------------------------------")
    print(value)
    return None

    pose = {"Foot": (1, 2, 3)}  # from JSON file

    # TODO: error if joint link not found

    cache = {n: j.link.joint for n, j in joints}

    for key, value in pose.items():
        joints[key].set(*value)

    pose = {n: j.link.joint for n, j in joints}

    for key, value in cache.items():
        joints[key].link.joint = value

    return pose
