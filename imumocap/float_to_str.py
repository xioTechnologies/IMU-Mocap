def float_to_str(number: float, precision: int = 6) -> str:
    string = f"{number:.{precision}g}"

    return "0" if string == "-0" else string
