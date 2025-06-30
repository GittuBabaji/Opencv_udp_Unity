# 🐦 Flappy Bird – Hand-Controlled (Unity + OpenCV)

This project lets you control a Flappy Bird–like game using **your index finger via webcam**. Raise your finger to make the bird jump — no keyboard required
---

## 🧠 Features

* Unity game with gravity, sprite animation, scoring, and obstacles
* Finger-controlled jump using Python, OpenCV, and Mediapipe
* Real-time hand tracking via webcam
* UDP communication from Python to Unity
* Optional analog finger position control (for drag-like movement)


---

## 🧰 Requirements

### 🕹️ Unity

* Unity 2021 or later (tested on 2022.3 LTS)
* Input system: Legacy or new (doesn't matter)

### 🐍 Python

* Python 3.8+
* Install dependencies:

```bash
pip install opencv-python mediapipe
```

---

## 🚀 How It Works

1. Python captures your webcam.
2. Tracks your index finger tip using Mediapipe.
3. Sends either:

   * `"JUMP"` (discrete control)
   * or `Y:0.42` (analog mode) via UDP to Unity.
4. Unity receives the signal and moves the bird accordingly.

---

## 🎮 How to Play

### 1. 🧩 Setup Unity

* Open the Unity project in `UnityProject/`
* In `Main.unity`, you’ll find:

  * `Player` GameObject with `Player.cs`
  * `InputManager` GameObject with `FingerControlListener.cs`
* Assign the Player reference in the `FingerControlListener` inspector field.

### 2. 📸 Run Python Controller

In `PythonControl/`:

```bash
python controller.py
```

🖐 Raise your index finger to jump!

---

## ⚙️ Switching Control Modes

In `FingerControlListener.cs`, you can toggle:

```csharp
[SerializeField] private bool useAnalogControl = false; // true for drag-like motion
```

| Mode    | Behavior                                      |
| ------- | --------------------------------------------- |
| `false` | Raise finger to jump (like spacebar)          |
| `true`  | Finger height sets bird’s Y position directly |

---

## 🧪 Troubleshooting

| Issue                    | Fix                                          |
| ------------------------ | -------------------------------------------- |
| `NullReferenceException` | Assign Player in the inspector               |
| UDP not working          | Check firewall / port (default: `5055`)      |
| No bird jump             | Add debug logs in both Unity & Python        |
| Too slow or too jumpy    | Tweak `normalized_y` threshold and smoothing |

---

## 👨‍💻 Credits

* Unity engine: [Unity](https://unity.com/)
* Hand tracking: [Mediapipe](https://google.github.io/mediapipe/)
* UDP bridge: Raw socket communication

___
Happy Walking! 🐤💨
