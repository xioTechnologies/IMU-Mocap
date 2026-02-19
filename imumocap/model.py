from .joint import Joint
from .link import Link
from .matrix import Matrix

type Joints = dict[str, Joint]  # {<joint name>: <Joint>, ...}

type Pose = dict[str, Matrix]  # {<link name>: <link joint matrix>, ...}

type Imus = dict[str, Matrix]  # {<link name>: <IMU measurement>, ...}


class Model:
    def __init__(self, root: Link, joints: Joints | None = None) -> None:
        self.__root = root
        # self.__links = {l.name: l for l in self.__root.flatten()}
        self.__joints = joints

    @property
    def root(self) -> Link:
        return self.__root

    # @property
    # def links(self) -> dict[str, Link]:
    #     return self.__links

    @property
    def joints(self) -> Joints:
        return self.__joints

    def get_pose(self) -> Pose:
        return {l.name: l.joint for l in self.__root.flatten()}

    def set_pose(self, pose: Pose, heading_offset: float = 0) -> None:
        links = {l.name: l for l in self.__root.flatten()}

        for name, matrix in pose.items():
            links[name].joint = matrix

        self.__root.joint = Matrix(xyz=self.__root.joint.xyz, rotation=(Matrix(rot_z=heading_offset) * self.__root.joint).rotation)

    def set_pose_from_imus(self, imus: Imus, heading_offset: float = 0) -> None:
        alignment = Matrix(rot_z=heading_offset)

        links = {l.name: l for l in self.__root.flatten()}

        for name, matrix in imus.items():
            links[name].set_joint_from_imu_world(alignment * matrix)
