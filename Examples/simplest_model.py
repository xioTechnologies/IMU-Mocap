import sys

import imumocap
import numpy as np
from imumocap import Link, Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Create model
lower_arm = Link("Forearm", Matrix(y=1))
upper_arm = Link("Upper Arm", Matrix(y=1)).connect(lower_arm)

model = imumocap.Model(upper_arm)

# Create animation frames
frames: list[imumocap.Pose] = []

for angle in [120 * np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    lower_arm.joint = Matrix(rot_z=angle)

    frames.append(model.get_pose())

# Plot
imumocap.plot(model, frames, block=not dont_block)
