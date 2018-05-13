using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public GameObject level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		
		Debug.Log ("player was hit");
		if (col.gameObject.layer == 12) 
		{
			//decrement player score
			level.GetComponent<levelController> ().decrementPlayerScore ();
		}

	}
}
