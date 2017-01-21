using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OstritchStuff : MonoBehaviour
{

    public Collider2D enemy1;
    //public GameObject EnemyOne;
    //float playerSpeed = 6.0f;
    GameObject Target;
    Vector2 playerSpeed;
    Vector2 mySpeed;
    float speedDiff;
    float ostrichSpeed;
    float x;
    //public float ostrichSpeed;

    void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Node");
    }

    void Start()
    {
        enemy1.enabled = false;
        ostrichSpeed = 2.6f;
        x = Time.deltaTime * ostrichSpeed;
        //player = GameObject.FindGameObjectWithTag("Player");
        //Rigidbody rb = player.GetComponent<Rigidbody>();
        //playerSpeed = rb.velocity.magnitude;

        //r = GameObject.GetComponent<"Rigidbody">();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerSpeed = player.transform.position;
        //mySpeed = enemy1.transform.position;
        //speedDiff = Vector2.Distance(playerSpeed, mySpeed);
        if (!(Target.transform.position.x - enemy1.transform.position.x <= 0.5f))
        {
            transform.Translate(x, 0, 0);
        }



        //speedDiff = mySpeed.x - playerSpeed.x;




        //Debug.Log(speedDiff);


        //if playerSpeed==mySpeed or less than that than go faster 
        //else start slowing down 
        //while ((EnemyOne.transform.position.x) < (Camera.main.ScreenToWorldPoint(new Vector2((Screen.width), 0)).x))
        //{
        //    ostritchSpeed -= 0.1f;
        //}

        //ostritchSpeed = playerSpeed * 0.9f;


        //if(speedDiff > 5f)
        //{
        //    //float x = playerSpeed.x * 1.0f;
        //    x = Time.deltaTime * 0.6f;
        //    enemy1.enabled = true;

        //}
    }
}
