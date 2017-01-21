using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHomingMissile : BulletEmitterGroup {

    public Sprite bullet1Sprite;
    public GameObject targetObject;

    // Use this for initialization
    void Start () {
        ValueUpdatePVA bulletYMotion = new ValueUpdatePVA(null);
        ValueUpdatePVA bulletXMotion = new ValueUpdatePVA(null, new RangeValue(0.03));
        ValueUpdateHoming bulletRotMotion = new ValueUpdateHoming(targetObject, true);
        BulletProperties myBullet = new BulletProperties(bulletXMotion, bulletYMotion, bulletRotMotion);
        myBullet.timeToLiveBullet = new RangeValue(240);
        myBullet.myImage = bullet1Sprite;
        BulletEmitter emit = new BulletEmitter(myBullet, BulletSpawnFunctions.spawnBasic);
        emit.timePerEmit = new RangeValue(300);

        addEmitter(emit);
    }
}
