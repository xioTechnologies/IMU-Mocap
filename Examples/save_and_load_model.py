import sys

import imumocap
import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load example model
model = models.Body()

# Save and load model
imumocap.save.save_model("model.json", model.root, model.joints)

root, joints = imumocap.load.load_model("model.json")

# Plot
root.plot(block=not dont_block)
