import sys

import imumocap
import imumocap.file
import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.Body()

# Save and load model
imumocap.file.save_model("model.json", model.root, model.joints)

root, joints = imumocap.file.load_model("model.json")

# Plot
imumocap.plot(root, block=not dont_block)
