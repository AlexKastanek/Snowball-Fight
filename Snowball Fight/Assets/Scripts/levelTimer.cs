using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelTimer : MonoBehaviour {

    public Text timeText;

    public float timeStart;
    private float timer, min, sec;

	// Use this for initialization
	void Start () {

        timer = timeStart;
		
	}
	
	// Update is called once per frame
	void Update () {

        min = timer / 60;
        sec = timer % 60;
        if ((int)min > 0)
        {
            timeText.text = ((int)min).ToString() + ":" + ((int)sec).ToString("00");
        }
        else
        {
            timeText.text = ((int)sec).ToString();
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //game over
        }
		
	}
}
