using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public BulletProperties myProperties;
    public BulletMoveInterface personalMoveController;
    public Vector3 spawnPosition; // Where the bullet first spawned from. All motion control will be relative to this point.

    private int lifeTime = 0;
    private int totalLifeTime = -1;
    private double relX = 0; // current position relative to the spawn point
    private double relY = 0;

    public void Init () {
        spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        if (myProperties.timeToLiveBullet != null)
            totalLifeTime = (int)myProperties.timeToLiveBullet.getValue();
        personalMoveController = myProperties.bulletMotion.getClone();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        lifeTime += 1;
        if (totalLifeTime > 0 && lifeTime >= totalLifeTime)
            Destroy(gameObject);

        personalMoveController.FixedUpdate();
        relX = personalMoveController.getXOff();
        relY = personalMoveController.getYOff();
        Vector3 newPosition = new Vector3();
        newPosition.x = (float)(spawnPosition.x + relX);
        newPosition.y = (float)(spawnPosition.y + relY);
        gameObject.transform.position = newPosition;
    }
}
