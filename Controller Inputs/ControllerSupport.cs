using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==============================================================//
//  This script determines the inputs of game controllers		//
//  and universaly maps all input axies and keys.				//
//																//
//  Current mapped controllers:									//
//  - Xbox one / 360											//
//  - Playstation 4												//
//==============================================================//

public static class ControllerSupport
{
    public static bool ToggleHold;
    public static bool ToggleHoldExtras;

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
        if (ToggleHold) {
            return Input.GetButton("X_LeftButton");
        }
        else {
            return Input.GetButtonDown("X_LeftButton");
        }
    }
    public static bool X_RightButton() {
        if (ToggleHold) {
            return Input.GetButton("X_RightButton");
        }
        else {
            return Input.GetButtonDown("X_RightButton");
        }
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
        if (ToggleHold) {
            return Input.GetButton("X_LeftBump");
        }
        else {
            return Input.GetButtonDown("X_LeftBump");
        }
    }
    public static bool X_RightBump() {
        if (ToggleHold) {
            return Input.GetButton("X_RightBump");
        }
        else {
            return Input.GetButtonDown("X_RightBump");
        }
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
        if (ToggleHold) {
            return Input.GetButton("X_AButton");
        }
        else {
            return Input.GetButtonDown("X_AButton");
        }
    }
    public static bool X_BButton() {
        if (ToggleHold) {
            return Input.GetButton("X_BButton");
        }
        else {
            return Input.GetButtonDown("X_BButton");
        }
    }
    public static bool X_XButton() {
        if (ToggleHold) {
            return Input.GetButton("X_XButton");
        }
        else {
            return Input.GetButtonDown("X_XButton");
        }
    }
    public static bool X_YButton() {
        if (ToggleHold) {
            return Input.GetButton("X_YButton");
        }
        else {
            return Input.GetButtonDown("X_YButton");
        }
    }
    public static bool X_BackButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("X_StartButton");
        }
        else {
            return Input.GetButtonDown("X_StartButton");
        }
    }
    public static bool X_StartButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("X_StartButton");
        }
        else {
            return Input.GetButtonDown("X_StartButton");
        }
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
        if (ToggleHold) {
            return Input.GetButton("PS_LeftButton");
        }
        else {
            return Input.GetButtonDown("PS_LeftButton");
        }
    }
    public static bool PS_RightButton() {
        if (ToggleHold) {
            return Input.GetButton("PS_RightButton");
        }
        else {
            return Input.GetButtonDown("PS_RightButton");
        }
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
        if (ToggleHold) {
            return Input.GetButton("PS_LeftBump");
        } 
        else {
            return Input.GetButtonDown("PS_LeftBump");
        }
    }
    public static bool PS_RightBump() {
        if (ToggleHold) {
            return Input.GetButton("PS_RightBump");
        }
        else {
            return Input.GetButtonDown("PS_RightBump");
        }
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
        if (ToggleHold) {
            return Input.GetButton("PS_SButton");
        }
        else {
            return Input.GetButtonDown("PS_SButton");
        }
    }
    public static bool PS_XButton() {
        if (ToggleHold) {
            return Input.GetButton("PS_XButton");
        }
        else {
            return Input.GetButtonDown("PS_XButton");
        }
    }
    public static bool PS_OButton() {
        if (ToggleHold) {
            return Input.GetButton("PS_OButton");
        }
        else {
            return Input.GetButtonDown("PS_OButton");
        }
    }
    public static bool PS_TButton() {
        if (ToggleHold) {
            return Input.GetButton("PS_TButton");
        }
        else {
            return Input.GetButtonDown("PS_TButton");
        }
    }
    public static bool PS_ShareButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("PS_ShareButton");
        }
        else {
            return Input.GetButtonDown("PS_ShareButton");
        }
    }
    public static bool PS_OptionsButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("PS_OptionsButton");
        }
        else {
            return Input.GetButtonDown("PS_OptionsButton");
        }
    }
    public static bool PS_HomeButton() {
        if (ToggleHoldExtras) {
            return Input.GetButton("PS_HomeButton");
        }
        else {
            return Input.GetButtonDown("PS_HomeButton");
        }
    }
    #endregion
}
