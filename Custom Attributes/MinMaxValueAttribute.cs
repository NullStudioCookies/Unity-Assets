using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script contains the attribute tags for the min and max value
/// validators. Each on takes 1 argument to set the limit for the 
/// variable.
/// </summary>

// This class does nothing
class MinMaxValueAttribute {
    
}

public class MinValueAttribute : PropertyAttribute {
    public float minValue { get; private set; }

    public MinValueAttribute(float MainVlaue) {
        minValue = MainVlaue;
    }

    public MinValueAttribute(int MinVlaue) {
        minValue = MinVlaue;
    }
}

public class MaxValueAttribute : PropertyAttribute {
    public float maxValue { get; private set; }

    public MaxValueAttribute(float MaxVlaue) {
        maxValue = MaxVlaue;
    }

    public MaxValueAttribute(int MaxVlaue) {
        maxValue = MaxVlaue;
    }
}