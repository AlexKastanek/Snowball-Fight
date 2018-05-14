using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelController : MonoBehaviour {

	public Text score;

	private int playerScore = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		score.text = "Score: " + playerScore;
		
	}

	public void incrementPlayerScore()
	{

		playerScore += 10;

	}

	public void decrementPlayerScore()
	{

		playerScore -= 10;

	}

    public int GetScore ()
    {
        return playerScore;

    }
}
