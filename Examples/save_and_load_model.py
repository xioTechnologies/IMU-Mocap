import sys

import example_models
import imumocap
import imumocap.file

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = example_models.Body()

# Save and load model
imumocap.file.save_model("save_and_load_model.json", model.root, model.joints)

root, joints = imumocap.file.load_model("save_and_load_model.json")

# Plot
imumocap.plot(root, block=not dont_block)
