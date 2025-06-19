from __future__ import annotations

import matplotlib.pyplot as plt
import numpy as np
from matplotlib import animation

from .link import Link
from .matrix import Matrix
from .pose import set_pose


def plot(
    root: Link,
    frames: list[dict[str, Matrix]] | None = None,  # [{<link name>: <link joint matrix>, ...}, ...]
    fps: float = 30,  # animation frames per second
    file_name: str = "",  # must be .gif
    elev: float | None = None,  # see mpl_toolkits.mplot3d.axes3d.Axes3D.view_init
    azim: float | None = None,  # see mpl_toolkits.mplot3d.axes3d.Axes3D.view_init
    figsize: tuple[float, float] | None = None,  # see matplotlib.pyplot.figure
    dpi: float | None = None,  # see matplotlib.pyplot.figure
    hide_tick_labels: bool = True,  # hides the tick labels
    block: bool | None = None,  # see matplotlib.pyplot.show
) -> None:
    links = root.flatten()

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

    labels = [axes.text(*l.get_imu_world().xyz, l.name, zorder=np.inf) for l in links]

    # Create index text
    if frames is not None:
        index_text = plt.figtext(0.99, 0.01, "", horizontalalignment="right")

    # Show legend
    axes.legend(loc="upper left", frameon=0)

    # Set view
    axes.view_init(elev=elev, azim=azim)

    # Update plot
    def update(index: int | None = None) -> None:
        # Set pose
        if index is not None:
            set_pose(root, frames[index])

        # Set link quivers
        joints = np.array([l.get_joint_world() for l in links])
        ends = np.array([l.get_end_world() for l in links])

        link_quiver_segments = [[tuple(j.xyz), tuple(e.xyz)] for j, e in zip(joints, ends)]

        for joint, end, next_links in zip(joints, ends, [l.links for l in links]):
            for next_joint in [n.get_joint_world() for n, _ in next_links]:
                link_quiver_segments.append([tuple(joint.xyz), tuple(next_joint.xyz)])
                link_quiver_segments.append([tuple(end.xyz), tuple(next_joint.xyz)])

        for joint, end, wheel_axis in zip(joints, ends, [l.get_wheel_axis_world() for l in links]):
            if wheel_axis:
                chords = [joint.xyz + (Matrix(axis_angle=(wheel_axis.xyz, a)) * Matrix(xyz=end.xyz - joint.xyz)).xyz for a in np.linspace(0, 360, 36)]

                for start, end in zip(chords, chords[1:]):
                    link_quiver_segments.append([tuple(start), tuple(end)])

        link_quivers.set_segments(link_quiver_segments)

        # Set XYZ quivers
        lengths = [0.5 * l.length for l in links]

        x_quiver_segments = [[tuple(j.xyz), tuple(j.xyz + (l * j.rotation[:, 0]))] for j, l in zip(joints, lengths)]
        y_quiver_segments = [[tuple(j.xyz), tuple(j.xyz + (l * j.rotation[:, 1]))] for j, l in zip(joints, lengths)]
        z_quiver_segments = [[tuple(j.xyz), tuple(j.xyz + (l * j.rotation[:, 2]))] for j, l in zip(joints, lengths)]

        imus = np.array([l.get_imu_world() for l in links])
        lengths = [0.25 * l.length for l in links]

        x_quiver_segments += [[tuple(i.xyz), tuple(i.xyz + (l * i.rotation[:, 0]))] for i, l in zip(imus, lengths)]
        y_quiver_segments += [[tuple(i.xyz), tuple(i.xyz + (l * i.rotation[:, 1]))] for i, l in zip(imus, lengths)]
        z_quiver_segments += [[tuple(i.xyz), tuple(i.xyz + (l * i.rotation[:, 2]))] for i, l in zip(imus, lengths)]

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
