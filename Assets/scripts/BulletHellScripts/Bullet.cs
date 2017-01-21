using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public BulletProperties myProperties;
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
        gameObject.transform.position = newPosition;
    }
}
