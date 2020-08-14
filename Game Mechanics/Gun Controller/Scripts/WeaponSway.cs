using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script rotates and moves the weapon slightly when looking around.
/// </summary>

[DisallowMultipleComponent]
public class WeaponSway : MonoBehaviour {
    [HideInInspector] [SerializeField] Transform WeaponHolder = null;
    [ReadOnly] [HideInInspector] public GunProperties weaponProperties = null;
    [ReadOnly] [HideInInspector] public float X_Input = 0;
    [ReadOnly] [HideInInspector] public float Y_Input = 0;

    Vector3 InitialPosition;
    Quaternion InitialRotation;

    // Start is called before the first frame update
    void Start() {
        WeaponHolder = this.gameObject.transform.GetChild(0);
        InitialPosition = transform.localPosition;
        InitialRotation = WeaponHolder.transform.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate() {
        MovementSway();
        RotationSway();
    }

    void MovementSway() {
        float X_Movement = X_Input * weaponProperties.SwayAmount;
        float Y_Movement = Y_Input * weaponProperties.SwayAmount;
        X_Movement = Mathf.Clamp(X_Movement, -weaponProperties.MaxSwayAmount, weaponProperties.MaxSwayAmount);
        Y_Movement = Mathf.Clamp(Y_Movement, -weaponProperties.MaxSwayAmount, weaponProperties.MaxSwayAmount);

        Vector3 FinalPosition = new Vector3(X_Movement, Y_Movement, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, FinalPosition + InitialPosition, Time.deltaTime * weaponProperties.SmoothedSwayAmount);
    }

    void RotationSway() {
        float X_Tilt = Y_Input * weaponProperties.RotationAmount;
        float Y_Tilt = X_Input * weaponProperties.RotationAmount;
        X_Tilt = Mathf.Clamp(X_Tilt, -weaponProperties.MaxRotationAmount, weaponProperties.MaxRotationAmount);
        Y_Tilt = Mathf.Clamp(Y_Tilt, -weaponProperties.MaxRotationAmount, weaponProperties.MaxRotationAmount);

        Quaternion FinalRotation = Quaternion.Euler(new Vector3 (
            weaponProperties.RotationAxis.HasFlag(WeaponRotation.X) ? -X_Tilt : 0,
            weaponProperties.RotationAxis.HasFlag(WeaponRotation.Y) ? Y_Tilt : 0,
            weaponProperties.RotationAxis.HasFlag(WeaponRotation.Z) ? Y_Tilt : 0
            ));

        WeaponHolder.transform.localRotation = Quaternion.Slerp(WeaponHolder.transform.localRotation, FinalRotation * InitialRotation, Time.deltaTime * weaponProperties.smoothedRotaation);
    }
}