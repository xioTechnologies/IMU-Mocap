import msvcrt
import time

import cliny as cli
import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer

import hardware

# Load model
model = imumocap.file.load_model("twintig.json")

try:
    imumocap.file.load_calibration("twintig_calibration.json", model)
except Exception:
    cli.print_warning("Unable to load calibration. Please perform calibration.")


# Connect to Twintig
twintig = hardware.Twintig()

# Heading solver
heading = imumocap.solvers.Heading(twintig.get_imus())


# Stream to IMU Mocap Viewer
def zero_heading():
    imus_a = twintig.get_imus()

    cli.print_muted("Please rotate")

    time.sleep(1)

    imus_b = twintig.get_imus()

    heading.zero(model, imus_a, imus_b)

    cli.print_success("Heading zeroed")


def calibrate():
    imus = heading.apply(twintig.get_imus())

    imumocap.solvers.calibrate(model, imus, mounting=imumocap.solvers.Mounting.Y_FORWARD)

    imumocap.file.save_calibration("twintig_calibration.json", model)

    cli.print_success("Calibrated")


viewer = imumocap.viewer.Connection()

while True:
    time.sleep(1 / 30)  # 30 fps

    if msvcrt.kbhit():
        match msvcrt.getwch().lower():
            case "z":
                zero_heading()
            case "c":
                calibrate()

    imus = heading.apply(twintig.get_imus())

    model.set_pose_from_imus(imus)

    viewer.send_frame(imumocap.viewer.model_to_primitives(model))
