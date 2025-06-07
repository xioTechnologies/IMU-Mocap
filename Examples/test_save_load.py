import imumocap
import imumocap.load
import imumocap.save
import models

model = models.LowerBody()

model.joints["Left Hip"].set(1, 2, 3)

imumocap.save.save_model("model.json", model.root, model.joints)
imumocap.save.save_pose("pose.json", model.joints)

root, joints, _ = imumocap.load.load_model("model.json")
pose = imumocap.load.load_pose("pose.json", joints)

for k, v in pose.items():
    root.dictionary()[k].joint = v

imumocap.save.save_model("model.json", root, joints)
imumocap.save.save_pose("pose.json", joints)
