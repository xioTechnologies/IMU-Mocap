from typing import Dict, List, Tuple, Union

import matplotlib.pyplot as plt
import numpy as np
from matplotlib import animation

from .matrix import Matrix


class Link:
    def __init__(self, name, end: Matrix, wheel_axis: Matrix = Matrix()) -> None:
        self.__name = str(name)
        self.__origin = Matrix()  # link origin in global frame
        self.__joint = Matrix()  # joint rotation relative to origin
        self.__end = end  # link end relative to origin
        self.__imu = Matrix(x=end.x / 2, y=end.y / 2, z=end.z / 2)  # IMU relative to origin
        self.__wheel_axis = wheel_axis  # direction defined by wheel_axis.xyz
        self.__links = []  # [(link, matrix), ...] where matrix is the origin of the next link relative to the end of this link
        self.__is_root = True

        if not np.isclose(np.dot(self.__end.xyz, self.__wheel_axis.xyz), 0):
            raise ValueError(f"Invalid values for {name}. Link end {self.__end.xyz} must be orthogonal to wheel_axis {self.__wheel_axis.xyz}.")

    @property
    def name(self) -> str:
        return self.__name

    @property
    def joint(self) -> Matrix:
        return self.__joint.copy()

    @joint.setter
    def joint(self, joint: Matrix) -> None:
        if self.__is_root:
            self.__joint = joint
        else:
            self.__joint = Matrix(x=self.__joint.x, y=self.__joint.y, z=self.__joint.z, rotation=joint.rotation)  # ignore joint.xyz
        self.__update()

    @property
    def imu(self) -> Matrix:
        return self.__imu.copy()

    @imu.setter
    def imu(self, imu: Matrix) -> None:
        self.__imu = Matrix(x=self.__imu.x, y=self.__imu.y, z=self.__imu.z, rotation=imu.rotation)  # ignore imu.xyz

    @property
    def links(self) -> List[Tuple["Link", Matrix]]:
        return self.__links

    @property
    def length(self) -> float:
        return np.linalg.norm(self.__end.xyz)

    def __update(self, origin: Union[None, Matrix] = None) -> None:
        if origin is not None:
            self.__origin = origin

        for link, matrix in self.__links:
            link.__update(self.__origin * self.joint * self.__end * matrix)

    def connect(self, link: "Link", matrix: Matrix = Matrix()) -> "Link":  # matrix is the origin of the next link relative to the end of this link
        link.__is_root = False
        self.__links.append((link, matrix))
        self.__update()
        return self

    def get_joint_global(self) -> Matrix:
        return self.__origin * self.__joint

    def get_end_global(self) -> Matrix:
        return self.__origin * self.__joint * self.__end

    def get_imu_global(self) -> Matrix:
        return self.__origin * self.__joint * self.__imu

    def set_imu_global(self, imu_global: Matrix) -> None:
        self.imu = self.__joint.T * self.__origin.T * imu_global  # transpose can be used instead of inverse because imu.xyz ignored

    def set_joint_from_imu_global(self, imu_global: Matrix) -> None:
        self.joint = self.__origin.T * imu_global * self.__imu.T  # transpose can be used instead of inverse because joint.xyz ignored

    def get_wheel_axis_global(self) -> Matrix:
        return Matrix(rotation=(self.__origin * self.__joint).rotation) * self.__wheel_axis

    def flatten(self) -> List["Link"]:
        links = [self]

        for link, _ in self.__links:
            links = np.concatenate((links, link.flatten()))

        return links

    def dictionary(self) -> Dict[str, "Link"]:
        return {l.name: l for l in self.flatten()}

    def plot(
        self,
        frames: Union[None, Dict[str, Matrix]] = None,  # each frame is a dictionary of joint matrices created by {l.name: l.joint for l in root.flatten()}
        fps: float = 30,  # animation frames per second
        file_name: str = "",  # must be .gif
        elev: Union[None, float] = None,  # see mpl_toolkits.mplot3d.axes3d.Axes3D.view_init
        azim: Union[None, float] = None,  # see mpl_toolkits.mplot3d.axes3d.Axes3D.view_init
        figsize: Union[None, Tuple[float, float]] = None,  # see matplotlib.pyplot.figure
        dpi: Union[None, float] = None,  # see matplotlib.pyplot.figure
        hide_tick_labels: bool = True,  # hides the tick labels
        block: Union[None, bool] = None,  # see matplotlib.pyplot.show
    ) -> None:
        links = self.flatten()

        # Create figure
        figure = plt.figure(figsize=figsize, dpi=dpi)

        axes = plt.axes(projection="3d")

        plt.subplots_adjust(top=0.95, bottom=0, left=0, right=1)

        if hide_tick_labels:
            axes.set_xticklabels([])
            axes.set_yticklabels([])
            axes.set_zticklabels([])

        # Create quivers, markers, and labels
        link_quivers = axes.quiver([], [], [], [], [], [], color="tab:gray", zorder=-np.inf, label="Link")

        x_quivers = axes.quiver([], [], [], [], [], [], color="tab:red", label="X")
        y_quivers = axes.quiver([], [], [], [], [], [], color="tab:green", label="Y")
        z_quivers = axes.quiver([], [], [], [], [], [], color="tab:blue", label="Z")

        (joint_markers,) = axes.plot([], [], [], "ko", markersize=4, zorder=np.inf, label="Joint")

        (imu_markers,) = axes.plot([], [], [], "ko", markersize=2, zorder=np.inf, label="IMU")

        labels = [axes.text(*l.get_imu_global().xyz, l.name, zorder=np.inf) for l in links]

        # Create index text
        if frames is not None:
            index_text = plt.figtext(0.99, 0.01, "", horizontalalignment="right")

        # Show legend
        axes.legend(loc="upper left", frameon=0)

        # Set view
        axes.view_init(elev=elev, azim=azim)

        # Update plot
        def update(index: Union[None, int] = None) -> None:
            # Set joints
            if index is not None:
                for name, joint in frames[index].items():
                    self.dictionary()[name].joint = joint

            # Set link quivers
            joints = np.array([l.get_joint_global() for l in links])
            ends = np.array([l.get_end_global() for l in links])

            link_quiver_segments = [[tuple(j.xyz), tuple(e.xyz)] for j, e in zip(joints, ends)]

            for joint, end, next_links in zip(joints, ends, [l.links for l in links]):
                for next_joint in [n.get_joint_global() for n, _ in next_links]:
                    link_quiver_segments.append([tuple(joint.xyz), tuple(next_joint.xyz)])
                    link_quiver_segments.append([tuple(end.xyz), tuple(next_joint.xyz)])

            for joint, end, wheel_axis in zip(joints, ends, [l.get_wheel_axis_global() for l in links]):
                if any(wheel_axis.xyz != 0):
                    chords = [joint.xyz + (Matrix(axis_angle=(wheel_axis.xyz, a)) * Matrix(xyz=end.xyz - joint.xyz)).xyz for a in np.linspace(0, 360, 36)]

                    for start, end in zip(chords, chords[1:]):
                        link_quiver_segments.append([tuple(start), tuple(end)])

            link_quivers.set_segments(link_quiver_segments)

            # Set XYZ quivers
            lengths = [0.5 * l.length for l in links]

            x_quiver_segments = [[tuple(j.xyz), tuple(j.xyz + (l * j.rotation[:, 0].A1))] for j, l in zip(joints, lengths)]
            y_quiver_segments = [[tuple(j.xyz), tuple(j.xyz + (l * j.rotation[:, 1].A1))] for j, l in zip(joints, lengths)]
            z_quiver_segments = [[tuple(j.xyz), tuple(j.xyz + (l * j.rotation[:, 2].A1))] for j, l in zip(joints, lengths)]

            imus = np.array([l.get_imu_global() for l in links])
            lengths = [0.25 * l.length for l in links]

            x_quiver_segments += [[tuple(i.xyz), tuple(i.xyz + (l * i.rotation[:, 0].A1))] for i, l in zip(imus, lengths)]
            y_quiver_segments += [[tuple(i.xyz), tuple(i.xyz + (l * i.rotation[:, 1].A1))] for i, l in zip(imus, lengths)]
            z_quiver_segments += [[tuple(i.xyz), tuple(i.xyz + (l * i.rotation[:, 2].A1))] for i, l in zip(imus, lengths)]

            x_quivers.set_segments(x_quiver_segments)
            y_quivers.set_segments(y_quiver_segments)
            z_quivers.set_segments(z_quiver_segments)

            # Set markers
            joint_markers.set_data([[j.xyz[0] for j in joints], [j.xyz[1] for j in joints]])
            joint_markers.set_3d_properties([j.xyz[2] for j in joints])

            imu_markers.set_data([[i.xyz[0] for i in imus], [i.xyz[1] for i in imus]])
            imu_markers.set_3d_properties([i.xyz[2] for i in imus])

            # Set labels text positions
            for label, imu in zip(labels, imus):
                label.set_position((imu.xyz[0], imu.xyz[1]))
                label.set_3d_properties(z=imu.xyz[2], zdir=None)

            # Set index text
            if frames is not None:
                index_text.set_text(f"Frame {index} of {len(frames)}")

            # Set limits
            all_xyz = np.concatenate(
                (
                    [l[1] for l in link_quiver_segments],
                    [x[1] for x in x_quiver_segments],
                    [y[1] for y in y_quiver_segments],
                    [z[1] for z in z_quiver_segments],
                )
            )

            axes.set_xlim3d(np.min(all_xyz[:, 0]), np.max(all_xyz[:, 0]))
            axes.set_ylim3d(np.min(all_xyz[:, 1]), np.max(all_xyz[:, 1]))
            axes.set_zlim3d(np.min(all_xyz[:, 2]), np.max(all_xyz[:, 2]))

            axes.set_box_aspect(np.ptp(all_xyz, axis=0))

        # Static plot
        if frames is None:
            update()
            plt.show(block=block)
            return

        # Animation
        anim = animation.FuncAnimation(figure, update, frames=len(frames), interval=1000 / fps, repeat=False, blit=False)

        if file_name:
            anim.save(file_name, writer=animation.PillowWriter(fps), dpi="figure", progress_callback=lambda i, n: print(f"Saving frame {i + 1} of {n}"))
        else:
            plt.show(block=block)  # play animation
