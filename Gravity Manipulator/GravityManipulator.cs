using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script manipulates the forces applied on any
/// game objects with the "GravityBody" script. The 
/// script will be dynamic enough to change both gravity
/// direction and force along with the effected area.
/// </summary>

enum Gravity { Directional, Spherical }
enum ForceAxis { X, Y, Z}
[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SphereCollider))]
public class GravityManipulator : MonoBehaviour {
    #region Gravity Manipulation Properties
    [Header("Gravity Settings")]
    [SerializeField] Gravity gravityType = Gravity.Directional;
    [SerializeField] float gravityForce = 9.81f;
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] bool limitedGravityArea = true;
    [Space(10)]
    [ConditionalEnumHide("gravityType", (int)Gravity.Directional)][SerializeField] ForceAxis gravityAxis = ForceAxis.Y;
    [ConditionalHide("limitedGravityArea", true)][SerializeField] DirectionalGravity directionalGravityProperties = null;
    [Space(10)]
    [ConditionalHide("limitedGravityArea", true)][SerializeField] SphericalGravity sphericalGravityProperties = null;

    [System.Serializable]
    class DirectionalGravity {
        [ConditionalEnumHide("gravityType", (int)Gravity.Directional)] public Vector3 gravitySize = new Vector3(1, 1, 1);
    }

    [System.Serializable]
    class SphericalGravity {
        [ConditionalEnumHide("gravityType", (int)Gravity.Spherical)] public float gravityRadius = 1;
    }

    GravityBody[] tempBodies;
    Vector3 GravityDirection;
    Vector3 ObjectUp;
    Quaternion ObjectRotation;

    [ExecuteInEditMode]
    void OnValidate() {
        // Ensures that the correct collider is enabled
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;

        if (gravityType == Gravity.Directional) {
            boxCollider.enabled = true;
            sphereCollider.enabled = false;
        }
        else {
            boxCollider.enabled = false;
            sphereCollider.enabled = true;
        }

        // Adjusting values for the colliders
        boxCollider.size = directionalGravityProperties.gravitySize;
        sphereCollider.radius = sphericalGravityProperties.gravityRadius;

        // Checking for any values under 0
        if (directionalGravityProperties.gravitySize.x < 0) {
            directionalGravityProperties.gravitySize.x = 0;
        }
        if (directionalGravityProperties.gravitySize.y < 0) {
            directionalGravityProperties.gravitySize.y = 0;
        }
        if (directionalGravityProperties.gravitySize.z < 0) {
            directionalGravityProperties.gravitySize.z = 0;
        }
        if (sphericalGravityProperties.gravityRadius < 0) {
            sphericalGravityProperties.gravityRadius = 0;
        }
    }
    #endregion

    // Late Update is called at the end of each frame
    void LateUpdate() {
        if (!limitedGravityArea) {
            // Finds every object with "GravityBody"
            tempBodies = FindObjectsOfType<GravityBody>();
            foreach (GravityBody i in tempBodies) {
                i.AddManipulator(this);
            }
        }
    }

    // This script will be called by the "GravityBody" 
    // script to apply gravitational force
    public void ApplyGravity(Rigidbody objectBody, Transform objectTransform) {
        switch (gravityType) {
            case Gravity.Directional:
                // Apply gravitational force by axis
                switch (gravityAxis) {
                    case ForceAxis.X:
                        objectBody.AddForce(objectTransform.right * -gravityForce);
                        break;
                    case ForceAxis.Y:
                        objectBody.AddForce(objectTransform.up * -gravityForce);
                        break;
                    case ForceAxis.Z:
                        objectBody.AddForce(objectTransform.forward * -gravityForce);
                        break;
                }

                // Rotate object to align with the gravity source
                objectTransform.rotation = Quaternion.Slerp(objectTransform.rotation, transform.localRotation, rotationSpeed * Time.deltaTime);
                break;

            case Gravity.Spherical:
                // Determine the direction of the gravity and object "up" direction
                GravityDirection = (objectTransform.position - transform.position).normalized;
                ObjectUp = objectTransform.up;

                // Apply gravity
                objectBody.AddForce(GravityDirection * -gravityForce);

                // Rotate the object based on the position realative to the gravity source
                ObjectRotation = Quaternion.FromToRotation(ObjectUp, GravityDirection) * objectTransform.rotation;
                objectTransform.rotation = Quaternion.Slerp(objectTransform.rotation, ObjectRotation, rotationSpeed * Time.deltaTime);
                break;
        }
    }

    // Change gravity force and or range
    public void ChangeGravityForce(float NewGravForce = 0) {
        gravityForce = NewGravForce;
    }
    public void ChangeGravityRangeBox(Vector3 BoxSize) {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = BoxSize;
    }
    public void ChangeGravityRangeSphere(float SphereRange) {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = SphereRange;
    }


    void OnTriggerEnter(Collider obj) {
        if (limitedGravityArea && obj.GetComponent<GravityBody>() != null) {
            obj.GetComponent<GravityBody>().AddManipulator(this);
        }
    }

    void OnTriggerExit(Collider obj) {
        obj.GetComponent<GravityBody>().RemoveManipulator(this);
    }
}