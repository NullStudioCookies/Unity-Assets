using UnityEditor;
using UnityEngine;

/// <summary>
/// This script uses the Unity Editor MinMaxSlider
/// for the MinMaxRange attribute. This attribute will
/// only work for either Vector2 or Vector2Int.
/// </summary>

[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
public class MinMaxRangePropertyDrawer : PropertyDrawer {
    const string MinName = "X";
    const string MaxName = "Y";
    const float FieldWidth = 30.0f;
    const float Spacing = 2.0f;
    const float RoundValue = 100.0f;

    #region Setting up the MinMax Range/Slider
    bool SetVectorValues(SerializedProperty property, float minValue, float maxValue) {
        if (property.propertyType == SerializedPropertyType.Vector2) {
            minValue = Rounding(minValue, RoundValue);
            maxValue = Rounding(maxValue, RoundValue);
            property.vector2Value = new Vector2(minValue, maxValue);
        }
        else if (property.propertyType == SerializedPropertyType.Vector2Int) {
            property.vector2IntValue = new Vector2Int((int)minValue, (int)maxValue);
        }
        else {
            return false;
        }

        return true;
    }

    float Rounding(float value, float roundingValue) {
        if (roundingValue == 0) {
            return value;
        }

        return Mathf.Round(value * roundingValue) / RoundValue;
    }
    #endregion

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // Reference to values from "MinMaxRangeAttribute"
        MinMaxRangeAttribute MinMax = (MinMaxRangeAttribute)attribute;

        float StartingMin = 0f;
        float StartingMax = 0f;

        // Checks for the proper data type
        if (property.propertyType == SerializedPropertyType.Vector2) {
            var AttributeValue = property.vector2Value;
            StartingMin = AttributeValue.x;
            StartingMax = AttributeValue.y;
        }
        else if (property.propertyType == SerializedPropertyType.Vector2Int) {
            var AttributeValue = property.vector2IntValue;
            StartingMin = AttributeValue.x;
            StartingMax = AttributeValue.y;
        }
        else {
            var AttributeValue = new GUIContent("Please use either Vector2 or Vector2Int");
            EditorGUI.LabelField(position, label, AttributeValue);
            return;
        }

        #region Creating the slider
        float PixelPoint = EditorGUIUtility.pixelsPerPoint;
        float Space = Spacing * PixelPoint;
        float Width = FieldWidth * PixelPoint;

        var indent = EditorGUI.indentLevel;

        var temp = EditorGUI.PrefixLabel(position, label);

        Rect sliderPos = temp;

        sliderPos.x += Width + Space;
        sliderPos.width -= (Width + Space) * 2;

        EditorGUI.BeginChangeCheck();
        EditorGUI.indentLevel = 0;
        EditorGUI.MinMaxSlider(sliderPos, ref StartingMin, ref StartingMax, MinMax.min, MinMax.max);
        EditorGUI.indentLevel = indent;
        if (EditorGUI.EndChangeCheck()) {
            SetVectorValues(property, StartingMin, StartingMax);
        }

        // Number box on the left
        Rect minPos = temp;
        minPos.width = Width;

        var vectorMinProp = property.FindPropertyRelative(MinName);
        EditorGUI.BeginChangeCheck();
        EditorGUI.indentLevel = 0;
        StartingMin = EditorGUI.DelayedFloatField(minPos, StartingMin);
        EditorGUI.indentLevel = indent;
        if (EditorGUI.EndChangeCheck()) {
            StartingMin = Mathf.Max(StartingMin, MinMax.min);
            StartingMax = Mathf.Min(StartingMin, StartingMax);
            SetVectorValues(property, StartingMin, StartingMax);
        }

        // Number box on the right
        Rect maxPos = position;
        maxPos.x += maxPos.width - Width;
        maxPos.width = Width;

        var vectorMaxProp = property.FindPropertyRelative(MaxName);
        EditorGUI.BeginChangeCheck();
        EditorGUI.indentLevel = 0;
        StartingMax = EditorGUI.DelayedFloatField(maxPos, StartingMax);
        EditorGUI.indentLevel = indent;
        if (EditorGUI.EndChangeCheck()) {
            StartingMax = Mathf.Min(StartingMax, MinMax.max);
            StartingMax = Mathf.Max(StartingMax, StartingMin);
            SetVectorValues(property, StartingMin, StartingMax);
        }

        EditorGUI.showMixedValue = false;
        #endregion
    }
}