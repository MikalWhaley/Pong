using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float amplify = 3;
    ScoreManager scoreManager;
    GameManager gameManager;
    private Rigidbody rb;

    public int scaleMod = 2;

    public AudioClip fastBump;
    public AudioClip slowBump;
    private AudioSource source;

    Paddle paddle;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(6, 0, 6) * amplify);

        source = GetComponent<AudioSource>();


        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 32)
        {
            rb.velocity = new Vector3(30, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < -32)
        {
            rb.velocity = new Vector3(-30, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.z > 32)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 30);
        }

        if (rb.velocity.z < -32)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -30);
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

                if(rb.velocity.magnitude > 15){

                    source.PlayOneShot(fastBump, 1F);
                }
                else
                {
                    source.PlayOneShot(slowBump, 1F);
                }
                

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

            if (gameManager.blueExists == false)
            {
                gameManager.createBlueMateria();
            }
            if (gameManager.greenExists == false)
            {
                gameManager.createGreenMateria();
            }
        }

        if (other.gameObject.name == "RightGoal")
        {
            scoreManager.Player1Scored();
            Destroy(gameObject);
            gameManager.CreateBall(1);

            if (gameManager.blueExists == false)
            {
                gameManager.createBlueMateria();
            }
            if (gameManager.greenExists == false)
            {
                gameManager.createGreenMateria();
            }
        }

        
        if (other.gameObject.name == "BlueMateria(Clone)")
        {
            //Debug.Log("hit");
            BlueMateria(other);
        }

        if (other.gameObject.name == "GreenMateria(Clone)")
        {
            //Debug.Log("hit");
            GreenMateria(other);
        }

    }


    private void BlueMateria(Collider other)
    {
        gameObject.GetComponent<Transform>().localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        gameManager.blueExists = false;
        Destroy(other.gameObject);
        //Debug.Log("shoulda deleted");
    }

    private void GreenMateria(Collider other)
    {
        rb.velocity = new Vector3(-rb.velocity.x, -rb.velocity.y, -rb.velocity.z);
        gameManager.greenExists = false;
        Destroy(other.gameObject);


    }

}
