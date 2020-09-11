using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public float ballSpeed = 5f;

    private AudioClip bgm;
    private AudioSource source;

    public GameObject blueMateria;
    public bool blueExists = false;
    public bool greenExists = false;

    public GameObject greenMateria;

    public float gameTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        CreateBall(0);
        source = GetComponent<AudioSource>();
        //source.PlayOneShot(bgm, 1F);


        blueExists = true;
        float ran1 = Random.Range(-6, 6);
        float ran2 = Random.Range(-6, 6);
        GameObject bluePre = Instantiate(blueMateria, new Vector3(ran1, 0, ran2), transform.rotation);

        greenExists = true;
        float ran3 = Random.Range(-6, 6);
        float ran4 = Random.Range(-6, 6);
        GameObject greenPre = Instantiate(greenMateria, new Vector3(ran3, 0, ran4), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createGreenMateria()
    {
        greenExists = true;
        float ran3 = Random.Range(-6, 6);
        float ran4 = Random.Range(-6, 6);
        GameObject greenPre = Instantiate(greenMateria, new Vector3(ran3, 0, ran4), transform.rotation);
    }
    public void createBlueMateria()
    {
        blueExists = true;
        float ran1 = Random.Range(-6, 6);
        float ran2 = Random.Range(-6, 6);
        GameObject bluePre = Instantiate(blueMateria, new Vector3(ran1, 0, ran2), transform.rotation);
    }

    public void CreateBall(int caseNum)
    {

        //Debug.Log(direction);

        //towards player 1
        if (caseNum == 1)
        {
            float angle = Random.Range(2.094f, 4.188f) + 180f; //+ Random.Range(0, 2) * 180f;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(radAngle), 0, Mathf.Sin(radAngle));

            GameObject ballPre = Instantiate(ball, new Vector3(0, 0, 0), transform.rotation);

            ballPre.GetComponent<Rigidbody>().velocity = dir * ballSpeed;
        }

        //twoards player 2
        if (caseNum == 2)
        {
            float angle = Random.Range(1.047f, 5.235f); //+ Random.Range(0, 2) * 180f;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(radAngle), 0, Mathf.Sin(radAngle));

            GameObject ballPre = Instantiate(ball, new Vector3(0, 0, 0), transform.rotation);

            ballPre.GetComponent<Rigidbody>().velocity = dir * ballSpeed;
        }


        if (caseNum == 0){
            float angle = Random.Range(30f, 150f) + Random.Range(0, 2) * 180f;
            float radAngle = angle * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(radAngle), 0, Mathf.Sin(radAngle));

            GameObject ballPre = Instantiate(ball, new Vector3(0, 0, 0), transform.rotation);

            ballPre.GetComponent<Rigidbody>().velocity = dir * ballSpeed;
        }
        
    }
}
