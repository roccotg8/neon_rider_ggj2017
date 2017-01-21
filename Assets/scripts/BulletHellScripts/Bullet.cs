using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public BulletProperties myProperties;
    public BulletEmitter myChildEmitter = null;
    public ValueUpdateInterface xController;
    public ValueUpdateInterface yController;
    public ValueUpdateInterface rotateController;

    private int lifeTime = 0;
    private int totalLifeTime = -1;
    private double relX = 0; // current position relative to the spawn point
    private double relY = 0;
    private double lastRelX = 0;
    private double lastRelY = 0;
    private double relRot = 0;

    public void Init () {
        if (myProperties.timeToLiveBullet != null)
            totalLifeTime = (int)myProperties.timeToLiveBullet.getValue();
        xController = myProperties.xMotion.getClone();
        yController = myProperties.yMotion.getClone();
        rotateController = myProperties.rotMotion.getClone();
        SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
        if (myProperties.myImage != null)
            render.sprite = myProperties.myImage;
        else
            render.enabled = false;
        if (myProperties.childEmitter != null)
            myChildEmitter = myProperties.childEmitter.clone();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        lifeTime += 1;
        if (totalLifeTime > 0 && lifeTime >= totalLifeTime)
            Destroy(gameObject);

        xController.FixedUpdate();
        yController.FixedUpdate();
        rotateController.FixedUpdate();
        relX = xController.getValue();
        relY = yController.getValue();
        double deltaX = relX - lastRelX;
        double deltaY = relY - lastRelY;
        relRot = Mathf.Deg2Rad * rotateController.getValue();
        double cs = Mathf.Cos((float)relRot);
        double sn = Mathf.Sin((float)relRot);
        double rotDeltaX = deltaX * cs - deltaY * sn;
        double rotDeltaY = deltaX * sn + deltaY * cs;

        Vector3 newPosition = new Vector3();
        newPosition.x = (float)(gameObject.transform.position.x + rotDeltaX);
        newPosition.y = (float)(gameObject.transform.position.y + rotDeltaY);
        lastRelX = relX;
        lastRelY = relY;

        // Have bullets face the direction they are moving.
        Vector3 diff = newPosition - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        gameObject.transform.position = newPosition;

        if (myChildEmitter != null) {
            myChildEmitter.FixedUpdate();
            myChildEmitter.setEmitPosition(gameObject.transform.position);
            myChildEmitter.setEmitRotation(rotateController.getValue());
        }
    }
}
