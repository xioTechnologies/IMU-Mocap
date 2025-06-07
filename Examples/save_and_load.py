import imumocap
import models

# Load example model
model = models.Body()

# Save and load links only
imumocap.save.save_model("model.json", model.root)

root, _, _ = imumocap.load.load_model("model.json")

root.plot()

# Save and load links and joints
imumocap.save.save_model("model.json", model.root, model.joints)

root, joints, _ = imumocap.load.load_model("model.json")

joints["Lower Lumbar"].set(45)

root.plot()

# Save and load pose
model.joints["Lower Lumbar"].set(45)

imumocap.save.save_pose("pose.json", model.joints)

model.joints["Lower Lumbar"].set(0)

pose = imumocap.load.load_pose("pose.json", model.joints)

for k, v in pose.items():
    model.root.dictionary()[k].joint = v

model.root.plot()
