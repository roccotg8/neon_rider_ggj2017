using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlaceholder : MonoBehaviour {
    float x;
    public float ls;
	// Use this for initialization
	void Start ()
    {
        x = Time.deltaTime * ls;      
    }
	
	// Update is called once per frame
	void Update () {
		transform.Translate(x, 0, 0);
	}
}
