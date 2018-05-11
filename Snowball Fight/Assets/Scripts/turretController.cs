using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour {

	public List<GameObject> turretSet;
	public GameObject player;

	public float shootIntervalLow, shootIntervalHigh;

	private bool shooterAssigned = false, timerLoaded = false;

	private float shootInterval = 0f, shootTimer = 0f;

	private int shooterIndex = 1, lastShooterIndex = 0;

	void Awake()
	{
		turretSet = new List<GameObject> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//if shooterAssigned is false 
		if (!shooterAssigned)
		{
			
			//randomly generate turret index from 0 to turretSet.size - 1 and set shooterAssigned to true
			Debug.Log(turretSet.Count);
			shooterIndex = Random.Range (0, turretSet.Count);
			while (turretSet[shooterIndex].gameObject.GetComponent<turret>().isShooting()) 
			{
				shooterIndex = Random.Range (0, turretSet.Count);
			}
			shooterAssigned = true;
			lastShooterIndex = shooterIndex;
			Debug.Log ("next shooter: " + shooterIndex);

			//randomly generate wait time from lower bound to upper bound public variables
			shootInterval = Random.Range(shootIntervalLow, shootIntervalHigh);
			Debug.Log ("timer set to: " + shootInterval);

			//start timer
			shootTimer = 0f;
			timerLoaded = true;

		}

		//once wait time is reached, shoot turret and set shooterAssigned to false
		if (timerLoaded) 
		{
			shootTimer += Time.deltaTime;
			//Debug.Log (shootTimer);
			if (shootTimer > shootInterval) 
			{
				turretSet [shooterIndex].GetComponent<turret> ().startShootingProcess();
				Debug.Log (shooterIndex + " is shooting");
				shooterAssigned = false;
				timerLoaded = false;
			}
		}

	}
}
