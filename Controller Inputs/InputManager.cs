using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script determines the inputs of game controllers
    and universaly maps all input axies and keys.

    Current mapped controllers:
    - Xbox one / 360
    - Playstation 4
*/

public static class InputManager
{
    #region Xbox Controls
    //Left and Right joysticks
    public static float X_LeftStickX() {
        float X = 0;
        X += Input.GetAxis("X_LeftStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float X_LeftStickY() {
        float X = 0;
        X += Input.GetAxis("X_LeftStickY");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float X_RightStickX() {
        float X = 0;
        X += Input.GetAxis("X_RightStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float X_RightStickY() {
        float X = 0;
        X += Input.GetAxis("X_RightStickY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Joystick Buttons
    public static bool X_LeftButton() {
        return Input.GetButtonDown("X_LeftButton");
    }
    public static bool X_RightButton() {
        return Input.GetButtonDown("X_RightButton");
    }

    //D-pad
    public static float X_DpadX() {
        float X = 0;
        X += Input.GetAxis("X_DpadX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float X_DpadY() {
        float X = 0;
        X += Input.GetAxis("X_DpadY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Triggers and bumpers
    public static bool X_LeftBump() {
        return Input.GetButtonDown("X_LeftBump");
    }
    public static bool X_RightBump() {
        return Input.GetButtonDown("X_RightBump");
    }
    public static float X_LeftTrigger() {
        float X = 0;
        X += Input.GetAxis("X_LeftTrigger");
        return Mathf.Clamp(X, 0, 1);
    }
    public static float X_RightTrigger() {
        float X = 0;
        X += Input.GetAxis("X_RightTrigger");
        return Mathf.Clamp(X, 0, 1);
    }

    //Buttons
    public static bool X_AButton() {
        return Input.GetButtonDown("X_AButton");
    }
    public static bool X_BButton() {
        return Input.GetButtonDown("X_BButton");
    }
    public static bool X_XButton() {
        return Input.GetButtonDown("X_XButton");
    }
    public static bool X_YButton() {
        return Input.GetButtonDown("X_YButton");
    }
    public static bool X_BackButton() {
        return Input.GetButtonDown("X_BackButton");
    }
    public static bool X_StartButton() {
        return Input.GetButtonDown("X_StartButton");
    }
    #endregion

    #region Playstation Controls
    //Left and Right joysticks
    public static float PS_LeftStickX() {
        float X = 0;
        X += Input.GetAxis("PS_LeftStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PS_LeftStickY() {
        float X = 0;
        X += Input.GetAxis("PS_LeftStickY");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PS_RightStickX() {
        float X = 0;
        X += Input.GetAxis("PS_RightStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PS_RightStickY() {
        float X = 0;
        X += Input.GetAxis("PS_RightStickY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Joystick Buttons
    public static bool PS_LeftButton() {
        return Input.GetButtonDown("PS_LeftButton");
    }
    public static bool PS_RightButton() {
        return Input.GetButtonDown("PS_RightButton");
    }

    //D-pad
    public static float PS_DpadX() {
        float X = 0;
        X += Input.GetAxis("PS_DpadX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PS_DpadY() {
        float X = 0;
        X += Input.GetAxis("PS_DpadY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Triggers and bumpers
    public static bool PS_LeftBump() {
        return Input.GetButtonDown("PS_LeftBump");
    }
    public static bool PS_RightBump() {
        return Input.GetButtonDown("PS_RightBump");
    }
    public static float PS_LeftTrigger() {
        float X = 0;
        X += Input.GetAxis("PS_LeftTrigger");
        return Mathf.Clamp(X, 0, 1);
    }
    public static float PS_RightTrigger() {
        float X = 0;
        X += Input.GetAxis("PS_RightTrigger");
        return Mathf.Clamp(X, 0, 1);
    }

    //Buttons
    public static bool PS_SButton() {
        return Input.GetButtonDown("PS_SButton");
    }
    public static bool PS_XButton() {
        return Input.GetButtonDown("PS_XButton");
    }
    public static bool PS_OButton() {
        return Input.GetButtonDown("PS_OButton");
    }
    public static bool PS_TButton() {
        return Input.GetButtonDown("PS_TButton");
    }
    public static bool PS_ShareButton() {
        return Input.GetButtonDown("PS_ShareButton");
    }
    public static bool PS_OptionsButton() {
        return Input.GetButtonDown("PS_OptionsButton");
    }
    public static bool PS_HomeButton() {
        return Input.GetButtonDown("PS_HomeButton");
    }
    #endregion
}
