using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The highest level configuration object for spawning bullets. This script should not be attached to a game object, you should
// attach the BulletEmitterGroup script instead.
public class BulletEmitter {
    public RangeValue timeToLive = null; // How long this will emit for (null to emit forever)
    public RangeValue timePerEmit = new RangeValue(10);
    public delegate void SpawnFunction(BulletProperties spawnProperties, Vector3 basePosition, double baseAngle, Arguments arg); // How should bullets be spawned when it is time to emit?
    SpawnFunction spawnMethod;
    public Arguments spawnMethodParams = new Arguments();
    public BulletProperties bulletType; // The properties of the bullet that should be spawned by this emitter.

    private Vector3 emissionPosition = new Vector3();
    private double emissionAngle = 0;
    private int lifeTime = 0;
    private int totalLifeTime = -1;
    private int emitTimer = 0;
    private int nextEmit = 0;
    private bool paused = false;

    public BulletEmitter(BulletProperties bulletType, SpawnFunction spawnMethod) {
        this.bulletType = bulletType;
        this.spawnMethod = spawnMethod;
    }

    public void Init() {
        lifeTime = 0;
        if (timeToLive != null)
            totalLifeTime = (int)timeToLive.getValue();
        nextEmit = (int)timePerEmit.getValue();
    }

    public void overwriteNextEmit(int next) {
        nextEmit = next;
    }

    public void setEmitPosition(Vector3 newPos) {
        emissionPosition = newPos;
    }

    public void setEmitRotation(double rot) {
        emissionAngle = rot;
    }

    public void reset() {
        lifeTime = 0;
    }

    public void pause() {
        paused = true;
    }

    public void resume() {
        paused = false;
    }

    public void FixedUpdate() {
        // Stop emitting after time.
        if (!paused)
            lifeTime += 1;
        if (totalLifeTime > 0 && lifeTime >= totalLifeTime) { return; }

        // Emit bullet(s) after time.
        if (!paused)
            emitTimer += 1;
        if (emitTimer >= nextEmit) {
            spawnMethod(bulletType, emissionPosition, emissionAngle, spawnMethodParams);
            nextEmit = (int)timePerEmit.getValue();
            emitTimer = 0;
        }
    }

    public BulletEmitter clone() {
        BulletEmitter cloneEmit = new BulletEmitter(bulletType, spawnMethod);
        cloneEmit.timeToLive = timeToLive;
        cloneEmit.timePerEmit = timePerEmit;
        cloneEmit.spawnMethodParams = spawnMethodParams;
        cloneEmit.Init();
        return cloneEmit;
    }
}
