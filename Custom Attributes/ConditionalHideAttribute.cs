using System;
using UnityEngine;

/// <summary>
/// This script allows to hide/show, enable or disable variables
/// based on another variable's value.
/// </summary>

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | 
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
    public string ConditionalSourceField = "";
    public bool HideInInspector = false;

    public ConditionalHideAttribute(string conditionalSourceField) {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = false;
    }

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector) {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
    }
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalEnumHideAttribute : PropertyAttribute {
    public string ConditionalSourceField = "";

    public int EnumValue1 = 0;
    public int EnumValue2 = 0;

    public bool HideInInspector = false;
    public bool Inverse = false;

    public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1) {
        this.ConditionalSourceField = conditionalSourceField;
        this.EnumValue1 = enumValue1;
        this.EnumValue2 = enumValue1;
    }

    public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1, int enumValue2) {
        this.ConditionalSourceField = conditionalSourceField;
        this.EnumValue1 = enumValue1;
        this.EnumValue2 = enumValue2;
    }
}
