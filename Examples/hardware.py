from typing import List

import colorama
import numpy as np
import ximu3
from imumocap import Matrix


class Imu:
    __quaternion = np.array([1, 0, 0, 0])
    __button_pressed = False

    def __init__(self, connection_info: ximu3.UdpConnectionInfo) -> None:
        self.__connection = ximu3.Connection(connection_info)

        if self.__connection.open() != ximu3.RESULT_OK:
            raise Exception(f"Unable to open {connection_info.to_string()}")

        ping_response = self.__connection.ping()  # send something so that device starts sending to computer's IP address

        if ping_response.result != ximu3.RESULT_OK:
            raise Exception(f"Ping failed for {connection_info.to_string()}")

        self.__connection.add_quaternion_callback(self.__quaternion_callback)
        self.__connection.add_notification_callback(self.__notification_callback)

    def close(self) -> None:
        self.__connection.close()

    def send_command(self, key: str, value=None) -> str:
        if value is None:
            value = "null"
        elif type(value) is bool:
            value = str(value).lower()
        elif type(value) is str:
            value = f'"{value}"'
        else:
            value = str(value)

        command = f'{{"{key}":{value}}}'

        responses = self.__connection.send_commands([command], 2, 500)

        if not responses:
            raise Exception(f"No response. {command} sent to {self.__connection.get_info().to_string()}")

        response = ximu3.CommandMessage.parse(responses[0])

        if response.error:
            raise Exception(f"{response.error}. {command} sent to {self.__connection.get_info().to_string()}")

        return response.value

    def __quaternion_callback(self, message: ximu3.QuaternionMessage) -> None:
        self.__quaternion = np.array([message.w, message.x, message.y, message.z])

    def __notification_callback(self, message: ximu3.NotificationMessage) -> None:
        if message.string == "Button pressed.":
            self.__button_pressed = True

    @property
    def matrix(self) -> Matrix:
        return Matrix(quaternion=self.__quaternion)

    @property
    def button_pressed(self) -> bool:  # reading this property will clear the flag
        button_pressed = self.__button_pressed

        self.__button_pressed = False

        return button_pressed


def setup(names: List[str]) -> dict[str, Imu]:
    while True:
        messages = ximu3.NetworkAnnouncement().get_messages_after_short_delay()

        verified = _verify(names, messages)

        if not messages:
            input("No devices found. Press Enter to try again.")
            continue

        if _yes_or_no("Would you like to reassign all devices?") and _yes_or_no("Are you sure?"):
            _assign(names, messages)
        elif verified:
            break

    messages = [m for m in messages if m.device_name in names]

    return {m.device_name: Imu(m.to_udp_connection_info()) for m in messages}


def _verify(names: List[str], messages: List[ximu3.NetworkAnnouncementMessage]) -> bool:
    colorama.init()

    # Map names to network announcement messages
    names_map = {s: None for s in names}

    for name in names_map.keys():
        matched = [m for m in messages if m.device_name == name]

        if len(matched) == 1:
            names_map[name] = matched[0]

    # Print asigned and unassigned devices
    assigned = [m for m in names_map.values() if m]

    unassigned = [m for m in messages if m not in names_map.values()]

    def print_devices(prefix: str, messages: List[ximu3.NetworkAnnouncementMessage]) -> None:
        print(f"{prefix} ({len(messages)}):")

        for message in messages:
            device_name = message.device_name
            serial_number = message.serial_number
            connection_info = message.to_udp_connection_info().to_string()
            rssi = f"Wi-Fi {message.rssi}%"

            if message.charging_status == ximu3.CHARGING_STATUS_NOT_CONNECTED:
                battery = f"Battery {message.battery}%"
            else:
                battery = ximu3.charging_status_to_string(message.charging_status)

            print(f"{colorama.Fore.LIGHTBLACK_EX}{device_name:<24}{serial_number:<12}{connection_info:<32}{rssi:<16}{battery}{colorama.Style.RESET_ALL}")

    if len(assigned) > 0:
        print_devices("Assigned", assigned)

    if len(unassigned) > 0:
        print_devices("Unassigned", unassigned)

    # Print missing names
    missing = [n for n, m in names_map.items() if not m]

    if len(missing) > 0:
        print(f"{colorama.Fore.RED}Missing ({len(missing)}): {', '.join(missing)}{colorama.Style.RESET_ALL}")
        return False

    print(f"{colorama.Fore.GREEN}Setup complete{colorama.Style.RESET_ALL}")

    return True


def _yes_or_no(question: str) -> bool:
    while True:
        key = input(question + " [Y/N]\n")

        if key == "y" or key == "Y":
            return True

        if key == "n" or key == "N":
            return False


def _assign(names: List[str], messages: List[ximu3.NetworkAnnouncementMessage]) -> None:
    imus = [Imu(m.to_udp_connection_info()) for m in messages]

    for imu in imus:
        imu.send_command("color", "#FF6600")  # orange LED
        imu.send_command("device_name", "Unassigned")

    for name in names:
        print(f"Press the button on the {name}")

        while True:
            selected = [c for c in imus if c.button_pressed]

            if len(selected) == 0:
                continue

            if selected[0].send_command("device_name") != "Unassigned":
                continue

            selected[0].send_command("color")  # restore normal LED behavior
            selected[0].send_command("device_name", name)
            break

    for imu in imus:
        imu.close()
