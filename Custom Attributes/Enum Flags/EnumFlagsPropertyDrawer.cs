using UnityEngine;
using UnityEditor;

/// <summary>
/// This script is the logic for creating a drop down field to
/// select multiple enum values.
/// </summary>

[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsPropertyDrawer : PropertyDrawer {
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label) {
        _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
    }
}
