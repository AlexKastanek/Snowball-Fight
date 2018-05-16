using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTargets : MonoBehaviour {

    public TextMesh message;

	// Use this for initialization
	void Start () {

        int playerScore = PlayerPrefs.GetInt("Score"), highScore = PlayerPrefs.GetInt("HighScoreTargets");

        message.text = "Time has run out!\nYou achieved a score of " + playerScore.ToString();
        if (playerScore > highScore)
        {
            message.text = "\nCongrats! This is a new high score!";
        }
        PlayerPrefs.SetInt("HighScoreTargets", playerScore);
        PlayerPrefs.DeleteKey("Score");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
