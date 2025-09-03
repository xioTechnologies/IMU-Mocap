import time
import tkinter as tk
from tkinter import filedialog, messagebox, ttk

import example_models
import imumocap
import imumocap.file
import imumocap.solvers
import imumocap.viewer
from imumocap import Joint

initial_path = "model.json"
save_file_path: str | None = "edit_pose.json"


# Load model
model = example_models.LeftHand()

imumocap.file.save_model(initial_path, model.root, model.joints)

root, joints = imumocap.file.load_model(initial_path)

original_pose = imumocap.get_pose(root)

pose = imumocap.get_pose(root)

viewer = imumocap.viewer.Connection()

UPDATE_RATE = 30  # fps
ALPHA_RANGE = 180
BETA_RANGE = 90
GAMMA_RANGE = 180


# ---
ui_root = tk.Tk()
ui_root.title("Edit Pose")
ui_root.minsize(400, 400)


# Buttons
button_strip = ttk.Frame(ui_root)
button_strip.pack(fill="x", padx=10, pady=5)


def on_save():
    global save_file_path

    try:
        imumocap.file.save_model(save_file_path, root, joints)
        print("Saved")
    except Exception as e:
        print(f"Save failed: {e}")


save_button = ttk.Button(button_strip, text="Save", command=on_save)
save_button.pack(side="left")


def on_save_as():
    global save_file_path

    try:
        file_path = filedialog.asksaveasfilename(title="Save Model", defaultextension=".json", filetypes=[("JSON files", "*.json"), ("All files", "*.*")], initialfile=save_file_path)

        if file_path:
            save_file_path = file_path

            imumocap.file.save_model(file_path, root, joints)

            messagebox.showinfo("Success", f"Model saved to {file_path}")

    except Exception as e:
        messagebox.showerror("Error", f"Save failed: {e}")


save_as_button = ttk.Button(button_strip, text="Save as", command=on_save_as)
save_as_button.pack(side="left")


def update_sliders_from_model():
    for name, joint in joints.items():
        alpha, beta, gamma = joint.get()
        slider_alpha, slider_beta, slider_gamma = slider_groups[name]

        slider_alpha.set(alpha)
        slider_beta.set(beta)
        slider_gamma.set(gamma)


def on_reset():
    imumocap.set_pose(root, original_pose)
    update_sliders_from_model()


reset_button = ttk.Button(button_strip, text="Reset", command=on_reset)
reset_button.pack(side="left")

symmetrical_var = tk.BooleanVar()


def on_symmetry_toggle():
    global active_slider
    active_slider = None


symmetrical_checkbox = ttk.Checkbutton(button_strip, text="Symmetrical", variable=symmetrical_var, command=on_symmetry_toggle)
symmetrical_checkbox.pack(side="left", padx=(10, 0))


# Scroll Area
main_frame = ttk.Frame(ui_root)
main_frame.pack(fill=tk.BOTH, expand=True)

canvas = tk.Canvas(main_frame, highlightthickness=0, bd=0)

scrollbar = ttk.Scrollbar(main_frame, orient="vertical", command=canvas.yview)
scrollable_frame = ttk.Frame(canvas)

scrollable_frame.bind("<Configure>", lambda e: canvas.configure(scrollregion=canvas.bbox("all")))


def resize_scrollable_frame(event):
    canvas.itemconfig("scrollable_window", width=event.width)


canvas.bind("<Configure>", resize_scrollable_frame)


# Make sure the canvas can receive focus for mouse wheel events
canvas.focus_set()

canvas.create_window((0, 0), window=scrollable_frame, anchor="nw", tags="scrollable_window")
canvas.configure(yscrollcommand=scrollbar.set)

canvas.pack(side="left", fill="both", expand=True)
scrollbar.pack(side="right", fill="y")


# Grid
grid_frame = ttk.Frame(scrollable_frame)
grid_frame.pack(fill="both", expand=True, padx=10, pady=0)

# Columns
grid_frame.columnconfigure(0, weight=0)  # Joint name
grid_frame.columnconfigure(1, weight=2)  # Alpha
grid_frame.columnconfigure(2, weight=2)  # Beta
grid_frame.columnconfigure(3, weight=2)  # Gamma

