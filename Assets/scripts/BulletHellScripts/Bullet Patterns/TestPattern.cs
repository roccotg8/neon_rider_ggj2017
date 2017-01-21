using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : BulletEmitterGroup {

	// Use this for initialization
	void Start () {
        BulletMovePVA bulletMotion = new BulletMovePVA(null, null, new RangeValue(-4, 4), new RangeValue(-4, 4));
        BulletProperties myBullet = new BulletProperties(bulletMotion);
        myBullet.timeToLiveBullet = new RangeValue(30);
        BulletEmitter emit = new BulletEmitter(myBullet, new BulletSpawnBasic(), gameObject);
        emit.timePerEmit = new RangeValue(10, 40);

        addEmitter(emit);
	}
}
