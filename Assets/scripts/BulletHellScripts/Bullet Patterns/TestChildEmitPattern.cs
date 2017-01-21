using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChildEmitPattern : BulletEmitterGroup {

    public Sprite bullet1Sprite;
    public Sprite bullet2Sprite;

    // Use this for initialization
    void Start () {
        // Child Cross Pattern
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(0.06));
        ValueUpdatePVA bulletRotMotion = new ValueUpdatePVA(null);
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(30);
        myBullet.myImage = bullet2Sprite;
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnCircle);
        emit.spawnMethodParams = new Arguments(4, 0);
        emit.timePerEmit = new RangeValue(60);

        // Parent Cross Pattern
        ValueUpdatePVA bulletPYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletPXMotion = new ValueUpdatePVA(null, new RangeValue(0.04));
        ValueUpdatePVA bulletPRotMotion = new ValueUpdatePVA(null);
        BulletProperties myPBullet = new BulletProperties(bulletPXMotion, bulletPYMotion, bulletPRotMotion);
        myPBullet.timeToLiveBullet = new RangeValue(120);
        myPBullet.myImage = bullet1Sprite;
        myPBullet.childEmitter = emit;
        BulletEmitter emitP = new BulletEmitter(myPBullet, BulletSpawnFunctions.spawnCircle);
        emitP.spawnMethodParams = new Arguments(4, 0);
        emitP.timePerEmit = new RangeValue(60);

        // Rotation Control Parent
        ValueUpdatePVA controlYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlXMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA controlRotMotion = new ValueUpdatePVA(new RangeValue(0, 360));
        BulletProperties myControlBullet = new BulletProperties(controlXMotion, controlYMotion, controlRotMotion);
        myControlBullet.timeToLiveBullet = new RangeValue(60);
        myControlBullet.childEmitter = emitP;
        BulletEmitter emitControl = new BulletEmitter(myControlBullet, BulletSpawnFunctions.spawnBasic);
        emitControl.timePerEmit = new RangeValue(60);

        addEmitter(emitControl);
    }
}
