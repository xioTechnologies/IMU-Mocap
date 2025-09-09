import imumocap
import imumocap.viewer

viewer_connection = imumocap.viewer.Connection()

viewer_connection.send_text("Test Text", 10)
