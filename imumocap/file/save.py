import json

from ..joint import Joint
from ..link import Link
from ..matrix import Matrix


def save_model(path: str, root: Link, joints: dict[str, Joint] | None = None) -> None:
    key_values = [
        f'"root": {_link(root)}',
        None if joints is None else f'"joints": {_joints(joints)}',
        None if joints is None else f'"pose": {_pose(joints)}',
    ]

    raw_json = f"{{ {', '.join([k for k in key_values if k])} }}"

    with open(path, "w") as file:
        file.write(_format_json(raw_json))


def save_pose(path: str, joints: dict[str, Joint]) -> None:
    raw_json = f'{{ "pose": {_pose(joints)} }}'

    with open(path, "w") as file:
        file.write(_format_json(raw_json))


def _link(link: Link) -> str:
    links = ", ".join([f"[ {_link(l)}, {_matrix(m)} ]" for l, m in link.links])

    key_values = [
        f'"name": "{link.name}"',
        f'"end": {_matrix(link.end)}',
        None if link.wheel_axis is None else f'"wheel_axis": {_matrix(link.wheel_axis)}',
        f'"links": [ {links} ]',
    ]

    return "{ " + ", ".join([k for k in key_values if k]) + " }"


def _matrix(matrix: Matrix) -> str:
    return (
        "[ "
        + ", ".join(
            (
                f"[{_number(matrix[0, 0])}, {_number(matrix[0, 1])}, {_number(matrix[0, 2])}, {_number(matrix[0, 3])}]",
                f"[{_number(matrix[1, 0])}, {_number(matrix[1, 1])}, {_number(matrix[1, 2])}, {_number(matrix[1, 3])}]",
                f"[{_number(matrix[2, 0])}, {_number(matrix[2, 1])}, {_number(matrix[2, 2])}, {_number(matrix[2, 3])}]",
                f"[{_number(matrix[3, 0])}, {_number(matrix[3, 1])}, {_number(matrix[3, 2])}, {_number(matrix[3, 3])}]",
            )
        )
        + " ]"
    )


def _joints(joints: dict[str, Joint]) -> str:
    return "{ " + ", ".join([f'"{n}": {_joint(j)}' for n, j in joints.items()]) + " }"


def _joint(joint: Joint) -> str:
    key_values = [
        f'"link": "{joint.link.name}"',
        f'"alignment": {_matrix(joint.alignment)}',
        f'"bend_limit": {_limit(joint.bend_limit)}',
        f'"tilt_limit": {_limit(joint.tilt_limit)}',
        f'"twist_limit": {_limit(joint.twist_limit)}',
    ]

    return "{ " + ", ".join([k for k in key_values]) + " }"


def _limit(limit: tuple[float, float] | None) -> str:
    return "null" if limit is None else f"[ {_number(limit[0])}, {_number(limit[1])} ]"


def _pose(joints: dict[str, Joint]) -> str:
    return "{ " + ", ".join([f'"{n}": {_angles(j)}' for n, j in joints.items()]) + " }"


def _angles(joint: Joint) -> str:
    bend, tilt, twist = joint.get()

    return f'{{ "bend": {_number(bend)}, "tilt": {_number(tilt)}, "twist": {_number(twist)} }}'


def _number(value: float, precision: int = 9) -> str:
    string = f"{value:.{precision}f}".rstrip("0").rstrip(".")

    return "0" if string == "-0" else string


def _format_json(raw_json: str) -> str:
    return json.dumps(json.loads(raw_json), indent=4, ensure_ascii=False)
