import sys

import imumocap
import imumocap.file

import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = models.Factory().body()

# Save and load pose
imumocap.file.save_pose("save_and_load_pose.json", model.joints)

imumocap.file.load_pose("save_and_load_pose.json", model.joints)

# Plot
imumocap.plot(model, block=not dont_block)