# Headers
header_alpha = ttk.Label(grid_frame, text="Alpha", anchor="center")
header_alpha.grid(row=0, column=1, sticky="ew", padx=5, pady=0)

header_beta = ttk.Label(grid_frame, text="Beta", anchor="center")
header_beta.grid(row=0, column=2, sticky="ew", padx=5, pady=0)

header_gamma = ttk.Label(grid_frame, text="Gamma", anchor="center")
header_gamma.grid(row=0, column=3, sticky="ew", padx=5, pady=0)

# Sliders
slider_groups: dict[str, list[tk.Scale]] = {}

active_slider: str | None = None
sliders: dict[str, tk.Scale] = {}


def on_slider_focus(event, name):
    global active_slider
    active_slider = name


def create_slider(name: str, parent, value: float, range: float) -> tk.Scale:
    slider = tk.Scale(parent, from_=-range, to=range, orient="horizontal", width=8)
    slider.set(value)
    slider.bind("<Button-1>", lambda e: on_slider_focus(e, name))
    sliders[name] = slider
    return slider


row = 1
for name, joint in joints.items():
    joint_label = ttk.Label(grid_frame, text=name)
    joint_label.grid(row=row, column=0, sticky="w", padx=5, pady=2)

    alpha, beta, gamma = joint.get()

    alpha_slider = create_slider(name + "/alpha", grid_frame, alpha, ALPHA_RANGE)
    alpha_slider.grid(row=row, column=1, sticky="ew", padx=5, pady=2)

    beta_slider = create_slider(name + "/beta", grid_frame, beta, BETA_RANGE)
    beta_slider.grid(row=row, column=2, sticky="ew", padx=5, pady=2)

    gamma_slider = create_slider(name + "/gamma", grid_frame, gamma, GAMMA_RANGE)
    gamma_slider.grid(row=row, column=3, sticky="ew", padx=5, pady=2)

    slider_groups[name] = [alpha_slider, beta_slider, gamma_slider]

    row += 1

ui_root.update_idletasks()  # pump the ui event queue
grid_frame.update_idletasks()
padding = 40  # account for padding and potential scrollbar
total_required_height = button_strip.winfo_reqheight() + grid_frame.winfo_reqheight() + padding

preferred_width = max(600, int(ui_root.winfo_screenwidth() * 0.8))  # reasonable default width
preferred_height = min(total_required_height, int(ui_root.winfo_screenheight()))

ui_root.geometry(f"{preferred_width}x{preferred_height}")

screen_width = ui_root.winfo_screenwidth()
screen_height = ui_root.winfo_screenheight()

x = min(max(0, (screen_width - preferred_width) // 2), screen_width - preferred_width)
y = min(max(0, (screen_height - preferred_height) // 2), screen_height - preferred_height)

ui_root.geometry(f"{preferred_width}x{preferred_height}+{x}+{y}")


# ---


job = None  # store the job so we can cancel it


def on_closing():
    global job
    if job:
        ui_root.after_cancel(job)
    ui_root.destroy()


ui_root.protocol("WM_DELETE_WINDOW", on_closing)  # handle the window closing


def get_other_side(symbol: str, prefix1: str, prefix2: str):
    if symbol.startswith(prefix1):
        return prefix2 + symbol[len(prefix1) :]
    elif symbol.startswith(prefix2):
        return prefix1 + symbol[len(prefix2) :]
    else:
        return None


def update_model_loop():
    # symmetry update
    if symmetrical_var.get() and active_slider:
        other = get_other_side(active_slider, "Left ", "Right ")
        if other and other in sliders:
            sliders[other].set(sliders[active_slider].get())

    # update pose from sliders
    for name, joint in joints.items():
        group = slider_groups[name]
        joint.set(group[0].get(), group[1].get(), group[2].get())

    viewer.send([*imumocap.viewer.link_to_primitives(root), *imumocap.viewer.joints_to_primitives(joints, "Left")])

    global job
    job = ui_root.after(UPDATE_RATE, update_model_loop)  # loop


job = ui_root.after(UPDATE_RATE, update_model_loop)  # start the loop

ui_root.mainloop()
