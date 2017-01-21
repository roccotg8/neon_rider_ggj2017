using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just spawns a single bullet at the given position.
public class BulletSpawnBasic : BulletSpawnInterface {

    public new void spawnBullets(BulletProperties spawnProperties, Transform basePosition) {
        GameObject bullet = Instantiate(Resources.Load("BulletPrefab"), basePosition) as GameObject;
        Bullet bulletScr = bullet.GetComponent<Bullet>();
        bulletScr.myProperties = spawnProperties;
        bulletScr.Init();
    }

}
