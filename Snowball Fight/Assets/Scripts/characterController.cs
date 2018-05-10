using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

	public GameObject head;
	public GameObject projectile;

	public float projAcc = 10f;

	private GameObject snowball;

	private bool possessesSnowball = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		//casting ray on layer 8 from camera to check if player is looking at snow within pick up radius
		int layerMask = 1 << 8;
		bool lookingAtNearbySnow = Physics.Raycast (head.transform.position, head.transform.forward, 3f, layerMask);
		Debug.DrawRay (head.transform.position, head.transform.forward * 3f, Color.yellow);

		//if left mouse button is clicked no snowball is in hand, check if player is looking at snow within pick up radius
		//else if snowball is in hand, throw snowball
		if (Input.GetMouseButtonDown (0) && !possessesSnowball) 
		{

			//if looking at snow within pick up radius, place snowball in hand
			if (lookingAtNearbySnow) {
				
				Debug.Log ("pick up available");
				Vector3 snowballHoldPosition = head.transform.position + head.transform.forward + head.transform.right * 0.5f + head.transform.up * 0.2f;
				snowball = Instantiate (projectile, snowballHoldPosition, Quaternion.identity, head.transform);
				snowball.GetComponent<Rigidbody> ().isKinematic = true;
				possessesSnowball = true;

			} 
			else 
			{

				Debug.Log ("pick up not available");

			}

		}
		else if (Input.GetMouseButtonDown (0) && possessesSnowball) 
		{

			snowball.transform.parent = null;
			snowball.GetComponent<Rigidbody> ().isKinematic = false;
			snowball.GetComponent<Rigidbody> ().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			snowball.GetComponent<Rigidbody> ().AddForce(head.transform.forward * projAcc + head.transform.right * -30f + head.transform.up * 100f);
			possessesSnowball = false;

		}
			
	}
}
