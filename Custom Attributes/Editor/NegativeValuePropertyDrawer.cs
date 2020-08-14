using UnityEditor;
using UnityEngine;

/// <summary>
/// The logic of the attribute "AbsoluteValue" is simple.
/// it just checks if its a integer, float or somthing else.
/// It will simply make any positive number and multiplying
/// it with a -1.
/// </summary>


[CustomPropertyDrawer(typeof(NegativeValueAttribute))]
public class NegativeValuePropertyDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if (property.propertyType == SerializedPropertyType.Integer) {
            if (property.intValue > 0) {
                property.intValue *= -1;
            }

            property.intValue = EditorGUI.IntField(position, label, property.intValue);
        }
        else if (property.propertyType == SerializedPropertyType.Float) {
            if (property.floatValue > 0) {
                property.floatValue *= -1;
            }

            property.floatValue = EditorGUI.FloatField(position, label, property.floatValue);
        }
        else {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
