using UnityEngine;
using System;
using System.Collections;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute {
    //The name of the bool field that will be in control
    public string ConditionalSourceField = "";
    //TRUE = Hide in inspector / FALSE = Disable in inspector 
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
    //The name of the bool field that will be in control
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