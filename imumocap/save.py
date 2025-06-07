from .float_to_str import float_to_str
from .joint import Joint
from .link import Link
from .matrix import Matrix


def save_model(path: str, root: Link, joints: dict[str, Joint]) -> None:
    with open(path, "w") as file:
        file.write(f"""\
{{
    "root": {__link(root)},
    "joints": {__joints(joints)},
    "pose": {__pose(joints)}
}}
""")


def save_calibration(path: str, joints: dict[str, Joint]) -> None:
    with open(path, "w") as file:
        file.write(f"""\
{{
{__pose(joints)}
}}
""")


def __link(link: Link) -> str:
    links = ", ".join([f"{__link(l)}, {__matrix(m)}" for l, m in link.links])

    key_values = [
        f'"name": "{link.name}"',
        f'"end": {__matrix(link.end)}',
        [] if link.wheel_axis is None else f'"wheel_axis": {__matrix(link.wheel_axis)}',
        f'"links": [ {links} ]',
    ]

    return "{ " + ", ".join([k for k in key_values]) + " }"


def __matrix(matrix: Matrix) -> str:
    return (
        "[ "
        + ", ".join(
            (
                f"[{float_to_str(matrix[0, 0])}, {float_to_str(matrix[0, 1])}, {float_to_str(matrix[0, 2])}, {float_to_str(matrix[0, 3])}]",
                f"[{float_to_str(matrix[1, 0])}, {float_to_str(matrix[1, 1])}, {float_to_str(matrix[1, 2])}, {float_to_str(matrix[1, 3])}]",
                f"[{float_to_str(matrix[2, 0])}, {float_to_str(matrix[2, 1])}, {float_to_str(matrix[2, 2])}, {float_to_str(matrix[2, 3])}]",
                f"[{float_to_str(matrix[3, 0])}, {float_to_str(matrix[3, 1])}, {float_to_str(matrix[3, 2])}, {float_to_str(matrix[3, 3])}]",
            )
        )
        + " ]"
    )


def __joints(joints: dict[str, Joint]) -> str:
    return "{ " + ", ".join([f'"{n}": {__joint(j)}' for n, j in joints.items()]) + " }"


def __joint(joint: Joint) -> str:
    return '"joint"'  # TODO


def __pose(joints: dict[str, Joint]) -> str:
    return "{ " + ", ".join([f'"{n}": {__angles(j)}' for n, j in joints.items()]) + " }"


def __angles(joint: Joint) -> str:
    bend, tilt, twist = joint.get()

    return f'{{ "bend": {float_to_str(bend)}, "tilt": {float_to_str(tilt)}, "twist": {float_to_str(twist)} }}'
