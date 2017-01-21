using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For rotation only
public class ValueUpdateHoming : ValueUpdateInterface {
    private GameObject myTargetObject = null;
    public GameObject mySourceObject = null;

    private double my_rot = 0;
    private bool continuous;
    private bool initialized = false;

    // continuous_mode = True: This will constantly home into the target.
    // continuous_mode = False: This will only point at the target once at spawn.
    public ValueUpdateHoming(GameObject target, bool continuous_mode) {
        myTargetObject = target;
        continuous = continuous_mode;
    }

    public override void FixedUpdate() {
        return;
    }

    public override ValueUpdateInterface getClone() {
        return new ValueUpdateHoming(myTargetObject, continuous);
    }

    public override double getValue() {
        if (myTargetObject != null && mySourceObject != null) {
            if (continuous || (!continuous && !initialized)) {
                my_rot = Mathf.Atan2(myTargetObject.transform.position.y - mySourceObject.transform.position.y
                    , myTargetObject.transform.position.x - mySourceObject.transform.position.x) * Mathf.Rad2Deg;
                initialized = true;
            }
        }
        return my_rot;
    }

    public override void setValue(double value) {
        my_rot += value;
    }
}
