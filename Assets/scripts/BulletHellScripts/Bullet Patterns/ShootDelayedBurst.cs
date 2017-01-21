using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDelayedBurst : BulletEmitterGroup {

    public Sprite bullet1Sprite;
    public Sprite bullet2Sprite;
    public int damage;
    public int numberOfBulletsInBurst = 16;
    public int timeBetweenAttacks = 100;
    public int totalAttackTime = -1;
    public int bulletExpiryTime = 60;
    public double bulletExitSpeed = 0.04;
    public double bulletBurstSpeed = 0.06;
    public int delayBeforeBurst = 60;
    public RangeValue possibleShootAngles = new RangeValue(180);

    // Use this for initialization
    void Start () {
        // Child Burst
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(bulletBurstSpeed));
        ValueUpdatePVA bulletRotMotion = new ValueUpdatePVA(null);
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(bulletExpiryTime);
        myBullet.myImage = bullet2Sprite;
        myBullet.damage = damage;
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnCircle);
        emit.spawnMethodParams = new Arguments(numberOfBulletsInBurst, 0);
        emit.timePerEmit = new RangeValue(delayBeforeBurst);
        emit.timeToLive = new RangeValue(delayBeforeBurst+1);

        // Parent Single Shot Before Burst
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(bulletExitSpeed));
        ValueUpdatePVA bulletPRotMotion = new ValueUpdatePVA(possibleShootAngles);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue(delayBeforeBurst);
        myPBullet.myImage = bullet1Sprite;
        myPBullet.childEmitter = emit;
        myPBullet.damage = damage;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnBasic);
        emitP.timePerEmit = new RangeValue(delayBeforeBurst);
        emitP.timeToLive = new RangeValue(delayBeforeBurst+1);

        // Rotation Control Parent
        ValueUpdatePVA controlYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlXMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlRotMotion = new ValueUpdatePVA(possibleShootAngles);
        BulletProperties myControlBullet = new BulletProperties(controlXMotion, controlYMotion, controlRotMotion);
        myControlBullet.timeToLiveBullet = new RangeValue(delayBeforeBurst+1);
        myControlBullet.childEmitter = emitP;
        BulletEmitter emitControl = new BulletEmitter(myControlBullet, BulletSpawnFunctions.spawnBasic);
        emitControl.timePerEmit = new RangeValue(timeBetweenAttacks);
        emitControl.timeToLive = new RangeValue(totalAttackTime);

        addEmitter(emitControl);
    }
}
