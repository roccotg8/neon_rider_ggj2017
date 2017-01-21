using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNonContHoming : BulletEmitterGroup {

    public Sprite bullet1Sprite;
    public Sprite bullet2Sprite;
    public GameObject targetObject;

    // Use this for initialization
    void Start () {
        // Child Homing Bullets
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(0.06));
        ValueUpdateHoming bulletRotMotion = new ValueUpdateHoming(targetObject, false);
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(60);
        myBullet.myImage = bullet2Sprite;
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnBasic);
        emit.timePerEmit = new RangeValue(30);

        // Parent Multi Line Shoot Pattern
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(0.04));
        ValueUpdatePVA bulletPRotMotion = new ValueUpdatePVA(null);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue(30);
        myPBullet.myImage = bullet1Sprite;
        myPBullet.childEmitter = emit;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnBasic);
        emitP.timePerEmit = new RangeValue(15);
        emitP.timeToLive = new RangeValue(90);

        // Rotation Control Parent
        ValueUpdatePVA controlYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlXMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlRotMotion = new ValueUpdatePVA(new RangeValue(0, 360));
        BulletProperties myControlBullet = new BulletProperties(controlXMotion, controlYMotion, controlRotMotion);
        myControlBullet.timeToLiveBullet = new RangeValue(180);
        myControlBullet.childEmitter = emitP;
        BulletEmitter emitControl = new BulletEmitter(myControlBullet, BulletSpawnFunctions.spawnBasic);
        emitControl.timePerEmit = new RangeValue(150);

        addEmitter(emitControl);
    }
}
