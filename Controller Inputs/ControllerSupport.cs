using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script maps all input for Xbox and Playstation
/// controllers. This version of the Controler Support
/// script uses the old Unity input system.
/// </summary>

public static class ControllerSupport
{
    #region Controller Properties
    //General controllers
    public static bool HoldTopButton;
    public static bool HoldRightButton;
    public static bool HoldLeftButton;
    public static bool HoldBottomButton;

    public static bool HoldLeftStick;
    public static bool HoldRightStick;

    public static bool HoldLeftBumpers;
    public static bool HoldRightBumpers;

    public static bool ToggleHoldExtras;

    //Switch specific
    public static bool HoldSwitchTriggers;
    #endregion

    #region Xbox Controls
    //Left and Right joysticks
    public static float Xbox_LeftStickX() {
        float X = 0;
        X += Input.GetAxis("Xbox_LeftStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Xbox_LeftStickY() {
        float X = 0;
        X += Input.GetAxis("Xbox_LeftStickY");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Xbox_RightStickX() {
        float X = 0;
        X += Input.GetAxis("Xbox_RightStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Xbox_RightStickY() {
        float X = 0;
        X += Input.GetAxis("Xbox_RightStickY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Joystick Buttons
    public static bool Xbox_LeftStick() {
        if (HoldLeftStick) {
            return Input.GetButton("Xbox_LeftStick");
        }
        else {
            return Input.GetButtonDown("Xbox_LeftStick");
        }
    }
    public static bool Xbox_RightStick() {
        if (HoldRightStick) {
            return Input.GetButton("Xbox_RightStick");
        }
        else {
            return Input.GetButtonDown("Xbox_RightStick");
        }
    }

    //D-pad
    public static float Xbox_DpadX() {
        float X = 0;
        X += Input.GetAxis("Xbox_DpadX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Xbox_DpadY() {
        float X = 0;
        X += Input.GetAxis("Xbox_DpadY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Triggers and bumpers
    public static bool Xbox_LeftBump() {
        if (HoldLeftBumpers) {
            return Input.GetButton("Xbox_LeftBump");
        }
        else {
            return Input.GetButtonDown("Xbox_LeftBump");
        }
    }
    public static bool Xbox_RightBump() {
        if (HoldRightBumpers) {
            return Input.GetButton("Xbox_RightBump");
        }
        else {
            return Input.GetButtonDown("Xbox_RightBump");
        }
    }
    public static float Xbox_LeftTrigger() {
        float X = 0;
        X += Input.GetAxis("Xbox_LeftTrigger");
        return Mathf.Clamp(X, 0, 1);
    }
    public static float Xbox_RightTrigger() {
        float X = 0;
        X += Input.GetAxis("Xbox_RightTrigger");
        return Mathf.Clamp(X, 0, 1);
    }

    //Buttons
    public static bool Xbox_AButton() {
        if (HoldBottomButton) {
            return Input.GetButton("Xbox_AButton");
        }
        else {
            return Input.GetButtonDown("Xbox_AButton");
        }
    }
    public static bool Xbox_BButton() {
        if (HoldRightButton) {
            return Input.GetButton("Xbox_BButton");
        }
        else {
            return Input.GetButtonDown("Xbox_BButton");
        }
    }
    public static bool Xbox_XButton() {
        if (HoldLeftButton) {
            return Input.GetButton("Xbox_XButton");
        }
        else {
            return Input.GetButtonDown("Xbox_XButton");
        }
    }
    public static bool Xbox_YButton() {
        if (HoldTopButton) {
            return Input.GetButton("Xbox_YButton");
        }
        else {
            return Input.GetButtonDown("Xbox_YButton");
        }
    }
    public static bool Xbox_BackButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("Xbox_StartButton");
        }
        else {
            return Input.GetButtonDown("Xbox_StartButton");
        }
    }
    public static bool Xbox_StartButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("Xbox_StartButton");
        }
        else {
            return Input.GetButtonDown("Xbox_StartButton");
        }
    }
    #endregion

    #region Playstation Controls
    //Left and Right joysticks
    public static float PlayStation_LeftStickX() {
        float X = 0;
        X += Input.GetAxis("PlayStation_LeftStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PlayStation_LeftStickY() {
        float X = 0;
        X += Input.GetAxis("PlayStation_LeftStickY");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PlayStation_RightStickX() {
        float X = 0;
        X += Input.GetAxis("PlayStation_RightStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PlayStation_RightStickY() {
        float X = 0;
        X += Input.GetAxis("PlayStation_RightStickY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Joystick Buttons
    public static bool PlayStation_LeftStick() {
        if (HoldLeftStick) {
            return Input.GetButton("PlayStation_LeftStick");
        }
        else {
            return Input.GetButtonDown("PlayStation_LeftStick");
        }
    }
    public static bool PlayStation_RightStick() {
        if (HoldRightStick) {
            return Input.GetButton("PlayStation_RightStick");
        }
        else {
            return Input.GetButtonDown("PlayStation_RightStick");
        }
    }

    //D-pad
    public static float PlayStation_DpadX() {
        float X = 0;
        X += Input.GetAxis("PlayStation_DpadX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float PlayStation_DpadY() {
        float X = 0;
        X += Input.GetAxis("PlayStation_DpadY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Triggers and bumpers
    public static bool PlayStation_LeftBump() {
        if (HoldLeftBumpers) {
            return Input.GetButton("PlayStation_LeftBump");
        } 
        else {
            return Input.GetButtonDown("PlayStation_LeftBump");
        }
    }
    public static bool PlayStation_RightBump() {
        if (HoldRightBumpers) {
            return Input.GetButton("PlayStation_RightBump");
        }
        else {
            return Input.GetButtonDown("PlayStation_RightBump");
        }
    }
    public static float PlayStation_LeftTrigger() {
        float X = 0;
        X += Input.GetAxis("PlayStation_LeftTrigger");
        return Mathf.Clamp(X, 0, 1);
    }
    public static float PlayStation_RightTrigger() {
        float X = 0;
        X += Input.GetAxis("PlayStation_RightTrigger");
        return Mathf.Clamp(X, 0, 1);
    }

    //Buttons
    public static bool PlayStation_SButton() {
        if (HoldLeftButton) {
            return Input.GetButton("PlayStation_SButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_SButton");
        }
    }
    public static bool PlayStation_XButton() {
        if (HoldBottomButton) {
            return Input.GetButton("PlayStation_XButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_XButton");
        }
    }
    public static bool PlayStation_OButton() {
        if (HoldRightButton) {
            return Input.GetButton("PlayStation_OButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_OButton");
        }
    }
    public static bool PlayStation_TButton() {
        if (HoldTopButton) {
            return Input.GetButton("PlayStation_TButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_TButton");
        }
    }
    public static bool PlayStation_ShareButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("PlayStation_ShareButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_ShareButton");
        }
    }
    public static bool PlayStation_OptionsButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("PlayStation_OptionsButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_OptionsButton");
        }
    }
    public static bool PlayStation_HomeButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("PlayStation_HomeButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_HomeButton");
        }
    }
    #endregion
}