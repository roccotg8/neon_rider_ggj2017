using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsSingle : BulletEmitterGroup {
    public Sprite bulletSprite;
    public GameObject targetObject;
 
    public bool homingMode = false;
    public double bulletSpeed = 0.08;
    public double bulletExpiryTime = 50;
    public RangeValue shootingFrequency = new RangeValue(100);
    public int timeToKeepAttacking = -1; // -1: this pattern will continue forever
    public int damage = 1;
 
    // Use this for initialization
    void Start() {
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(bulletSpeed));
        ValueUpdateHoming bulletPRotMotion = new ValueUpdateHoming(targetObject, homingMode);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue(bulletExpiryTime);
        myPBullet.myImage = bulletSprite;
        myPBullet.damage = damage;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnBasic);
        emitP.timePerEmit = shootingFrequency;
        emitP.timeToLive = new RangeValue(timeToKeepAttacking);
 
        addEmitter(emitP);
    }
}