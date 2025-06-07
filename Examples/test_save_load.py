import imumocap
import imumocap.load
import imumocap.save
import models

model = models.LowerBody()

imumocap.save.save_model("test.json", model.root, model.joints)

# imumocap.load.load_model("test.json")
