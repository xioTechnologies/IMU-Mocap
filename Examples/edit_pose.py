import time
import tkinter as tk
from tkinter import ttk

import imumocap
import imumocap.file
import imumocap.solvers
from imumocap import Joint

root, joints = imumocap.file.load_model("edit_pose.json")

original_pose = imumocap.get_pose(root)

pose = imumocap.get_pose(root)

connection = imumocap.viewer.Connection()

UPDATE_RATE = 30  # fps
BEND_RANGE = 180
TILT_RANGE = 90
TWIST_RANGE = 180


# ---


ui_root = tk.Tk()
ui_root.title("Joint Slider UI")
ui_root.minsize(400, 400)


# Buttons
button_bar = ttk.Frame(ui_root)
button_bar.pack(fill="x", padx=10, pady=5)


def on_save():
    imumocap.file.save_model("edit_pose.json", root, joints)
    print("Saved")


save_button = ttk.Button(button_bar, text="Save", command=on_save)
save_button.pack(side="left")

symmetry_var = tk.BooleanVar()
symmetry_checkbox = ttk.Checkbutton(button_bar, text="Symmetry", variable=symmetry_var)
symmetry_checkbox.pack(side="left", padx=(10, 0))


# Scroll Area
main_frame = ttk.Frame(ui_root)
main_frame.pack(fill=tk.BOTH, expand=True)

canvas = tk.Canvas(main_frame)

scrollbar = ttk.Scrollbar(main_frame, orient="vertical", command=canvas.yview)
scrollable_frame = ttk.Frame(canvas)

scrollable_frame.bind("<Configure>", lambda e: canvas.configure(scrollregion=canvas.bbox("all")))


def resize_scrollable_frame(event):
    canvas.itemconfig("scrollable_window", width=event.width)


canvas.bind("<Configure>", resize_scrollable_frame)

canvas.create_window((0, 0), window=scrollable_frame, anchor="nw", tags="scrollable_window")
canvas.configure(yscrollcommand=scrollbar.set)

canvas.pack(side="left", fill="both", expand=True)
scrollbar.pack(side="right", fill="y")


# Grid
grid_frame = ttk.Frame(scrollable_frame)
grid_frame.pack(fill="both", expand=True, padx=10, pady=10)

# Columns
grid_frame.columnconfigure(0, weight=0)  # Joint name
grid_frame.columnconfigure(1, weight=2)  # Bend
grid_frame.columnconfigure(2, weight=2)  # Tilt
grid_frame.columnconfigure(3, weight=2)  # Twist

# Headers
header_bend = ttk.Label(grid_frame, text="Bend", font=("TkDefaultFont", 10, "bold"), anchor="center")
header_bend.grid(row=0, column=1, sticky="ew", padx=5, pady=5)

header_tilt = ttk.Label(grid_frame, text="Tilt", font=("TkDefaultFont", 10, "bold"), anchor="center")
header_tilt.grid(row=0, column=2, sticky="ew", padx=5, pady=5)

header_twist = ttk.Label(grid_frame, text="Twist", font=("TkDefaultFont", 10, "bold"), anchor="center")
header_twist.grid(row=0, column=3, sticky="ew", padx=5, pady=5)

# Sliders
slider_groups: dict[str, list[tk.Scale]] = {}


def create_slider(parent, value: float, range: float) -> tk.Scale:
    slider = tk.Scale(parent, from_=-range, to=range, orient="horizontal")
    slider.set(value)
    return slider


row = 1
for name, joint in joints.items():
    joint_label = ttk.Label(grid_frame, text=name)
    joint_label.grid(row=row, column=0, sticky="w", padx=5, pady=2)

    bend, tilt, twist = joint.get()

    bend_slider = create_slider(grid_frame, bend, BEND_RANGE)
    bend_slider.grid(row=row, column=1, sticky="ew", padx=5, pady=2)

    tilt_slider = create_slider(grid_frame, tilt, TILT_RANGE)
    tilt_slider.grid(row=row, column=2, sticky="ew", padx=5, pady=2)

    twist_slider = create_slider(grid_frame, twist, TWIST_RANGE)
    twist_slider.grid(row=row, column=3, sticky="ew", padx=5, pady=2)

    slider_groups[name] = [bend_slider, tilt_slider, twist_slider]

    row += 1


# Auto-fit
ui_root.update_idletasks()  # pump the ui event queue

preferred_width = max(canvas.winfo_reqwidth(), int(ui_root.winfo_screenwidth() * 0.8))  # fill most of the screen width
preferred_height = min(canvas.winfo_reqheight(), int(ui_root.winfo_screenheight() * 0.8))  # only expand enough to fit the content
ui_root.geometry(f"{preferred_width}x{preferred_height}")


# ---


job = None  # store the job so we can cancel it


def on_closing():
    global job
    if job:
        ui_root.after_cancel(job)
    ui_root.destroy()


ui_root.protocol("WM_DELETE_WINDOW", on_closing)  # handle the window closing


def update_model_loop():
    # update pose from sliders
    for name, joint in joints.items():
        group = slider_groups[name]
        joint.set(group[0].get(), group[1].get(), group[2].get())

    connection.send([*imumocap.viewer.link_to_primitives(root), *imumocap.viewer.joints_to_primitives(joints, ["Left"])])

    global job
    job = ui_root.after(UPDATE_RATE, update_model_loop)  # loop


job = ui_root.after(UPDATE_RATE, update_model_loop)  # start the loop

ui_root.mainloop()
