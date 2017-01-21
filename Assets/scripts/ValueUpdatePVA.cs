using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move by position, velocity, & acceleration ranges.
public class ValueUpdatePVA : ValueUpdateInterface {

    public RangeValue valOffset;
    public RangeValue valVelo;
    public RangeValue valAccel;

    private double cur_vo;
    private double cur_vv;
    private double cur_va;
	
    public ValueUpdatePVA(double val) {
        valOffset = new RangeValue(val);
        cur_vo = val;
    }

    public ValueUpdatePVA(double val, double valV) :
        this (val)  {
        valVelo = new RangeValue(valV);
        cur_vv = valV;
    }

    public ValueUpdatePVA(double val, double valV, double valA) :
        this (val, valV) {
        valAccel = new RangeValue(valA);
        cur_va = valA;
    }

    public ValueUpdatePVA(RangeValue val) {
        if (val == null)
            valOffset = new RangeValue();
        else
            valOffset = val;
        cur_vo = valOffset.getValue();
    }

    public ValueUpdatePVA(RangeValue val, RangeValue valV) :
        this(val) {
        if (valV == null)
            valVelo = new RangeValue();
        else
            valVelo = valV;
        cur_vv = valVelo.getValue();
    }

    public ValueUpdatePVA(RangeValue val, RangeValue valV, RangeValue valA) :
        this(val, valV) {
        if (valA == null)
            valAccel = new RangeValue();
        else
            valAccel = valA;
        cur_va = valAccel.getValue();
    }

    public override void FixedUpdate() {
        cur_vo += cur_vv;
        cur_vv += cur_va;
	}

    public override double getValue() {
        return cur_vo;
    }

    public override ValueUpdateInterface getClone() {
        return new ValueUpdatePVA(valOffset, valVelo, valAccel);
    }
}
