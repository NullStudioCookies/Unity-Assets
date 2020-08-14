using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script provides any information that the 
/// Gravity Manipulator script needs to apply the
/// physics upon object.
/// </summary>

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class GravityBody : MonoBehaviour {
    public bool EnableGravity = true;

    Rigidbody ObjectBody;
    Transform ObjectTransform;
    public List<GravityManipulator> GravityManipulators = new List<GravityManipulator>();

    // Start is called before the first frame update
    void Start() {
        ObjectBody = GetComponent<Rigidbody>();
        ObjectBody.useGravity = false;
        ObjectTransform = GetComponent<Transform>();
    }

    // Fixed Update is called during the physics update
    void FixedUpdate() {
        if (EnableGravity && GravityManipulators != null) {
            foreach (GravityManipulator manipulators in GravityManipulators) {
                manipulators.ApplyGravity(ObjectBody, ObjectTransform);
            }
        }
    }

    public void AddManipulator(GravityManipulator gravitySource) {
        if (!GravityManipulators.Contains(gravitySource)) {
            GravityManipulators.Add(gravitySource);
        }
    }

    public void RemoveManipulator(GravityManipulator gravitySource) {
        GravityManipulators.Remove(gravitySource);
    }
}