using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsLine : BulletEmitterGroup {
    public Sprite bulletSprite;
    public GameObject targetObject;

    public double bulletSpeed = 0.08;
    public double bulletExpiryTime = 50;
    public RangeValue shootingFrequency = new RangeValue(100);
    public int timeToKeepAttacking = -1; // -1: this pattern will continue forever
    public int damage = 1;
    public int numBullets = 12;
    public int lineSpacing = 2;

    // Use this for initialization
    void Start() {
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(bulletSpeed));
        ValueUpdatePVA bulletPRotMotion = new ValueUpdatePVA(null);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue(bulletExpiryTime);
        myPBullet.myImage = bulletSprite;
        myPBullet.damage = damage;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnBasic);
        emitP.timePerEmit = new RangeValue(lineSpacing);
        emitP.timeToLive = new RangeValue(numBullets*lineSpacing);

        // Rotation Control Parent
        ValueUpdatePVA controlYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlXMotion = new ValueUpdatePVA(null);
        ValueUpdateHoming controlRotMotion = new ValueUpdateHoming(targetObject, false);
        BulletProperties myControlBullet = new BulletProperties(controlXMotion, controlYMotion, controlRotMotion);
        myControlBullet.timeToLiveBullet = new RangeValue(numBullets*lineSpacing);
        myControlBullet.childEmitter = emitP;
        BulletEmitter emitControl = new BulletEmitter(myControlBullet, BulletSpawnFunctions.spawnBasic);
        emitControl.timePerEmit = shootingFrequency;
        emitControl.timeToLive = new RangeValue(timeToKeepAttacking);

        addEmitter(emitControl);
    }
}
