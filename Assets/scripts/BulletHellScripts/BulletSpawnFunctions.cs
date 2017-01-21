using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawnFunctions : MonoBehaviour {

    // Just spawns a single bullet at the given position.
    public static void spawnBasic(BulletProperties spawnProperties, Transform basePosition) {
        GameObject bullet = Instantiate(Resources.Load("BulletPrefab"), basePosition) as GameObject;
        Bullet bulletScr = bullet.GetComponent<Bullet>();
        bulletScr.myProperties = spawnProperties;
        bulletScr.Init();
    }

}
