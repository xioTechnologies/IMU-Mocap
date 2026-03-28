import pickle
from abc import ABC
from dataclasses import dataclass, field, fields, replace
from pathlib import Path
from typing import Self

import numpy as np

from .matrix import Matrix
from .model import Imus, Model, Pose

# Time series dataclasses are anchored by a 'seconds' array of uniformly-
# spaced timestamps from which 'duration', 'sample_period', and 'sample_rate'
# are derived. Subclasses extend this with additional fields. Fields of type
# list, np.ndarray, and dict[str, np.ndarray] must represent time series data
# with lengths matching 'seconds'. Fields of other types may be used
# arbitrarily.

# TODO: Consider verifying approximately uniform timestamps in __post_init__

# TODO: Should 'zero' and 'crop' modify self or return a deep copy? The current
# implementation is a broken mix of the two.

# TODO: Regardless of whether modifying self or return a deep copy, the methods
# should support fluent chaining. e.g. data = TimeSeries().crop().zero()

# TODO: Should 'crop' parameters be 'start_index', 'start_seconds', etc. ?

# TODO: If path is just a file name then resolve absolute path


@dataclass
class TimeSeries(ABC):
    __PICKLE_EXTENSION = ".pkl"

    seconds: np.ndarray
    duration: float = field(init=False, default=None)
    sample_period: float = field(init=False, default=None)
    sample_rate: float = field(init=False, default=None)

    def __post_init__(self) -> None:
        self.seconds = np.array(self.seconds)
        self.duration = self.seconds[-1] - self.seconds[0]
        self.sample_period = np.median(np.diff(self.seconds))
        self.sample_rate = 1 / self.sample_period

    def __len__(self) -> int:
        return len(self.seconds)

    def __iter__(self):
        return iter(range(len(self.seconds)))

    def index(self, seconds: float) -> int:
        return int(np.argmin(np.abs(self.seconds - seconds)))

    def zero(self) -> Self:
        return replace(self, seconds=self.seconds - self.seconds[0])

    def crop(self, start: float | None, end: float | None) -> Self:
        start_index = 0 if start is None else self.index(start)
        end_index = len(self.seconds) if end is None else self.index(end)

        def crop_field(value):
            if isinstance(value, (list, np.ndarray)):
                return value[start_index:end_index]

            if isinstance(value, dict):
                return {k: v[start_index:end_index] for k, v in value.items()}

            return value

        cropped = {f.name: crop_field(getattr(self, f.name)) for f in fields(self)}

        return replace(self, **cropped)

    def save(self, path: Path | None = None) -> None:
        path = Path(path or type(self).__name__)

        path = path.with_suffix(TimeSeries.__PICKLE_EXTENSION)

        with open(path, "wb") as file:
            pickle.dump(self, file)

    @classmethod
    def load(cls, path: Path | None = None) -> Self:
        path = Path(path or cls.__name__)

        path = path.with_suffix(TimeSeries.__PICKLE_EXTENSION)

        with open(path, "rb") as file:
            obj = pickle.load(file)

        if not isinstance(obj, cls):
            raise TypeError(f"The loaded type {type(obj).__name__} is not {cls.__name__}")

        return obj


@dataclass
class ImusTimeSeries(TimeSeries):
    names: tuple[str, ...]
    gyroscope: dict[str, np.ndarray] | None = None  # {<link name>: <ndarray(n, 3)>, ...} where the columns are x, y, z
    accelerometer: dict[str, np.ndarray] | None = None  # {<link name>: <ndarray(n, 3)>, ...} where the columns are x, y, z
    magnetometer: dict[str, np.ndarray] | None = None  # {<link name>: <ndarray(n, 3)>, ...} where the columns are x, y, z
    quaternion: dict[str, np.ndarray] | None = None  # {<link name>: <ndarray(n, 4)>, ...} where the columns are w, x, y, z
    button: dict[str, np.ndarray] | None = None  # {<link name>: <ndarray(n,)>, ...} where True indicates pressed

    def __post_init__(self) -> None:
        super().__post_init__()

        self.names = tuple(self.names)

        if self.gyroscope is None:
            self.gyroscope = {n: np.empty((len(self.seconds), 3)) for n in self.names}

        if self.accelerometer is None:
            self.accelerometer = {n: np.empty((len(self.seconds), 3)) for n in self.names}

        if self.magnetometer is None:
            self.magnetometer = {n: np.empty((len(self.seconds), 3)) for n in self.names}

        if self.quaternion is None:
            self.quaternion = {n: np.empty((len(self.seconds), 4)) for n in self.names}

        if self.button is None:
            self.button = {n: np.empty((len(self.seconds),)) for n in self.names}

    def get_imus(
        self,
        index: int | None = None,
        seconds: float | None = None,
    ) -> Imus:
        if (index is None) == (seconds is None):
            raise ValueError("Either 'index' or 'seconds' must be provided")

        if index is None:
            index = self.index(seconds)

        return {n: Matrix(quaternion=q[index]) for n, q in self.quaternion.items()}


@dataclass
class PoseTimeSeries(TimeSeries):
    frames: list[Pose] | None = None

    def __post_init__(self) -> None:
        super().__post_init__()

        if self.frames is None:
            self.frames = [None for _ in self.seconds]

    def set(self, index: int, model: Model) -> None:
        self.frames[index] = model.get_pose()


@dataclass
class JointsTimeSeries(TimeSeries):
    names: tuple[str, ...]
    angles: dict[str, np.ndarray] | None = None  # {<joint name>: <ndarray(n, 3)>, ...} where the columns are alpha, beta, gamma

    def __post_init__(self) -> None:
        super().__post_init__()

        self.names = tuple(self.names)

        if self.angles is None:
            self.angles = {n: np.empty((len(self.seconds), 3)) for n in self.names}

    def set(self, index: int, model: Model) -> None:
        for name, joint in model.joints.items():
            self.angles[name][index] = joint.get()
