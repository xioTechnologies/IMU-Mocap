import sys

import imumocap
import numpy as np
from imumocap import Link, Matrix

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Create model
lower_arm = Link("Forearm", Matrix(y=1))
upper_arm = Link("Upper Arm", Matrix(y=1)).connect(lower_arm)

# Create animation frames
frames = []

for angle in [120 * np.sin(t) for t in np.linspace(0, np.pi, 100)]:
    lower_arm.joint = Matrix(rot_z=angle)

    frames.append(imumocap.get_pose(upper_arm))

# Plot
imumocap.plot(upper_arm, frames, block=not dont_block)
