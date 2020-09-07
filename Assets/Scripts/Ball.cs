using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float amplify = 3;
    ScoreManager scoreManager;
    GameManager gameManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(6, 0, 6) * amplify);


        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 30)
        {
            rb.velocity = new Vector3(29, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < -30)
        {
            rb.velocity = new Vector3(-29, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.z > 30)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 29);
        }

        if (rb.velocity.z < -30)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -29);
        }
    }

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) { AddForce(); }
        //rb.AddExplosionForce(this.amplify, Vector3.right * amplify);
    }

    private void AddForce()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "PaddleLeft" || other.gameObject.name == "PaddleRight")
        {
            if (rb.velocity.x < Mathf.Abs(25))
            {
                rb.AddForce(rb.velocity * amplify);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LeftGoal")
        {
            scoreManager.Player2Scored();
            Destroy(gameObject);
            gameManager.CreateBall(2);
        }

        if (other.gameObject.name == "RightGoal")
        {
            scoreManager.Player1Scored();
            Destroy(gameObject);
            gameManager.CreateBall(1);
        }

    }
}
