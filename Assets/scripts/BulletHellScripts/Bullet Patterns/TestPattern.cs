using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : BulletEmitterGroup {

	// Use this for initialization
	void Start () {
        BulletMovePVA bulletMotion = new BulletMovePVA(null, null
            , new RangeValue(-0.04, 0.04), new RangeValue(-0.04, 0.04)
            , new RangeValue(-0.001, 0.001), new RangeValue(-0.001, 0.001));
        BulletProperties myBullet = new BulletProperties(bulletMotion);
        myBullet.timeToLiveBullet = new RangeValue(30);
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnBasic, gameObject);
        emit.timePerEmit = new RangeValue(10, 40);

        addEmitter(emit);
	}
}
