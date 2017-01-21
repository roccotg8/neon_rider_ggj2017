using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLineHomingSplit : BulletEmitterGroup {

    public Sprite bullet1Sprite;
    public Sprite bullet2Sprite;
    public GameObject targetObject;
    public int damage;
    public int numberOfBullets;
    public int timePerBullet = 15;
    public int timeBetweenAttacks = 100;
    public int totalAttackTime = -1;
    public int bulletExpiryTime = 60;
    public double bulletSpreadSpeed = 0.04;
    public double bulletPierceSpeed = 0.06;
    public RangeValue possibleShootAngles = new RangeValue(0, 360);

    // Use this for initialization
    void Start () {
        // Child Homing Bullets
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(bulletPierceSpeed));
        ValueUpdateHoming bulletRotMotion = new ValueUpdateHoming(targetObject, false);
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(bulletExpiryTime);
        myBullet.myImage = bullet2Sprite;
        myBullet.damage = damage;
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnBasic);
        emit.timePerEmit = new RangeValue((numberOfBullets + 1) * timePerBullet - 1);

        // Parent Multi Line Shoot Pattern
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(bulletSpreadSpeed));
        ValueUpdatePVA bulletPRotMotion = new ValueUpdatePVA(null);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue((numberOfBullets + 1) * timePerBullet-1);
        myPBullet.myImage = bullet1Sprite;
        myPBullet.childEmitter = emit;
        myPBullet.damage = damage;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnBasic);
        emitP.timePerEmit = new RangeValue(timePerBullet);
        emitP.timeToLive = new RangeValue((numberOfBullets + 1) * timePerBullet);

        // Rotation Control Parent
        ValueUpdatePVA controlYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlXMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlRotMotion = new ValueUpdatePVA(possibleShootAngles);
        BulletProperties myControlBullet = new BulletProperties(controlXMotion, controlYMotion, controlRotMotion);
        myControlBullet.timeToLiveBullet = new RangeValue((numberOfBullets + 1) * timePerBullet+1);
        myControlBullet.childEmitter = emitP;
        BulletEmitter emitControl = new BulletEmitter(myControlBullet, BulletSpawnFunctions.spawnBasic);
        emitControl.timePerEmit = new RangeValue((numberOfBullets+1) * timePerBullet+timeBetweenAttacks);
        emitControl.timeToLive = new RangeValue(totalAttackTime);

        addEmitter(emitControl);
    }
}
