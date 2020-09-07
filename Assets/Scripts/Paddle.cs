using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody rigidbodyeft;
    Rigidbody rigidbodyRight;
    public ForceMode forceMode;

    public GameObject leftPaddle;
    public GameObject rightPaddle;

    public float amplify = 15;
    // Start is called before the first frame update
    void Start()
    {

        rigidbodyeft = leftPaddle.gameObject.GetComponent<Rigidbody>();
        rigidbodyRight = rightPaddle.gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Right Paddle") > 0)
        {
            Vector3 lup = new Vector3(0, 0.0f, 10);
            rigidbodyRight.AddForce(lup, forceMode);
        }

        if (Input.GetAxis("Right Paddle") < 0)
        {
            Vector3 lup = new Vector3(0, 0.0f, -10);
            rigidbodyRight.AddForce(lup, forceMode);
        }


        if (Input.GetAxis("Left Paddle") > 0)
        {
            Vector3 lup = new Vector3(0, 0.0f, 10);
            rigidbodyeft.AddForce(lup, forceMode);
        }

        if (Input.GetAxis("Left Paddle") < 0)
        {
            Vector3 lup = new Vector3(0, 0.0f, -10);
            rigidbodyeft.AddForce(lup, forceMode);
        }

    }
}
