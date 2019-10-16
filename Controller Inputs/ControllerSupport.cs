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
//  - Switch Joy cons											//
//==============================================================//

public static class ControllerSupport
{
    public static bool ToggleHoldButtons;
    public static bool ToggleHoldStick;
    public static bool ToggleHoldBumpers;
    public static bool ToggleHoldExtras;

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
    public static bool Xbox_LeftButton() {
        if (ToggleHoldStick) {
            return Input.GetButton("Xbox_LeftButton");
        }
        else {
            return Input.GetButtonDown("Xbox_LeftButton");
        }
    }
    public static bool Xbox_RightButton() {
        if (ToggleHoldStick) {
            return Input.GetButton("Xbox_RightButton");
        }
        else {
            return Input.GetButtonDown("Xbox_RightButton");
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
        if (ToggleHoldBumpers) {
            return Input.GetButton("Xbox_LeftBump");
        }
        else {
            return Input.GetButtonDown("Xbox_LeftBump");
        }
    }
    public static bool Xbox_RightBump() {
        if (ToggleHoldBumpers) {
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
        if (ToggleHoldButtons) {
            return Input.GetButton("Xbox_AButton");
        }
        else {
            return Input.GetButtonDown("Xbox_AButton");
        }
    }
    public static bool Xbox_BButton() {
        if (ToggleHoldButtons) {
            return Input.GetButton("Xbox_BButton");
        }
        else {
            return Input.GetButtonDown("Xbox_BButton");
        }
    }
    public static bool Xbox_XButton() {
        if (ToggleHoldButtons) {
            return Input.GetButton("Xbox_XButton");
        }
        else {
            return Input.GetButtonDown("Xbox_XButton");
        }
    }
    public static bool Xbox_YButton() {
        if (ToggleHoldButtons) {
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
    public static bool PlayStation_LeftButton() {
        if (ToggleHoldStick) {
            return Input.GetButton("PlayStation_LeftButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_LeftButton");
        }
    }
    public static bool PlayStation_RightButton() {
        if (ToggleHoldStick) {
            return Input.GetButton("PlayStation_RightButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_RightButton");
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
        if (ToggleHoldBumpers) {
            return Input.GetButton("PlayStation_LeftBump");
        } 
        else {
            return Input.GetButtonDown("PlayStation_LeftBump");
        }
    }
    public static bool PlayStation_RightBump() {
        if (ToggleHoldBumpers) {
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
        if (ToggleHoldButtons) {
            return Input.GetButton("PlayStation_SButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_SButton");
        }
    }
    public static bool PlayStation_XButton() {
        if (ToggleHoldButtons) {
            return Input.GetButton("PlayStation_XButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_XButton");
        }
    }
    public static bool PlayStation_OButton() {
        if (ToggleHoldButtons) {
            return Input.GetButton("PlayStation_OButton");
        }
        else {
            return Input.GetButtonDown("PlayStation_OButton");
        }
    }
    public static bool PlayStation_TButton() {
        if (ToggleHoldButtons) {
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

    #region Switch Controls
    //Left and Right joysticks
    public static float Switch_LeftStickX() {
        float X = 0;
        X += Input.GetAxis("Switch_LeftStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Switch_LeftStickY() {
        float X = 0;
        X += Input.GetAxis("Switch_LeftStickY");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Switch_RightStickX() {
        float X = 0;
        X += Input.GetAxis("Switch_RightStickX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Switch_RightStickY() {
        float X = 0;
        X += Input.GetAxis("Switch_RightStickY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Joystick Buttons
    public static bool Switch_LeftButton() {
        if (ToggleHoldStick) {
            return Input.GetButton("Switch_LeftButton");
        }
        else {
            return Input.GetButtonDown("Switch_LeftButton");
        }
    }
    public static bool Switch_RightButton() {
        if (ToggleHoldStick) {
            return Input.GetButton("Switch_RightButton");
        }
        else {
            return Input.GetButtonDown("Switch_RightButton");
        }
    }

    //D-pad
    public static float Switch_DpadX() {
        float X = 0;
        X += Input.GetAxis("Switch_DpadX");
        return Mathf.Clamp(X, -1, 1);
    }
    public static float Switch_DpadY() {
        float X = 0;
        X += Input.GetAxis("Switch_DpadY");
        return Mathf.Clamp(X, -1, 1);
    }

    //Triggers and bumpers
    public static bool Switch_LeftBump() {
        if (ToggleHoldBumpers) {
            return Input.GetButton("Switch_LeftBump");
        }
        else {
            return Input.GetButtonDown("Switch_LeftBump");
        }
    }
    public static bool Switch_RightBump() {
        if (ToggleHoldBumpers) {
            return Input.GetButton("Switch_RightBump");
        }
        else {
            return Input.GetButtonDown("Switch_RightBump");
        }
    }
    public static float Switch_LeftTrigger() {
        float X = 0;
        X += Input.GetAxis("Switch_LeftTrigger");
        return Mathf.Clamp(X, 0, 1);
    }
    public static float Switch_RightTrigger() {
        float X = 0;
        X += Input.GetAxis("Switch_RightTrigger");
        return Mathf.Clamp(X, 0, 1);
    }
    #endregion
}