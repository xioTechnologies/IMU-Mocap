from ..link import Link
from ..matrix import Matrix

# Interpolates the joint of each link between the first and last linke of a
# contagious chain.


def interpolate(links: list[Link]) -> None:
    if len(links) < 3:
        raise ValueError(f"The number of links {len(links)} is less than 3.")

    for index, _ in enumerate(links[:-1]):
        if links[index + 1] not in [l for l, _ in links[index].links]:
            raise ValueError(f"The links are not a contiguous chain. {links[index + 1].name} is not connected to {links[index].name}.")

    for link in links[1:-1]:
        link.joint = Matrix()

    matrices = Matrix.slerp(links[0].get_joint_world(), links[-1].get_joint_world(), len(links))

    for link, matrix in zip(links, matrices):
        link.set_joint_world(matrix)
