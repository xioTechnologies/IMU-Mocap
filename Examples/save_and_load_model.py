import sys

import imumocap
import imumocap.file

import models

dont_block = "dont_block" in sys.argv  # don't block when script run by CI

# Load model
model = models.Factory().body()

# Save and load model
imumocap.file.save_model("save_and_load_model.json", model)

model = imumocap.file.load_model("save_and_load_model.json")

# Plot
imumocap.plot(model, block=not dont_block)
