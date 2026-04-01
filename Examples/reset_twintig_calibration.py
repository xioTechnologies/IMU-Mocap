from datetime import datetime

import cliny as cli
import numpy as np
import ximu3_helpers
import ximu3csv

try:
    twintig_connection = ximu3_helpers.quick_connect("Twintig")

    imu_connections = ximu3_helpers.mux_connect(twintig_connection, 20, dictionary=True)

    for connection in imu_connections.values():
        ximu3_helpers.send_command(connection, "factory")
        ximu3_helpers.send_command(connection, "gyroscope_offset", [0, 0, 0])
        ximu3_helpers.send_command(connection, "gyroscope_bias_correction_enabled", False)
        ximu3_helpers.send_command(connection, "apply")

    data_logger = ximu3_helpers.DataLogger(list(imu_connections.values()), seconds=5, overwrite=True)

    devices = ximu3csv.read(data_logger.path)

    for device in devices:
        connection = imu_connections[device.device_name]

        offset: np.ndarray = device.inertial.gyroscope.xyz.mean(axis=0)

        ximu3_helpers.send_command(connection, "calibration_date", datetime.now().strftime("%Y-%m-%d %H:%M:%S"))
        ximu3_helpers.send_command(connection, "gyroscope_offset", offset.tolist())
        ximu3_helpers.send_command(connection, "save")
        ximu3_helpers.send_command(connection, "blink")

    data_logger.delete()

    cli.print_success("Complete")

except Exception as ex:
    cli.print_error(ex)