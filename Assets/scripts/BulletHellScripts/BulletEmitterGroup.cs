﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A collection of one or more bullet emitters that will be attached to a game object (ie: an enemy).
public class BulletEmitterGroup : MonoBehaviour {

    List<BulletEmitter> myEmitters = new List<BulletEmitter>();

	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate() {
        foreach (BulletEmitter emit in myEmitters) {
            emit.FixedUpdate();
        }
    }

    public void addEmitter(BulletEmitter emit) {
        emit.Init();
        myEmitters.Add(emit);
    }
}