using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSnowmen : MonoBehaviour {

    public TextMesh message;

	// Use this for initialization
	void Start () {

        int playerScore = PlayerPrefs.GetInt("Score"), highScore = PlayerPrefs.GetInt("HighScoreSnowmen");

        message.text = "You have been overrun by snowmen!\nBut you managed to achieved a score of " + playerScore.ToString();
        if (playerScore > highScore)
        {
            message.text = message.text + "\nCongrats! This is a new high score!";
        }
        else message.text = message.text + "\nThe high score is " + highScore.ToString();
        PlayerPrefs.SetInt("HighScoreSnowmen", playerScore);
        PlayerPrefs.DeleteKey("Score");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
