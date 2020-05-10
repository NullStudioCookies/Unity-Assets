using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// The logic of the attribute "AbsoluteValue" is simple.
/// it just checks if its a integer, float or somthing else.
/// It will simply make any negative number into positive using
/// Mathf.abs.
/// </summary>

[CustomPropertyDrawer(typeof(AbsoluteValueAttribute))]
public class AbsoluteValuePropertyDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if (property.propertyType == SerializedPropertyType.Integer) {
            property.intValue = Mathf.Abs(EditorGUI.IntField(position, label, property.intValue));
        }
        else if (property.propertyType == SerializedPropertyType.Float) {
            property.floatValue = Mathf.Abs(EditorGUI.FloatField(position, label, property.floatValue));
        }
        else {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
