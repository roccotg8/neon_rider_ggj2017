using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To be inherited by actions which control bullet movement
public abstract class BulletMoveInterface {

    public abstract double getXOff();
    public abstract double getYOff();
    public abstract void FixedUpdate();
    public abstract BulletMoveInterface getClone();

}
