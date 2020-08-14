using System;
using UnityEngine;

/// <summary>
/// This script is left empty, it is only used for the attribute name.
/// </summary>

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class EnumFlagsAttribute : PropertyAttribute {
    public EnumFlagsAttribute() { }
}
