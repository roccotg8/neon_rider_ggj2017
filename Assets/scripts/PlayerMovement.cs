using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [HideInInspector]
    public bool standingUp;         //which way is the player facing
    [HideInInspector]

    public float maxSpeed = 10f;    //the fastest the character moves in the x axis
    public float moveForce = 365f;  //amount of force added to move the player

    public bool jump = false;       //is the player jumping
    private int jumpCount;          //how many times the player has jumped
    public float jumpForce = 1000f; //amount of force added when the player jumps

    private bool grounded = false;  //is the player grounded

    private Animator anim;          //reference to the players animator component
    public Vector2 theScale;


	void Awake () {
        grounded = false;
        standingUp = true;
        //anim = GetComponent<Animator>();
        jumpCount = 0;
        theScale = transform.localScale;
	}
	
	
	void Update () {
        //if the player is grounded and the jump button is pressed, jump
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
            jump = true;
	}

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");

        if (v > 0 && !standingUp)
            Flip();
        else if (v < 0 && standingUp)
            Flip();


        if (0.5f * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0.5f * moveForce);



        if (jump && jumpCount < 2)
        {
            //set the jump animator trigger parameter
            //anim.SetTrigger("Jump");

            //add vertical force to the player
            if (standingUp)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                Debug.Log("jump");
            }
            else if(!standingUp)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -1 * jumpForce));
                Debug.Log("jump");
            }
            //prevent the player from jumping until the jump conditions from Update are satisfied
            grounded = false;
            jumpCount++;
            jump = false;
        }

        if (jumpCount >= 2)
            jump = false;
    }

    void Flip()
    {
        standingUp = !standingUp;
        Debug.Log("flipped around");

        //inverts gravity for the player
        GetComponent<Rigidbody2D>().gravityScale *= -1;

        //flips the player
        theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("you landed");
        grounded = true;
        jumpCount = 0;
    }
}
