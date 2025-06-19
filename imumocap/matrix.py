from __future__ import annotations

import numpy as np


class Matrix:
    def __init__(
        self,
        matrix: np.ndarray | None = None,
        xyz: np.ndarray | None = None,
        x: float = 0,
        y: float = 0,
        z: float = 0,
        rotation: np.ndarray | None = None,
        quaternion: np.ndarray | None = None,
        axis_angle: tuple[np.ndarray, float] | None = None,
        rot_xyz: np.ndarray | None = None,
        rot_x: float = 0,
        rot_y: float = 0,
        rot_z: float = 0,
    ) -> None:
        if xyz is not None:
            x, y, z = tuple(xyz)

        if rot_xyz is not None:
            rot_x, rot_y, rot_z = tuple(rot_xyz)

        if matrix is not None:
            matrix = np.array(matrix)

            if matrix.shape != (4, 4):
                raise ValueError(f"Matrix shape {matrix.shape} is not (4, 4)")

            self.__matrix = matrix
        elif rotation is not None:
            self.__matrix = np.array(
                [
                    [rotation[0, 0], rotation[0, 1], rotation[0, 2], x],
                    [rotation[1, 0], rotation[1, 1], rotation[1, 2], y],
                    [rotation[2, 0], rotation[2, 1], rotation[2, 2], z],
                    [0, 0, 0, 1],
                ],
                dtype=float,
            )
        elif quaternion is not None:
            # Quaternions and Rotation Sequence by Jack B. Kuipers, ISBN 0-691-10298-8, Page 168

            quaternion = quaternion / np.linalg.norm(quaternion)

            qw = quaternion[0]
            qx = quaternion[1]
            qy = quaternion[2]
            qz = quaternion[3]

            self.__matrix = np.array(
                [
                    [2 * (qw * qw - 0.5 + qx * qx), 2 * (qx * qy - qw * qz), 2 * (qx * qz + qw * qy), x],
                    [2 * (qx * qy + qw * qz), 2 * (qw * qw - 0.5 + qy * qy), 2 * (qy * qz - qw * qx), y],
                    [2 * (qx * qz - qw * qy), 2 * (qy * qz + qw * qx), 2 * (qw * qw - 0.5 + qz * qz), z],
                    [0, 0, 0, 1],
                ],
                dtype=float,
            )
        elif axis_angle is not None:
            # https://www.euclideanspace.com/maths/geometry/rotations/conversions/angleToQuaternion/index.htm

            axis, angle = axis_angle

            axis = axis / np.linalg.norm(axis)
            half_angle = np.radians(angle) / 2

            self.__matrix = Matrix(
                quaternion=[
                    np.cos(half_angle),
                    axis[0] * np.sin(half_angle),
                    axis[1] * np.sin(half_angle),
                    axis[2] * np.sin(half_angle),
                ]
            ).__matrix
        else:
            # rot_x, rot_y, rot_z are ZYX Euler angles
            # Quaternions and Rotation Sequence by Jack B. Kuipers, ISBN 0-691-10298-8, Page 167

            sx = np.sin(np.radians(rot_x))
            cx = np.cos(np.radians(rot_x))

            sy = np.sin(np.radians(rot_y))
            cy = np.cos(np.radians(rot_y))

            sz = np.sin(np.radians(rot_z))
            cz = np.cos(np.radians(rot_z))

            self.__matrix = np.array(
                [
                    [cz * cy, cz * sy * sx - sz * cx, cz * sy * cx + sz * sx, x],
                    [sz * cy, sz * sy * sx + cz * cx, sz * sy * cx - cz * sx, y],
                    [-sy, cy * sx, cy * cx, z],
                    [0, 0, 0, 1],
                ],
                dtype=float,
            )

    @property
    def xyz(self) -> np.ndarray:
        return np.array([self.__matrix[0, 3], self.__matrix[1, 3], self.__matrix[2, 3]])

    @property
    def x(self) -> float:
        return self.__matrix[0, 3]

    @property
    def y(self) -> float:
        return self.__matrix[1, 3]

    @property
    def z(self) -> float:
        return self.__matrix[2, 3]

    @property
    def rotation(self) -> np.ndarray:
        return self.__matrix[0:3, 0:3]

    @property
    def quaternion(self) -> np.ndarray:
        # http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/

        m00 = self.__matrix[0, 0]
        m01 = self.__matrix[0, 1]
        m02 = self.__matrix[0, 2]
        m10 = self.__matrix[1, 0]
        m11 = self.__matrix[1, 1]
        m12 = self.__matrix[1, 2]
        m20 = self.__matrix[2, 0]
        m21 = self.__matrix[2, 1]
        m22 = self.__matrix[2, 2]

        tr = m00 + m11 + m22

        if tr > 0:
            s = np.sqrt(tr + 1) * 2  # s=4*w
            return np.array(
                [
                    0.25 * s,
                    (m21 - m12) / s,
                    (m02 - m20) / s,
                    (m10 - m01) / s,
                ]
            )
        elif m00 > m11 and m00 > m22:
            s = np.sqrt(1 + m00 - m11 - m22) * 2  # s=4*x
            return np.array(
                [
                    (m21 - m12) / s,
                    0.25 * s,
                    (m01 + m10) / s,
                    (m02 + m20) / s,
                ]
            )
        elif m11 > m22:
            s = np.sqrt(1 + m11 - m00 - m22) * 2  # s=4*y
            return np.array(
                [
                    (m02 - m20) / s,
                    (m01 + m10) / s,
                    0.25 * s,
                    (m12 + m21) / s,
                ]
            )
        else:
            s = np.sqrt(1 + m22 - m00 - m11) * 2  # s=4*z
            return np.array(
                [
                    (m10 - m01) / s,
                    (m02 + m20) / s,
                    (m12 + m21) / s,
                    0.25 * s,
                ]
            )

    @property
    def rot_xyz(self) -> tuple[float, float, float]:
        # Quaternions and Rotation Sequence by Jack B. Kuipers, ISBN 0-691-10298-8, Page 168
        # (cross-reference with matrix elements on page 167)

        rot_x = np.degrees(np.arctan2(self.__matrix[2, 1], self.__matrix[2, 2]))

        rot_y = np.degrees(-1 * np.arcsin(np.clip(self.__matrix[2, 0], -1, 1)))

        rot_z = np.degrees(np.arctan2(self.__matrix[1, 0], self.__matrix[0, 0]))

        return rot_x, rot_y, rot_z

    @property
    def T(self) -> Matrix:
        return Matrix(matrix=self.__matrix.T)

    def copy(self) -> Matrix:
        return Matrix(matrix=self.__matrix)

    def __getitem__(self, key):
        return self.__matrix[key]

    def __mul__(self, other: Matrix) -> Matrix:
        return Matrix(matrix=self.__matrix @ other.__matrix)

    def __repr__(self) -> str:
        return str(self.__matrix)

    @staticmethod
    def slerp(m0: Matrix, m1: Matrix, n: int) -> list[Matrix]:
        # https://en.wikipedia.org/wiki/Slerp

        q0 = Matrix(rotation=m0.rotation).quaternion
        q1 = Matrix(rotation=m1.rotation).quaternion

        q_delta = (Matrix(rotation=m0.rotation).T * Matrix(rotation=m1.rotation)).quaternion

        theta = 2 * np.arccos(np.clip(q_delta[0], -1, 1))

        if np.isclose(theta, 0):
            return [
                Matrix(
                    xyz=m0.xyz + t * (m1.xyz - m0.xyz),
                    quaternion=q0,
                )
                for t in np.linspace(0, 1, n)
            ]

        return [
            Matrix(
                xyz=m0.xyz + t * (m1.xyz - m0.xyz),
                quaternion=((np.sin((1 - t) * theta) * q0) + (np.sin(t * theta) * q1)) / np.sin(theta),
            )
            for t in np.linspace(0, 1, n)
        ]

    @staticmethod
    def align_px_py_pz() -> Matrix:
        return Matrix(
            [
                [1, 0, 0, 0],
                [0, 1, 0, 0],
                [0, 0, 1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_px_nz_py() -> Matrix:
        return Matrix(
            [
                [1, 0, 0, 0],
                [0, 0, 1, 0],
                [0, -1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_px_ny_nz() -> Matrix:
        return Matrix(
            [
                [1, 0, 0, 0],
                [0, -1, 0, 0],
                [0, 0, -1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_px_pz_ny() -> Matrix:
        return Matrix(
            [
                [1, 0, 0, 0],
                [0, 0, -1, 0],
                [0, 1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nx_py_nz() -> Matrix:
        return Matrix(
            [
                [-1, 0, 0, 0],
                [0, 1, 0, 0],
                [0, 0, -1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nx_pz_py() -> Matrix:
        return Matrix(
            [
                [-1, 0, 0, 0],
                [0, 0, 1, 0],
                [0, 1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nx_ny_pz() -> Matrix:
        return Matrix(
            [
                [-1, 0, 0, 0],
                [0, -1, 0, 0],
                [0, 0, 1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nx_nz_ny() -> Matrix:
        return Matrix(
            [
                [-1, 0, 0, 0],
                [0, 0, -1, 0],
                [0, -1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_py_nx_pz() -> Matrix:
        return Matrix(
            [
                [0, -1, 0, 0],
                [1, 0, 0, 0],
                [0, 0, 1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_py_nz_nx() -> Matrix:
        return Matrix(
            [
                [0, 0, -1, 0],
                [1, 0, 0, 0],
                [0, -1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_py_px_nz() -> Matrix:
        return Matrix(
            [
                [0, 1, 0, 0],
                [1, 0, 0, 0],
                [0, 0, -1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_py_pz_px() -> Matrix:
        return Matrix(
            [
                [0, 0, 1, 0],
                [1, 0, 0, 0],
                [0, 1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_ny_px_pz() -> Matrix:
        return Matrix(
            [
                [0, 1, 0, 0],
                [-1, 0, 0, 0],
                [0, 0, 1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_ny_nz_px() -> Matrix:
        return Matrix(
            [
                [0, 0, 1, 0],
                [-1, 0, 0, 0],
                [0, -1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_ny_nx_nz() -> Matrix:
        return Matrix(
            [
                [0, -1, 0, 0],
                [-1, 0, 0, 0],
                [0, 0, -1, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_ny_pz_nx() -> Matrix:
        return Matrix(
            [
                [0, 0, -1, 0],
                [-1, 0, 0, 0],
                [0, 1, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_pz_py_nx() -> Matrix:
        return Matrix(
            [
                [0, 0, -1, 0],
                [0, 1, 0, 0],
                [1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_pz_px_py() -> Matrix:
        return Matrix(
            [
                [0, 1, 0, 0],
                [0, 0, 1, 0],
                [1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_pz_ny_px() -> Matrix:
        return Matrix(
            [
                [0, 0, 1, 0],
                [0, -1, 0, 0],
                [1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_pz_nx_ny() -> Matrix:
        return Matrix(
            [
                [0, -1, 0, 0],
                [0, 0, -1, 0],
                [1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nz_py_px() -> Matrix:
        return Matrix(
            [
                [0, 0, 1, 0],
                [0, 1, 0, 0],
                [-1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nz_nx_py() -> Matrix:
        return Matrix(
            [
                [0, -1, 0, 0],
                [0, 0, 1, 0],
                [-1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nz_ny_nx() -> Matrix:
        return Matrix(
            [
                [0, 0, -1, 0],
                [0, -1, 0, 0],
                [-1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )

    @staticmethod
    def align_nz_px_ny() -> Matrix:
        return Matrix(
            [
                [0, 1, 0, 0],
                [0, 0, -1, 0],
                [-1, 0, 0, 0],
                [0, 0, 0, 1],
            ]
        )
