import sys

import imumocap
import imumocap.file
from imumocap import Model

import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = models.Factory().body()

# Save and load model
imumocap.file.save_model("model.json", model.root, model.joints)

root, joints = imumocap.file.load_model("model.json")

model = Model(root, joints)

# Plot
imumocap.plot(model, block=not dont_block)
