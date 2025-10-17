import socket

from .primatives import Primitive


class Connection:
    def __init__(self, ip_address: str = "localhost", port: int = 6000) -> None:
        self.__address = (ip_address, port)

        self.__socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

        self.__socket.setsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF, 65535)

        self.__buffer_size = self.__socket.getsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF)

    def __del__(self) -> None:
        self.__socket.close()

    def send_text(self, text: str, seconds: float = 0.0) -> None:
        self.__send(f'{{"text":{{"text":"{text}","seconds":{seconds}}}}}')

    def send_frame(self, primitives: list[Primitive], layer: int = 0) -> None:
        self.__send(f'{{"frame":{{"layer":{layer},"primitives":[{",".join([str(p) for p in primitives])}]}}}}')

    def __send(self, json: str) -> None:
        data = json.encode("ascii")

        if len(data) > self.__buffer_size:
            raise ValueError(f"The data size is {len(data)}, which exceeds the buffer size of {self.__buffer_size}.")

        self.__socket.sendto(data, self.__address)
