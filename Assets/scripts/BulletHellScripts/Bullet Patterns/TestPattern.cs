using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : BulletEmitterGroup {

    public Sprite bullet1Sprite;
    public Sprite bullet2Sprite;

	// Use this for initialization
	void Start () {
        // Circular pattern
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(0.08));
        ValueUpdatePVA bulletRotMotion = new ValueUpdatePVA(null, new RangeValue(1.5));
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(75);
        myBullet.myImage = bullet1Sprite;
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnCircle);
        emit.spawnMethodParams = new Arguments(18, 0.5);
        emit.timePerEmit = new RangeValue(10);

        // Random pattern
        ValueUpdatePVA bullet2YMotion = new ValueUpdatePVA(null, new RangeValue(-0.12, 0.12));
        ValueUpdatePVA bullet2XMotion = new ValueUpdatePVA(null, new RangeValue(-0.12, 0.12));
        ValueUpdatePVA bullet2RotMotion = new ValueUpdatePVA(null);
        BulletProperties myBullet2 = new BulletProperties(bullet2XMotion, bullet2YMotion, bullet2RotMotion);
        myBullet2.timeToLiveBullet = new RangeValue(120);
        myBullet2.myImage = bullet2Sprite;
        BulletEmitter emit2 = new BulletEmitter(myBullet2, BulletSpawnFunctions.spawnBasic);
        emit2.timePerEmit = new RangeValue(1, 5);

        addEmitter(emit);
        addEmitter(emit2);
	}
}
