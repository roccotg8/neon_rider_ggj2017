using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawnFunctions : MonoBehaviour {

    // Just spawns a single bullet at the given position.
    public static void spawnBasic(BulletProperties spawnProperties, Transform basePosition, Arguments args) {
        GameObject bullet = Instantiate(Resources.Load("BulletPrefab"), basePosition) as GameObject;
        Bullet bulletScr = bullet.GetComponent<Bullet>();
        bulletScr.myProperties = spawnProperties;
        bulletScr.Init();
    }

    // Spawns a ring/arc of bullets
    // Uses arguments:
    //      -- arg0: number of bullets (default 18)
    //      -- arg1: radius of circle (default 1)
    //      -- arg2: min arc angle (default 0)
    //      -- arg3: max arc angle (default 360)
    public static void spawnCircle(BulletProperties spawnProperties, Transform basePosition, Arguments args) {
        int numBuls = 18;
        if (args.definedArgs > 0)
            numBuls = (int)args.arg0;
        double radius = 1;
        if (args.definedArgs > 1)
            radius = args.arg1;
        double minarc = 0;
        if (args.definedArgs > 2)
            minarc = args.arg2;
        double maxarc = 360;
        if (args.definedArgs > 3)
            maxarc = args.arg3;

        double degreesPerBul = (maxarc - minarc) / (double)numBuls;

        for (int i = 0; i < numBuls; i++) {
            double myAngle = minarc + degreesPerBul * i;
            Vector3 spawnPos = new Vector3((float)(basePosition.position.x + radius * Mathf.Cos((float)(myAngle * Mathf.Deg2Rad))),
                (float)(basePosition.position.x + radius * Mathf.Sin((float)(myAngle * Mathf.Deg2Rad))), 0);
            
            GameObject bullet = Instantiate(Resources.Load("BulletPrefab"), spawnPos, Quaternion.identity) as GameObject;
            Bullet bulletScr = bullet.GetComponent<Bullet>();
            bulletScr.myProperties = spawnProperties;
            bulletScr.Init();
            bulletScr.rotateController.setValue(myAngle);
        }
    }

}
