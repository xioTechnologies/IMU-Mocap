import imumocap
import matplotlib.pyplot as pyplot
import numpy
import scipy
import ximu3csv

# Crate kinematic model
PELVIS_LENGTH = 1
PELVIS_WIDTH = 2
UPPER_LEG_LENGTH = 4
LOWER_LEG_LENGTH = 4
FOOT_LENGTH = 1

left_foot = imumocap.Link("left_foot", FOOT_LENGTH)
left_lower_leg = imumocap.Link("left_lower_leg", LOWER_LEG_LENGTH, [(left_foot, imumocap.Link.matrix(pitch=-90, x=LOWER_LEG_LENGTH))])
left_upper_leg = imumocap.Link("left_upper_leg", UPPER_LEG_LENGTH, [(left_lower_leg, imumocap.Link.matrix(x=UPPER_LEG_LENGTH))])

right_foot = imumocap.Link("right_foot", FOOT_LENGTH)
right_lower_leg = imumocap.Link("right_lower_leg", LOWER_LEG_LENGTH, [(right_foot, imumocap.Link.matrix(pitch=-90, x=LOWER_LEG_LENGTH))])
right_upper_leg = imumocap.Link("right_upper_leg", UPPER_LEG_LENGTH, [(right_lower_leg, imumocap.Link.matrix(x=UPPER_LEG_LENGTH))])

pelvis = imumocap.Link("pelvis", PELVIS_LENGTH, [(left_upper_leg, imumocap.Link.matrix(y=PELVIS_WIDTH / 2, roll=180, yaw=180)),
                                                 (right_upper_leg, imumocap.Link.matrix(y=-PELVIS_WIDTH / 2, roll=180, yaw=180))])

# Import IMU data
devices = ximu3csv.read("Logged Data")

# Resample IMU data and arrange as dictionary of device names
first_timestamp = numpy.max([d.quaternion.timestamp[0] for d in devices]) / 1E6  # convert microseconds to seconds
last_timestamp = numpy.min([d.quaternion.timestamp[-1] for d in devices]) / 1E6

FPS = 30
time = numpy.arange(first_timestamp, last_timestamp, 1 / FPS)

dictionary = {d.device_name: scipy.interpolate.interp1d(d.quaternion.timestamp / 1E6, d.quaternion.quaternion.wxyz, axis=0)(time) for d in devices}

# Calibrate IMU alignment (data must start in calibration pose, facing north)
pelvis.joint = imumocap.Link.matrix(pitch=-90)

for link in imumocap.Link.flatten(pelvis):
    link.set_imu_global(imumocap.Link.matrix(quaternion=dictionary[link.name][0, :]))

imumocap.plot(pelvis)
pyplot.show()

# Create animation
frames = []

for index, _ in enumerate(time):
    for link in imumocap.Link.flatten(pelvis):
        link.set_joint_from_imu_global(imumocap.Link.matrix(quaternion=dictionary[link.name][index, :]))

    frames.append([l.joint.copy() for l in imumocap.Link.flatten(pelvis)])

imumocap.plot(pelvis, frames, fps=FPS, elev=10, file_name="lower_body.gif", figsize=(16, 9), dpi=120)
