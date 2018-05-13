using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballDestroy : MonoBehaviour {

	public float deleteTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Destroy (gameObject, deleteTimer);
		
	}
}
