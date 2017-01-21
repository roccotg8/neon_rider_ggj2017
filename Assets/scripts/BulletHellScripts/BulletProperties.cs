using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties {
    public int damage; // How much damage this bullet will do to the player.
    public ValueUpdateInterface xMotion; // How the bullet should move.
    public ValueUpdateInterface yMotion; // How the bullet should move.
    public ValueUpdateInterface rotMotion; // How the bullet should rotate.
    public BulletEmitter childEmitter = null; // Should this bullet also emit bullets? If so, this defines the emission behavior.
    public RangeValue timeToLiveBullet = new RangeValue(10); // How long the bullet should stay in the scene for.

    public BulletProperties(ValueUpdateInterface horMethod, ValueUpdateInterface vertMethod, ValueUpdateInterface rotationMethod) {
        this.xMotion = horMethod;
        this.yMotion = vertMethod;
        this.rotMotion = rotationMethod;
    }
}
