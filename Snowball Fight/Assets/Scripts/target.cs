using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

	private GameObject controller;

	// Use this for initialization
	void Start () {

		controller = transform.parent.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter()
	{

		//increment player score
		controller.GetComponent<targetController>().OnTargetHit();

	}
}
