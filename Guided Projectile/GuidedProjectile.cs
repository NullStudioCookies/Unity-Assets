using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GuidanceSystem { Controlled, Homing}
[RequireComponent(typeof(Rigidbody))]
public class GuidedProjectile : MonoBehaviour {
    [SerializeField] GuidanceSystem GuidanceMethod;
    [SerializeField][AbsoluteValue()] float TurnRate = 0;
    [SerializeField] bool SetInitalVelocity = false;
    [ConditionalHide("SetInitalVelocity", true)][SerializeField] float ProjectileVelocity = 0;

    [Header("Control guided variables")][Space(5)]
    [ConditionalEnumHide("GuidanceMethod", 0)][SerializeField] string XInputAxis;
    [ConditionalEnumHide("GuidanceMethod", 0)][SerializeField] string YInputAxis;
    [ConditionalEnumHide("GuidanceMethod", 0)][SerializeField] float InputSensitivity = 0;
    [ConditionalEnumHide("GuidanceMethod", 0)][SerializeField] float InputSmoothing = 0;
    Vector3 SmoothVector, TargetDirection;

    Rigidbody ProjectileBody;
    GameObject Target;

    // Start is called before the first frame update
    void Start() {
        ProjectileBody = GetComponent<Rigidbody>();
        if (!SetInitalVelocity) {
            ProjectileVelocity = ProjectileBody.velocity.magnitude;
        }
        else {
            ProjectileBody.velocity = ProjectileVelocity * Vector3.forward;
        }
    }

    // Fixed Update is called during the physics calculations
    void FixedUpdate() {
        switch (GuidanceMethod) {
            case GuidanceSystem.Controlled:
                ControlProjectile();
                break;
            case GuidanceSystem.Homing:
                HomingTarget();
                break;
        }
    }

    void ControlProjectile() {
        // Creating a direction based on the input
        var NewDirection = new Vector2(-Input.GetAxis(YInputAxis), Input.GetAxis(XInputAxis));

        NewDirection = Vector2.Scale(NewDirection, new Vector2(InputSensitivity * InputSmoothing, InputSensitivity * InputSmoothing));
        SmoothVector.x = Mathf.Lerp(SmoothVector.x, NewDirection.x, 1f / InputSmoothing);
        SmoothVector.y = Mathf.Lerp(SmoothVector.y, NewDirection.y, 1f / InputSmoothing);
        TargetDirection += SmoothVector;

        // Rotate projectil towards the new direction and appling force
        ProjectileBody.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(TargetDirection), TurnRate));
        ProjectileBody.velocity = transform.forward * ProjectileVelocity;
    }

    void HomingTarget() {
        // Rotate projectile towards the target and while applying force
        Quaternion TargetRotation = Quaternion.LookRotation(Target.transform.position - this.transform.position);
        ProjectileBody.MoveRotation(Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnRate));
        ProjectileBody.velocity = transform.forward * ProjectileVelocity;
    }

    // Logic for setting a target for homing guidence system
    public void SetTarget(GameObject TargetObject = null) {
        Target = TargetObject;
    }
}