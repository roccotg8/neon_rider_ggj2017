using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Movement : MonoBehaviour {
    public GameObject Enemy;
    float index;
    float x;
    float y;
    float ampX = Random.Range(3.0f,7.0f)+2;
    float ampY = Random.Range(0.5f,2.5f);
    float speedX = Random.Range(1.0f, 2.5f);
    float speedY = Random.Range(2.0f, 3.0f);
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		index += Time.deltaTime;
        x = ampX* Mathf.Cos(speedX * index);
        y = ampY * Mathf.Sin(speedY * index);
        transform.position = new Vector2(x, y); 
	}
}
