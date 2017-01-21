using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : BulletEmitterGroup {

	// Use this for initialization
	void Start () {
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null, new RangeValue(0.08));
        ValueUpdatePVA bulletRotMotion = new ValueUpdatePVA(new RangeValue(0, 360), new RangeValue(2));
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(75);
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnBasic, gameObject);
        emit.timePerEmit = new RangeValue(2, 10);

        addEmitter(emit);
	}
}
