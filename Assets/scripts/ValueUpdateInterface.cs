using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To be inherited by actions which manipulate a value over time.
public abstract class ValueUpdateInterface {

    public abstract double getValue();
    public abstract void FixedUpdate();
    public abstract ValueUpdateInterface getClone();

}
