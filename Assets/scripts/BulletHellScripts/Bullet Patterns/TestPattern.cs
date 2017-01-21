using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : BulletEmitterGroup {

	// Use this for initialization
	void Start () {
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(0.08));
        ValueUpdatePVA bulletRotMotion = new ValueUpdatePVA(null, new RangeValue(1.5));
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(75);
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnCircle, gameObject);
        emit.spawnMethodParams = new Arguments(18, 0.5);
        emit.timePerEmit = new RangeValue(10);

        addEmitter(emit);
	}
}
