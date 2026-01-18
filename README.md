# FindIt

**FindIt** is a tension-filled surveillance horror game built with Unity. Inspired by titles like *I'm on Observation Duty*, the game challenges players to monitor a house through security cameras and identify subtle "anomalies" before they escalate into a game-over.

## 👁️ Gameplay Overview

You are tasked with watching three key areas of a residence:
*   **Living Room**
*   **Bedroom**
*   **Kitchen**

As time passes, strange events—anomalies—will occur. Your job is to spot these changes and file an **Anomaly Report** immediately.

### Types of Anomalies
*   **Move**: An object shifts its position.
*   **Disappear**: An item completely vanishes from the room.
*   **Color Change**: An object's color changes unnaturally.
*   **Swap**: Objects switch places or models are replaced.

## 🛠️ Game Mechanics

*   **Reporting**: Use the in-game UI to select the room where you spotted an anomaly.
*   **Survival**: 
    - If you reach **5 unreported anomalies**, the house becomes too unstable and the game ends.
    - You have **3 lives**. Filing a false report (reporting a room without an anomaly) costs one life.
*   **Timer**: Track how long you can survive the shift.

## 🚀 Technical Details

*   **Engine**: Unity
*   **Language**: C#
*   **Key Scripts**:
    - `GameManager.cs`: Handles the randomized event interval (30s) and triggers anomaly types.
    - `UIManager.cs`: Manages the reporting system, life counter, and game state transitions.
    - `CameraSwitch.cs`: Controls the surveillance camera perspective.

## 🎮 How to Play

1.  Clone this repository.
2.  Open the project in **Unity 2021.3** or later.
3.  Open the scene located at `Assets/Scenes/SampleScene.unity`.
4.  Press **Play** in the Unity Editor.
5.  Use the on-screen buttons to switch cameras and the **File Anomaly Report** button to submit your findings.

---
*Built as a technical demonstration of randomized event systems and UI-driven gameplay in Unity.*
