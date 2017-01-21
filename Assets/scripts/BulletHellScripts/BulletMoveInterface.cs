using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To be inherited by actions which control bullet movement
public class BulletMoveInterface {

    public double getXOff() {
        return 0;
    }

    public double getYOff() {
        return 0;
    }

    public void FixedUpdate() {

    }

    public BulletMoveInterface getClone() {
        return null;
    }

}
