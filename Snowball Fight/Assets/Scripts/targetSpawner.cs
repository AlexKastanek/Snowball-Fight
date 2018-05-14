using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSpawner : MonoBehaviour {

	public GameObject target;

	public int targetAmount;

	public float targetRadius;
	public float targetHeight;

	void Awake () 
	{
		
	}

	void Start()
	{
        targetAmount = PlayerPrefs.GetInt("NumTurrets", 6);

        Vector3 center = transform.position + new Vector3 (0, -10 + targetHeight, 0);
		for (int i = 0; i < targetAmount; i++) 
		{

			Vector3 pos = NextCirclePos (center, targetRadius, i, targetAmount);
			Quaternion rot = Quaternion.FromToRotation (Vector3.up, center - pos);
			//rot = Quaternion.Euler(new Vector3(90, rot.y, rot.z));
			Instantiate (target, pos, rot, transform);

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
