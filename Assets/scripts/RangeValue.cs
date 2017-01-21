using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangeValue {
    public double minValue;
    public double maxValue;

    public RangeValue() {
        minValue = 0;
        maxValue = 0;
    }

    public RangeValue(double value) {
        minValue = value;
        maxValue = value;
    }

    public RangeValue(double min, double max) {
        minValue = min;
        maxValue = max;
    }

    public void setMinMax(double min, double max) {
        minValue = min;
        maxValue = max;
    }

    public void setGauss(double mean, double deviation) {
        minValue = mean - deviation;
        maxValue = mean + deviation;
    }

    public double randValue(double baseValue) {
        return baseValue + Random.Range((float)minValue, (float)maxValue);
    }

    public double getValue() {
        return Random.Range((float)minValue, (float)maxValue);
    }
}
