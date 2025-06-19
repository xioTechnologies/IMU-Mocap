import sys

import imumocap
import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.Body()

# Save and load pose
imumocap.save_pose("pose.json", model.joints)

imumocap.load_pose("pose.json", model.joints)

# Plot
model.root.plot(block=not dont_block)
