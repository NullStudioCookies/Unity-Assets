using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script maps all input for Xbox and Playstation
/// controllers. This version of the Controler Support
/// script uses the old Unity input system.
/// </summary>

public static class ControllerSupport {
    #region Xbox Controls
    // Left and Right joysticks
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

    // Joystick Buttons
    public static bool Xbox_LeftStickHold() {
        return Input.GetButton("Xbox_LeftStick");
    }
    public static bool Xbox_LeftStickDown() {
        return Input.GetButtonDown("Xbox_LeftStick");
    }
    public static bool Xbox_LeftStickUp() {
        return Input.GetButtonUp("Xbox_LeftStick");
    }

    public static bool Xbox_RightStickHold() {
        return Input.GetButton("Xbox_RightStick");
    }
    public static bool Xbox_RightStickDown() {
        return Input.GetButtonDown("Xbox_RightStick");
    }
    public static bool Xbox_RightStickUp() {
        return Input.GetButtonUp("Xbox_RightStick");
    }

    // D-pad
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

    // Sholder / Bumper buttons
    public static bool Xbox_LeftBumpHold() {
        return Input.GetButton("Xbox_LeftBump");
    }
    public static bool Xbox_LeftBumpDown() {
        return Input.GetButtonDown("Xbox_LeftBump");
    }
    public static bool Xbox_LeftBumpUp() {
        return Input.GetButtonUp("Xbox_LeftBump");
    }

    public static bool Xbox_RightBumpHold() {
        return Input.GetButton("Xbox_RightBump");
    }
    public static bool Xbox_RightBumpDown() {
        return Input.GetButtonDown("Xbox_RightBump");
    }
    public static bool Xbox_RightBumpUp() {
        return Input.GetButtonUp("Xbox_RightBump");
    }

    // Triggers
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

    // Face buttons
    public static bool Xbox_AButtonHold() {
        return Input.GetButton("Xbox_AButton");
    }
    public static bool Xbox_AButtonDown() {
        return Input.GetButtonDown("Xbox_AButton");
    }
    public static bool Xbox_AButtonUp() {
        return Input.GetButtonUp("Xbox_AButton");
    }

    public static bool Xbox_BButtonHold() {
        return Input.GetButton("Xbox_BButton");
    }
    public static bool Xbox_BButtonDown() {
        return Input.GetButtonDown("Xbox_BButton");
    }
    public static bool Xbox_BButtonUp() {
        return Input.GetButtonUp("Xbox_BButton");
    }

    public static bool Xbox_XButtonHold() {
        return Input.GetButton("Xbox_XButton");
    }
    public static bool Xbox_XButtonDown() {
        return Input.GetButtonDown("Xbox_XButton");
    }
    public static bool Xbox_XButtonUp() {
        return Input.GetButtonUp("Xbox_XButton");
    }

    public static bool Xbox_YButtonHold() {
        return Input.GetButton("Xbox_YButton");
    }
    public static bool Xbox_YButtonDown() {
        return Input.GetButtonDown("Xbox_YButton");
    }
    public static bool Xbox_YButtonUp() {
        return Input.GetButtonUp("Xbox_YButton");
    }

    // Extra / Options buttons
    public static bool Xbox_BackButtonHold() {
        return Input.GetButton("Xbox_StartButton");
    }
    public static bool Xbox_BackButtonDown() {
        return Input.GetButtonDown("Xbox_StartButton");
    }
    public static bool Xbox_BackButtonUp() {
        return Input.GetButtonUp("Xbox_StartButton");
    }

