import sys

import example_models
import imumocap
import imumocap.file

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = example_models.Body()

# Save and load pose
imumocap.file.save_pose("pose.json", model.joints)

imumocap.file.load_pose("pose.json", model.joints)

# Plot
imumocap.plot(model.root, block=not dont_block)
