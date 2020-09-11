using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    public Text playerScore;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        //Debug.Log("I'm supposed to update " + gameObject.name);
        score++;

        if(score >= 8)
        {
            playerScore.color = Color.red;
        }
        playerScore.text = "Score: " + score;
    }

    public void wipeScore()
    {
        score = 0;
        playerScore.text = "Score: " + score;
        playerScore.color = Color.blue;
    }


}
