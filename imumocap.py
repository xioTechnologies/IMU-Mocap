import matplotlib.pyplot as pyplot
import numpy
from matplotlib import animation


class Link:
    def __init__(self, name, length, connections=[]):
        self.__name = name
        self.__origin = Link.matrix()  # origin in global frame
        self.__joint = Link.matrix()  # joint rotation relative to origin
        self.__end = Link.matrix(x=length)  # link end relative to origin
        self.__imu = Link.matrix(x=length / 2)  # IMU relative to origin
        self.__connections = connections  # [(matrix, link), ...] where matrix is the origin of the connecting link relative to the origin of this link
        self.__update()

    @property
    def name(self):
        return self.__name

    @property
    def joint(self):
        return self.__joint

    @joint.setter
    def joint(self, value):
        self.__joint[0:3, 0:3] = value[0:3, 0:3]  # ignore translation
        self.__update()

    @property
    def imu(self):
        return self.__imu

    @imu.setter
    def imu(self, value):
        self.__imu[0:3, 0:3] = value[0:3, 0:3]  # ignore translation
        self.__update()

    def __update(self, origin=None):
        if origin is not None:
            self.__origin = origin

        for link, matrix in self.__connections:
            link.__update(self.__origin * self.joint * matrix)

    def get_joint_global(self):
        return self.__origin * self.__joint

    def get_end_global(self):
        return self.__origin * self.__joint * self.__end

    def get_imu_global(self):
        return self.__origin * self.__joint * self.__imu

    def set_imu_global(self, imu_global):
        self.imu = self.__joint.T * self.__origin.T * imu_global

    def get_connections_global(self):
        return [self.__origin * self.__joint * m for _, m in self.__connections]

    def set_joint_from_imu_global(self, imu_global):
        self.joint = self.__origin.T * imu_global * self.__imu.T

    @staticmethod
    def matrix(x=0, y=0, z=0, roll=0, pitch=0, yaw=0, quaternion=None):
        if quaternion is not None:
            qw = quaternion[0]
            qx = quaternion[1]
            qy = quaternion[2]
            qz = quaternion[3]

            return numpy.matrix([[2 * (qw * qw - 0.5 + qx * qx), 2 * (qx * qy - qw * qz), 2 * (qx * qz + qw * qy), x],
                                 [2 * (qx * qy + qw * qz), 2 * (qw * qw - 0.5 + qy * qy), 2 * (qy * qz - qw * qx), y],
                                 [2 * (qx * qz - qw * qy), 2 * (qy * qz + qw * qx), 2 * (qw * qw - 0.5 + qz * qz), z],
                                 [0, 0, 0, 1]])
        else:
            sr = numpy.sin(numpy.radians(roll))
            cr = numpy.cos(numpy.radians(roll))

            sp = numpy.sin(numpy.radians(pitch))
            cp = numpy.cos(numpy.radians(pitch))

            sy = numpy.sin(numpy.radians(yaw))
            cy = numpy.cos(numpy.radians(yaw))

            return numpy.matrix([[cy * cp, cy * sp * sr - sy * cr, cy * sp * cr + sy * sr, x],
                                [sy * cp, sy * sp * sr + cy * cr, sy * sp * cr - cy * sr, y],
                                [-sp, cp * sr, cp * cr, z],
                                [0, 0, 0, 1]])

    @staticmethod
    def flatten(root):
        links = [root]

        for link, _ in root.__connections:
            links = numpy.concatenate((links, Link.flatten(link)))

        return links


