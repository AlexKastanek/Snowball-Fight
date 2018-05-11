using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSpawner : MonoBehaviour {

	public GameObject turret;

	public int turretAmount;

	public float turretRadius;
	//public float targetHeight;

	void Awake () 
	{
		
	}

	void Start()
	{
		Vector3 center = transform.position + new Vector3 (0, -9.55f, 0);
		for (int i = 0; i < turretAmount; i++) 
		{

			Vector3 pos = NextCirclePos (center, turretRadius, i, turretAmount);
			Quaternion rot = Quaternion.FromToRotation (Vector3.forward, center - pos);
			Debug.Log (i + ": " + rot + ", " + pos + ", " + pos.x + "," + pos.z);
			//rot = Quaternion.Euler(new Vector3(90, rot.y, rot.z));
			GameObject turretInstance = Instantiate (turret, pos, rot, transform);
			if (i == turretAmount - 1 && (turretAmount % 2) == 0) 
			{
				turretInstance.transform.Rotate (new Vector3 (180, 180, 0));
			}
			this.GetComponent<turretController>().turretSet.Add (turretInstance);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector3 NextCirclePos(Vector3 center, float radius, int iteration, int amount)
	{

		float angle = (iteration + 1) * (360 / amount);
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin (angle * Mathf.Deg2Rad);
		pos.y = center.y;
		pos.z = center.z + radius * Mathf.Cos (angle * Mathf.Deg2Rad);
		return pos;

	}
}
