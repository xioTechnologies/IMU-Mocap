from .joint import Joint
from .link import Link
from .matrix import Matrix

type Joints = dict[str, Joint]  # {<joint name>: <Joint>, ...}

type Pose = dict[str, Matrix]  # {<link name>: <link joint matrix>, ...}

type Imus = dict[str, Matrix]  # {<link name>: <IMU measurement>, ...}


class Model:
    def __init__(self, root: Link, joints: Joints | None = None) -> None:
        if not root.is_root:
            raise ValueError(f"{root.name} is not the root")

        self.__root = root
        self.__joints = joints
        self.__links = {l.name: l for l in Model.flatten(self.__root)}

    @property
    def root(self) -> Link:
        return self.__root

    @property
    def joints(self) -> Joints:
        return self.__joints

    @property
    def links(self) -> dict[str, Link]:
        return self.__links

    @staticmethod
    def flatten(parent: Link) -> list[Link]:
        links = [parent]

        for child, _ in parent.links:
            links += Model.flatten(child)

        return links

    def get_pose(self) -> Pose:
        return {n: l.joint for n, l in self.links.items()}

    def set_pose(self, pose: Pose, heading_offset: float = 0) -> None:
        for name, matrix in pose.items():
            self.links[name].joint = matrix

        self.__root.joint = Matrix(xyz=self.__root.joint.xyz, rotation=(Matrix(rot_z=heading_offset) * self.__root.joint).rotation)

    def set_pose_from_imus(self, imus: Imus, heading_offset: float = 0) -> None:
        alignment = Matrix(rot_z=heading_offset)

        for name, matrix in imus.items():
            self.links[name].set_joint_from_imu_world(alignment * matrix)
