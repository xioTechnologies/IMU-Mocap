import time

import cliny as cli
import imumocap
import ximu3
import ximu3_helpers


class Ximu3s:
    def __init__(self, model: imumocap.Model, ignored: list[str] | None = None) -> None:
        names = [n for n in model.links.keys() if (ignored is None) or (n not in ignored)]

        while True:
            print("Searching for devices")

            try:
                messages = ximu3.NetworkAnnouncement().get_messages_after_short_delay()

                if not messages:
                    raise RuntimeError("No devices found")

            except Exception as ex:
                cli.print_error(f"{ex}. Retrying.")
                time.sleep(1)
                continue

            verified = Ximu3s.__verify(names, messages)

            if cli.yes_or_no("Would you like to reassign all devices?") and cli.yes_or_no("Are you sure?"):
                Ximu3s.__assign(names, messages)
            elif verified:
                break

        try:
            self.__connections = {m.device_name: ximu3.Connection(m.to_udp_connection_config()).open() for m in messages if m.device_name in names}

            for connection in self.__connections.values():
                if connection.ping() is None:  # send ping so that device starts sending to computer's IP address
                    raise Exception(f"Ping failed for {connection.get_config()}")

        except Exception as ex:
            cli.print_error(ex, exit=True)

    @staticmethod
    def __verify(names: list[str], messages: list[ximu3.NetworkAnnouncementMessage]) -> bool:
        assigned = set(m for m in messages if m.device_name in names)

        unassigned = set(messages) - assigned

        missing = set(names) - set(m.device_name for m in assigned)

        def print_devices(prefix: str, messages: list[ximu3.NetworkAnnouncementMessage]) -> None:
            if not messages:
                return

            print(f"{prefix} ({len(messages)}):")

            for message in messages:
                cli.print_muted(f"{message.device_name:<24}{message.serial_number:<12}{str(message.to_udp_connection_config()):<32}{f'Wi-Fi {message.rssi}%':<16}{f'Battery {message.battery}%'}")

        print_devices("Assigned", assigned)

        print_devices("Unassigned", unassigned)

        if missing:
            cli.print_error(f"Missing ({len(missing)}): {', '.join(missing)}")
            return False

        cli.print_success("Setup complete")
        return True

    @staticmethod
    def __assign(names: list[str], messages: list[ximu3.NetworkAnnouncementMessage]) -> None:
        connections = [ximu3.Connection(m.to_udp_connection_config()).open() for m in messages]

        for connection in connections:
            ximu3_helpers.send_command(connection, "color", "#FF6600")  # orange LED
            ximu3_helpers.send_command(connection, "device_name", "Unassigned")

        for name in names:
            print(f"Press the button on the {name}")

            while True:
                selected = [c for c in connections if Ximu3s.__get_button_pressed(c)]

                if not selected:
                    continue

                if selected[0].ping().device_name != "Unassigned":
                    continue

                ximu3_helpers.send_command(selected[0], "color")  # restore normal LED behavior
                ximu3_helpers.send_command(selected[0], "device_name", name)
                break

        for connection in connections:
            connection.close()

    @staticmethod
    def __get_button_pressed(connection: ximu3.Connection) -> bool:
        message = connection.get_notification_message(consume=True)

        if not message:
            return False

        return "Button pressed" in message.string

    def get_imus(self) -> imumocap.Imus:
        def matrix_from(message: ximu3.QuaternionMessage | None) -> imumocap.Matrix:
            return imumocap.Matrix(quaternion=[message.w, message.x, message.y, message.z]) if message else imumocap.Matrix()

        return {n: matrix_from(c.get_quaternion_message()) for n, c in self.__connections.items()}

    def get_button_pressed(self) -> bool:
        return any(Ximu3s.__get_button_pressed(c) for c in self.__connections.values())


class Twintig:
    def __init__(self) -> None:
        self.__twintig_connection, self.__keep_open = ximu3_helpers.quick_connect("Twintig", keep_open=True)

        self.__imu_connections = ximu3_helpers.mux_connect(self.__twintig_connection, 20, dictionary=True)

        for connection in [self.__twintig_connection] + [c for c in self.__imu_connections.values()]:
            ximu3_helpers.send_command(connection, "color", "#04000F")

    def get_imus(self) -> imumocap.Imus:
        def matrix_from(message: ximu3.QuaternionMessage | None) -> imumocap.Matrix:
            return imumocap.Matrix(quaternion=[message.w, message.x, message.y, message.z]) if message else imumocap.Matrix()

        return {n: matrix_from(c.get_quaternion_message()) for n, c in self.__imu_connections.items()}
