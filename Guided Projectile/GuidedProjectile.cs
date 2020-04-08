using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GuidanceSystem { Controlled, Homing}
enum ForwardAxis { X_Axis, Y_Axis, Z_Axis}
[RequireComponent(typeof(Rigidbody))]
public class GuidedProjectile : MonoBehaviour {
    [SerializeField] GuidanceSystem GuidanceMethod;
    [Tooltip("This is used to set which way the projectile is facing.")][SerializeField] ForwardAxis ForwardDirection;
    [SerializeField][Range(0, 1)] float TurnRate = 0.5f;
    [Space(5)]
    [SerializeField] bool SetInitalVelocity = false;
    [ConditionalHide("SetInitalVelocity", true)][SerializeField] float ProjectileVelocity = 0;
    [SerializeField] bool Tracking = true;

    [Header("Control Guided Variables")][Space(5)]
    [ConditionalEnumHide("GuidanceMethod", (int)GuidanceSystem.Controlled)][SerializeField] string XInputAxis = null;
    [ConditionalEnumHide("GuidanceMethod", (int)GuidanceSystem.Controlled)][SerializeField] string YInputAxis = null;
    [ConditionalEnumHide("GuidanceMethod", (int)GuidanceSystem.Controlled)][SerializeField] float InputSensitivity = 0;
    [ConditionalEnumHide("GuidanceMethod", (int)GuidanceSystem.Controlled)][SerializeField] float InputSmoothing = 0;
    Vector3 SmoothVector, TargetDirection;

    Rigidbody ProjectileBody;
    public GameObject Target;

    [ExecuteInEditMode]
    void OnValidate() {
        if (ProjectileVelocity < 0) {
            ProjectileVelocity = 0;
        }
        if (InputSensitivity < 0) {
            InputSensitivity = 0;
        }
        if (InputSmoothing < 0) {
            InputSmoothing = 0;
        }
    }

    // Start is called before the first frame update
    void Start() {
        ProjectileBody = GetComponent<Rigidbody>();
        if (!SetInitalVelocity) {
            ProjectileVelocity = ProjectileBody.velocity.magnitude;
        }
        else {
            ApplyNewDirection(Quaternion.identity);
        }
    }

    void FixedUpdate() {
        if (Tracking) {
            switch (GuidanceMethod) {
                case GuidanceSystem.Controlled:
                    ControlProjectile();
                    break;
                case GuidanceSystem.Homing:
                    HomingTarget();
                    break;
            }
        }
    }

    void ControlProjectile() {
        var NewDirection = new Vector2(-Input.GetAxis(YInputAxis), Input.GetAxis(XInputAxis));

        NewDirection = Vector2.Scale(NewDirection, new Vector2(InputSensitivity * InputSmoothing, InputSensitivity * InputSmoothing));
        SmoothVector.x = Mathf.Lerp(SmoothVector.x, NewDirection.x, 1f / InputSmoothing);
        SmoothVector.y = Mathf.Lerp(SmoothVector.y, NewDirection.y, 1f / InputSmoothing);
        TargetDirection += SmoothVector;

        ApplyNewDirection(Quaternion.Euler(TargetDirection));
    }

    void HomingTarget() {
        Quaternion TargetDirection = Quaternion.LookRotation(Target.transform.position - this.transform.position);

        ApplyNewDirection(TargetDirection);
    }

    void ApplyNewDirection(Quaternion TargetRotation) {
        ProjectileBody.MoveRotation(Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnRate));

        switch (ForwardDirection) {
            case ForwardAxis.X_Axis:
                ProjectileBody.velocity = transform.right * ProjectileVelocity;
                break;
            case ForwardAxis.Y_Axis:
                ProjectileBody.velocity = transform.up * ProjectileVelocity;
                break;
            case ForwardAxis.Z_Axis:
                ProjectileBody.velocity = transform.forward * ProjectileVelocity;
                break;
        }
    }

    public void SetTarget(GameObject TargetObject = null) {
        Target = TargetObject;
    }

    public void EnableTracking() {

    }
}