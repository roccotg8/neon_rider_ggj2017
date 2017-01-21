using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [HideInInspector]
    public bool standingUp;         //which way is the player facing
    [HideInInspector]

    public bool jump = false;       //is the player jumping
    private int jumpCount;          //how many times the player has jumped
    public float jumpForce = 1000f; //how strong is the jump

    private bool grounded = false;  //is the player grounded

	void Awake () {
        grounded = false;
        jumpCount = 0;
	}
	
	
	void Update () {
		//if the player is grounded and the jump button is pressed, jump
	}
}
