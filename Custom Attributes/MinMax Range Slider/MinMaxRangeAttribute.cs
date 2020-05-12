using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is contains the attribute arguments for the
/// MinMaxRange Attribute. This attribute will only work for 
/// either Vector2 or Vector2Int.
/// </summary>

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class MinMaxRangeAttribute : PropertyAttribute {
    public readonly float min;
    public readonly float max;

    // Default values
    public MinMaxRangeAttribute() : this(0, 1) { }

    // Custom values
    public MinMaxRangeAttribute(float MinValue, float MaxValue) {
        min = MinValue;
        max = MaxValue;
    }
}