def plot(root,  # root link
         frames=None,  # each frame is an nx4x4 array created by [l.joint.copy() for l in Link.flatten(root)]
         fps=30,  # animation frames per second
         file_name="",  # must be .gif
         elev=None,  # see mpl_toolkits.mplot3d.axes3d.Axes3D.view_init
         azim=None,  # see mpl_toolkits.mplot3d.axes3d.Axes3D.view_init
         figsize=None,  # see matplotlib.pyplot.figure
         dpi=None):  # see matplotlib.pyplot.figure

    links = Link.flatten(root)

    # Create figure
    figure = pyplot.figure(figsize=figsize, dpi=dpi)

    axis = pyplot.axes(projection="3d")

    pyplot.subplots_adjust(top=0.95, bottom=0, left=0, right=1)

    axis.set_xticklabels([])
    axis.set_yticklabels([])
    axis.set_zticklabels([])

    # Create link quivers
    link_quivers = axis.quiver([], [], [], [], [], [], color="tab:gray", zorder=-numpy.inf, label="Link")

    # Create joint quivers and origins
    joint_x_quivers = axis.quiver([], [], [], [], [], [], color="tab:red", label="X")
    joint_y_quivers = axis.quiver([], [], [], [], [], [], color="tab:green", label="Y")
    joint_z_quivers = axis.quiver([], [], [], [], [], [], color="tab:blue", label="Z")

    joint_origins, = axis.plot([], [], [], "ko", markersize=4, zorder=numpy.inf, label="Joint")

    # Create IMU quivers and origins
    imu_standoff_quivers = axis.quiver([], [], [], [], [], [], color="tab:gray", zorder=-numpy.inf)

    imu_x_quivers = axis.quiver([], [], [], [], [], [], color="tab:red")
    imu_y_quivers = axis.quiver([], [], [], [], [], [], color="tab:green")
    imu_z_quivers = axis.quiver([], [], [], [], [], [], color="tab:blue")

    imu_origins, = axis.plot([], [], [], "ko", markersize=2, zorder=numpy.inf, label="IMU")

    # Create labels text
    labels = [axis.text(l.get_imu_global()[0, 3], l.get_imu_global()[1, 3], l.get_imu_global()[2, 3], l.name, zorder=numpy.inf) for l in links]

    # Create frame index text
    if frames is not None:
        frame_index = pyplot.figtext(0.99, 0.01, "", horizontalalignment="right")

    # Show legend
    axis.legend(loc="upper left", frameon=0)

    # Set view
    axis.view_init(elev=elev, azim=azim)

    # Update plot
    def update(index):

        # Set joint rotations
        if index is not None:
            for link, joint in zip(links, frames[index]):
                link.joint = joint

        # Set link quivers
        origin_positions = numpy.array([l.get_joint_global()[:-1, 3].T.A1 for l in links])
        end_positions = numpy.array([l.get_end_global()[:-1, 3].T.A1 for l in links])

        link_quiver_segments = [[(o[0], o[1], o[2]), (e[0], e[1], e[2])] for o, e in zip(origin_positions, end_positions)]

        for origin_position, end_position, connections in zip(origin_positions, end_positions, [l.get_connections_global() for l in links]):
            for connection in connections:
                link_quiver_segments.append([(origin_position[0], origin_position[1], origin_position[2]), (connection[0, 3], connection[1, 3], connection[2, 3])])
                link_quiver_segments.append([(end_position[0], end_position[1], end_position[2]), (connection[0, 3], connection[1, 3], connection[2, 3])])

        link_quivers.set_segments(link_quiver_segments)

        # Set joint quivers and origins
        joint_positions = numpy.array([l.get_joint_global()[:-1, 3].T.A1 for l in links])
        joint_rotations = numpy.array([l.get_joint_global()[0:3, 0:3] for l in links])

        JOINT_QUIVER_LENGTH = 0.4
        joint_x_quiver_segments = [[(p[0], p[1], p[2]), (p[0] + r[0, 0], p[1] + r[1, 0], p[2] + r[2, 0])] for p, r in zip(joint_positions, JOINT_QUIVER_LENGTH * joint_rotations)]
        joint_y_quiver_segments = [[(p[0], p[1], p[2]), (p[0] + r[0, 1], p[1] + r[1, 1], p[2] + r[2, 1])] for p, r in zip(joint_positions, JOINT_QUIVER_LENGTH * joint_rotations)]
        joint_z_quiver_segments = [[(p[0], p[1], p[2]), (p[0] + r[0, 2], p[1] + r[1, 2], p[2] + r[2, 2])] for p, r in zip(joint_positions, JOINT_QUIVER_LENGTH * joint_rotations)]

        joint_x_quivers.set_segments(joint_x_quiver_segments)
        joint_y_quivers.set_segments(joint_y_quiver_segments)
        joint_z_quivers.set_segments(joint_z_quiver_segments)

        joint_origins.set_data(joint_positions[:, :2].T)
        joint_origins.set_3d_properties(joint_positions[:, 2])

        # Set IMU quivers and origins
        IMU_STANDOFF = 0.2
        imu_positions = numpy.array([l.get_imu_global()[:-1, 3].T.A1 for l in links])
        imu_standoffs = numpy.array([(l.get_imu_global() * Link.matrix(z=IMU_STANDOFF))[:-1, 3].T.A1 for l in links])
        imu_rotations = numpy.array([l.get_imu_global()[0:3, 0:3] for l in links])

        imu_standoff_quivers.set_segments([[(p[0], p[1], p[2]), (s[0], s[1], s[2])] for p, s in zip(imu_positions, imu_standoffs)])

        IMU_QUIVER_LENGTH = 0.2
        imu_x_quiver_segments = [[(s[0], s[1], s[2]), (s[0] + r[0, 0], s[1] + r[1, 0], s[2] + r[2, 0])] for s, r in zip(imu_standoffs, IMU_QUIVER_LENGTH * imu_rotations)]
        imu_y_quiver_segments = [[(s[0], s[1], s[2]), (s[0] + r[0, 1], s[1] + r[1, 1], s[2] + r[2, 1])] for s, r in zip(imu_standoffs, IMU_QUIVER_LENGTH * imu_rotations)]
        imu_z_quiver_segments = [[(s[0], s[1], s[2]), (s[0] + r[0, 2], s[1] + r[1, 2], s[2] + r[2, 2])] for s, r in zip(imu_standoffs, IMU_QUIVER_LENGTH * imu_rotations)]

        imu_x_quivers.set_segments(imu_x_quiver_segments)
        imu_y_quivers.set_segments(imu_y_quiver_segments)
        imu_z_quivers.set_segments(imu_z_quiver_segments)

        imu_origins.set_data(imu_standoffs[:, :2].T)
        imu_origins.set_3d_properties(imu_standoffs[:, 2])

        # Set labels text positions
        for label, imu in zip(labels, imu_standoffs):
            label.set_position((imu[0], imu[1]))
            label.set_3d_properties(z=imu[2], zdir=None)

        # Set frame index text
        if frames is not None:
            frame_index.set_text("Frame " + str(index) + " of " + str(len(frames)))

        # Set limits
        all_xyz = numpy.concatenate((origin_positions, end_positions, joint_positions, imu_standoffs))

        all_xyz = numpy.concatenate((all_xyz, [x[1] for x in joint_x_quiver_segments], [y[1] for y in joint_y_quiver_segments], [z[1] for z in joint_z_quiver_segments]))

        all_xyz = numpy.concatenate((all_xyz, [x[1] for x in imu_x_quiver_segments], [y[1] for y in imu_y_quiver_segments], [z[1] for z in imu_z_quiver_segments]))

        axis.set_xlim3d(numpy.min(all_xyz[:, 0]), numpy.max(all_xyz[:, 0]))
        axis.set_ylim3d(numpy.min(all_xyz[:, 1]), numpy.max(all_xyz[:, 1]))
        axis.set_zlim3d(numpy.min(all_xyz[:, 2]), numpy.max(all_xyz[:, 2]))

        axis.set_box_aspect(numpy.ptp(all_xyz, axis=0))

    # Static plot
    if frames is None:
        update(None)
        return

    # Animation
    anim = animation.FuncAnimation(figure, update, frames=len(frames), interval=1000 / fps, repeat=False, blit=False)

    if file_name:
        anim.save(file_name, writer=animation.PillowWriter(fps), dpi="figure", progress_callback=lambda i, n: print(f"Saving frame {i + 1} of {n}"))
    else:
        pyplot.show()  # play animation
