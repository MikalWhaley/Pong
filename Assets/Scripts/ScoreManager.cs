using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int player1Score { get; set; } = 0;
    public int player2Score { get; set; } = 0;

    public int Player1Scored()
    {
        player1Score++;
        Debug.Log("Player 1 Scored! " + printScore());

        if (player1Score == 11)
        {
            Debug.Log("Player 1 wins! " + GameOver());
        }
        return player1Score;
    }
    public int Player2Scored()
    {
        player2Score++;
        Debug.Log("Player 2 Scored! " + printScore());

        if(player2Score == 11)
        {
            Debug.Log("Player 2 wins! " + GameOver());
        }
        return player2Score;
    }

    public string printScore()
    {
        return("The Score is " + player1Score + " to " + player2Score );
    }

    public string GameOver()
    {
        player1Score = 0;
        player2Score = 0;

        return "Game Over";
    }


}
