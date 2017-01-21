using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The highest level configuration object for spawning bullets. This script should not be attached to a game object, you should
// attach the BulletEmitterGroup script instead.
public class BulletEmitter {
    public RangeValue timeToLive = null; // How long this will emit for (null to emit forever)
    public RangeValue timePerEmit = new RangeValue(10);
    public delegate void SpawnFunction(BulletProperties spawnProperties, Transform basePosition, Arguments arg); // How should bullets be spawned when it is time to emit?
    SpawnFunction spawnMethod;
    public Arguments spawnMethodParams = new Arguments();
    public BulletProperties bulletType; // The properties of the bullet that should be spawned by this emitter.
    public GameObject parentObject; // The game object (enemy) that this emitter is being used by.

    private int lifeTime = 0;
    private int totalLifeTime = -1;
    private int emitTimer = 0;
    private int nextEmit = 0;

    public BulletEmitter(BulletProperties bulletType, SpawnFunction spawnMethod, GameObject parentObject) {
        this.bulletType = bulletType;
        this.spawnMethod = spawnMethod;
        this.parentObject = parentObject;
    }

    public void Init() {
        if (timeToLive != null)
            totalLifeTime = (int)timeToLive.getValue();
        nextEmit = (int)timePerEmit.getValue();
    }

    public void FixedUpdate() {
        // Stop emitting after time.
        lifeTime += 1;
        if (totalLifeTime > 0 && lifeTime >= totalLifeTime) { return; }

        // Emit bullet(s) after time.
        emitTimer += 1;
        if (emitTimer >= nextEmit) {
            spawnMethod(bulletType, parentObject.transform, spawnMethodParams);
            nextEmit = (int)timePerEmit.getValue();
            emitTimer = 0;
        }
    }
}
