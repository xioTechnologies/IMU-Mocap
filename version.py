import os
import re

version = "1.1.1"


def replace(file_path: str, string: str) -> None:
    with open(file_path) as file:
        lines = file.readlines()

    with open(file_path, "w") as file:
        for line in lines:
            file.write(re.sub(string, string.replace("\\", "").replace(".*", version), line))


for root, _, files in os.walk(os.path.dirname(os.path.realpath(__file__))):
    for file in files:
        file_path = os.path.join(root, file)

        if file == "main.yml":
            replace(file_path, "version: '.*'")

        if file == "pyproject.toml":
            replace(file_path, 'version = ".*"')

        if file == "WindowsInstaller.iss":
            replace(file_path, "AppVersion=.*\n")
