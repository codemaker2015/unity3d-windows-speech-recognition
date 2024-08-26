# Cube Movement with Voice Commands - Unity Project

## Overview
This Unity project demonstrates how to control a 3D Cube in the Unity environment using voice commands. The movement of the cube is handled based on recognized speech inputs such as "right," "left," "up," and "down." The speech recognition functionality is powered by Unity's `DictationRecognizer` class.

![demo](Demos/demo.gif)

## Features
- **Voice-Controlled Cube Movement**: The cube can be moved in four directions: right, left, up, and down, based on voice commands.
- **Event-Driven Speech Recognition**: The project leverages Unity's event system to handle speech command recognition.
- **DictationRecognizer Integration**: Unity's `DictationRecognizer` is used to interpret the user's voice inputs and trigger corresponding actions.

## Voice Commands
The following voice commands control the movement of the cube:
- **"right"**: Moves the cube to the right.
- **"left"**: Moves the cube to the left.
- **"up"**: Moves the cube upward.
- **"down"**: Moves the cube downward.

## Scripts

### 1. **CubeMovement.cs**
This script manages the cube's movement based on speech commands. The cube can move in different directions (right, left, up, down) by subscribing to events triggered by the `DictationController`.

- **Key Methods**:
  - `MoveForward()`: Moves the cube to the right.
  - `MoveBackward()`: Moves the cube to the left.
  - `MoveUpward()`: Moves the cube upward.
  - `MoveDownward()`: Moves the cube downward.
  
- **Event Subscription**:
  The cube subscribes to the `CommandRecognized` event from `DictationController`. Based on the recognized command, the cube will move in the appropriate direction.

### 2. **DictationController.cs**
This script manages speech recognition using Unity's `DictationRecognizer`. It triggers the `CommandRecognized` event when a speech command is detected.

- **Key Methods**:
  - `Start()`: Initializes the `DictationRecognizer` and starts listening for voice input.
  - `OnDictationResult()`: Handles the final recognized text and triggers the command event.
  - `OnDictationHypothesis()`: Provides real-time feedback on what the system is currently recognizing (useful for debugging).
  - `OnDictationComplete()`: Called when the speech recognition session ends.
  - `OnDictationError()`: Handles errors in the dictation system.

- **Events**:
  - `CommandRecognized`: An event triggered when a voice command is successfully recognized.

## Setup Instructions

1. **Unity Version**: This project is developed in Unity 2020 or higher. Ensure you are using the correct version or later.
   
2. **Import the Scripts**:
   - Create two C# scripts, `CubeMovement.cs` and `DictationController.cs`, and copy the code provided in this readme into the respective files.

3. **Assign the Scripts**:
   - Attach the `CubeMovement.cs` script to the cube GameObject in your scene.
   - Attach the `DictationController.cs` script to an empty GameObject in your scene.

4. **Configure the Cube**:
   - Ensure the cube is positioned in a 3D space where it can be visibly moved in all directions.
   - Set the `moveSpeed` parameter in the `CubeMovement` script according to your preference.

5. **Microphone Access**:
   - Ensure that microphone access is enabled in your Unity project settings since `DictationRecognizer` requires the use of the microphone for voice input.
   - For Windows, enable microphone access in **Settings > Privacy > Microphone**.

6. **Build Settings**:
   - Ensure the project is set up to run on a platform that supports the `DictationRecognizer`, such as Windows.

## How It Works
- When the scene starts, the `DictationController` script begins listening for voice input.
- Upon recognizing a command, the `CubeMovement` script receives the command via the `CommandRecognized` event and moves the cube in the corresponding direction.

## Troubleshooting

- **Microphone Issues**: Ensure the microphone permissions are correctly set on your device.
- **Dictation Not Working**: Ensure that the platform you're using supports the `DictationRecognizer` class. It may not be available on some platforms like macOS or WebGL.