    public static bool Xbox_StartButtonHold() {
        return Input.GetButton("Xbox_StartButton");
    }
    public static bool Xbox_StartButtonDown() {
        return Input.GetButtonDown("Xbox_StartButton");
    }
    public static bool Xbox_StartButtonUp() {
        return Input.GetButtonUp("Xbox_StartButton");
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
    public static bool PlayStation_LeftStickHold() {
        return Input.GetButton("PlayStation_LeftStick");
    }
    public static bool PlayStation_LeftStickDown() {
        return Input.GetButtonDown("PlayStation_LeftStick");
    }
    public static bool PlayStation_LeftStickUp() {
        return Input.GetButtonUp("PlayStation_LeftStick");
    }

    public static bool PlayStation_RightStickHold() {
        return Input.GetButton("PlayStation_RightStick");
    }
    public static bool PlayStation_RightStickDown() {
        return Input.GetButtonDown("PlayStation_RightStick");
    }
    public static bool PlayStation_RightStickUp() {
        return Input.GetButtonUp("PlayStation_RightStick");
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

    // Sholder / Bumper buttons
    public static bool PlayStation_LeftBumpHold() {
        return Input.GetButton("PlayStation_LeftBump");
    }
    public static bool PlayStation_LeftBumpDown() {
        return Input.GetButtonDown("PlayStation_LeftBump");
    }
    public static bool PlayStation_LeftBumpUp() {
        return Input.GetButtonUp("PlayStation_LeftBump");
    }

    public static bool PlayStation_RightBumpHold() {
        return Input.GetButton("PlayStation_RightBump");
    }
    public static bool PlayStation_RightBumpDown() {
        return Input.GetButtonDown("PlayStation_RightBump");
    }
    public static bool PlayStation_RightBumpUp() {
        return Input.GetButtonUp("PlayStation_RightBump");
    }

    // Triggers
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

    // Face buttons
    public static bool PlayStation_SButtonHold() {
        return Input.GetButton("PlayStation_SButton");
    }
    public static bool PlayStation_SButtonDown() {
        return Input.GetButtonDown("PlayStation_SButton");
    }
    public static bool PlayStation_SButtonUp() {
        return Input.GetButtonUp("PlayStation_SButton");
    }

    public static bool PlayStation_XButtonHold() {
        return Input.GetButton("PlayStation_XButton");
    }
    public static bool PlayStation_XButtonDown() {
        return Input.GetButtonDown("PlayStation_XButton");
    }
    public static bool PlayStation_XButtonUp() {
        return Input.GetButtonUp("PlayStation_XButton");
    }

    public static bool PlayStation_OButtonHold() {
        return Input.GetButton("PlayStation_OButton");
    }
    public static bool PlayStation_OButtonDown() {
        return Input.GetButtonDown("PlayStation_OButton");
    }
    public static bool PlayStation_OButtonUp() {
        return Input.GetButtonUp("PlayStation_OButton");
    }

    public static bool PlayStation_TButtonHold() {
        return Input.GetButton("PlayStation_TButton");
    }
    public static bool PlayStation_TButtonDown() {
        return Input.GetButtonDown("PlayStation_TButton");
    }
    public static bool PlayStation_TButtonUp() {
        return Input.GetButtonUp("PlayStation_TButton");
    }

    // Extra / Options buttons
    public static bool PlayStation_ShareButtonHold() {
        return Input.GetButton("PlayStation_ShareButton");
    }
    public static bool PlayStation_ShareButtonDown() {
        return Input.GetButtonDown("PlayStation_ShareButton");
    }
    public static bool PlayStation_ShareButtonUp() {
        return Input.GetButtonUp("PlayStation_ShareButton");
    }

    public static bool PlayStation_OptionsButtonHold() {
        return Input.GetButton("PlayStation_OptionsButton");
    }
    public static bool PlayStation_OptionsButtonDown() {
        return Input.GetButtonDown("PlayStation_OptionsButton");
    }
    public static bool PlayStation_OptionsButtonUp() {
        return Input.GetButtonUp("PlayStation_OptionsButton");
    }

    public static bool PlayStation_HomeButtonHold() {
        return Input.GetButton("PlayStation_HomeButton");
    }
    public static bool PlayStation_HomeButtonDown() {
        return Input.GetButtonDown("PlayStation_HomeButton");
    }
    public static bool PlayStation_HomeButtonUp() {
        return Input.GetButtonUp("PlayStation_HomeButton");
    }
    #endregion
}