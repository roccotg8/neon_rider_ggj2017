using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsWave : BulletEmitterGroup {
    public Sprite bulletSprite;
    public GameObject targetObject;

    public double bulletSpeed = 0.08;
    public int shootingFrequency = 100;
    public int timeToKeepAttacking = -1; // -1: this pattern will continue forever
    public double arcDegrees = 45;
    public double arcRadius = 0.5;
    public int numBullets = 6;
    public int damage = 1;

    // Use this for initialization
    void Start() {
        // Arc Pattern
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(bulletSpeed));
        ValueUpdatePVA bulletPRotMotion = new ValueUpdatePVA(null);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue(100);
        myPBullet.myImage = bulletSprite;
        myPBullet.damage = damage;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnCircle);
        emitP.spawnMethodParams = new Arguments(numBullets, arcRadius, -(arcDegrees/2), (arcDegrees/2));
        emitP.timePerEmit = new RangeValue(5);
        emitP.timeToLive = new RangeValue(6);

        // Rotation Control Parent
        ValueUpdatePVA controlYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlXMotion = new ValueUpdatePVA(null);
        ValueUpdateHoming controlRotMotion = new ValueUpdateHoming(targetObject, false);
        BulletProperties myControlBullet = new BulletProperties(controlXMotion, controlYMotion, controlRotMotion);
        myControlBullet.timeToLiveBullet = new RangeValue(10);
        myControlBullet.childEmitter = emitP;
        BulletEmitter emitControl = new BulletEmitter(myControlBullet, BulletSpawnFunctions.spawnBasic);
        emitControl.timePerEmit = new RangeValue(shootingFrequency);
        emitControl.timeToLive = new RangeValue(timeToKeepAttacking);

        addEmitter(emitControl);
    }
}
