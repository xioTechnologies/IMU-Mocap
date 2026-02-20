import time

import climple as cli
import imumocap
import ximu3


class Ximu3s:
    def __init__(self, model: imumocap.Model, ignored: list[str]) -> None:
        names = [n for n in model.links.keys() if n not in ignored]

        while True:
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

        messages = [m for m in messages if m.device_name in names]

        try:
            self.__connections = {c.ping().device_name: c for c in (ximu3.Connection(m.to_udp_connection_config()).open() for m in messages)}

        except Exception as ex:
            cli.print_error(ex, exit=True)

    @staticmethod
    def __verify(names: list[str], messages: list[ximu3.NetworkAnnouncementMessage]) -> bool:
        # 1. asigned[] = messages but only items that match names

        # 2. remove duplicates from asigned

        # 3. unasigned = messages - asigned

        # 4. missing = names - asigned

        pass

    @staticmethod
    def __assign(names: list[str], messages: list[ximu3.NetworkAnnouncementMessage]) -> bool:
        pass

    @staticmethod
    def matrix_from(message: ximu3.QuaternionMessage) -> imumocap.Matrix:
        return imumocap.Matrix(quaternion=[message.w, message.x, message.y, message.z])

    def get_imus(self) -> imumocap.Imus:
        return {n: Ximu3s.matrix_from(c.get_quaternion_message()) for n, c in self.__connections.items()}

    def get_button_pressed(self) -> bool:
        timestamp = max(m.timestamp for m in (c.get_notification_message() for c in self.__connections.values()) if m and "Button pressed" in m.string)

        if timestamp == self.__timestamp:
            return False

        self.__timestamp = timestamp
        return True


class Twintig:
    def __init__(self, root: imumocap.Link) -> None:
        pass

    @property
    def imus(self) -> dict[str, imumocap.Matrix]:
        pass
