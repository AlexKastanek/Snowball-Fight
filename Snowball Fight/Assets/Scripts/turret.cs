using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

	public GameObject projectile;

	private GameObject turretHead, player;

	public float projAcc = 10f;

	private bool shooting = false, shootingInit = false, timerLoaded = false;
	private float shootTimer = 0f;

	// Use this for initialization
	void Start () {

		turretHead = this.gameObject.transform.GetChild (1).gameObject;
		player = GetComponentInParent<turretController> ().player;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (shootingInit) 
		{
			shootingInit = false;
			shootTimer = 0f;
			timerLoaded = true;
		}

		if (timerLoaded) 
		{
			shootTimer += Time.deltaTime;
			if (shootTimer > 3) 
			{
				fireProjectile ();
				shooting = false;
				timerLoaded = false;
			}
		}
		
	}

	public bool isShooting()
	{
		return shooting;
	}

	public void startShootingProcess ()
	{
		shootingInit = true;
		shooting = true;
	}

	private void fireProjectile()
	{

		GameObject snowball = Instantiate (projectile, turretHead.transform.position, Quaternion.identity);
		snowball.GetComponent<Rigidbody> ().AddForce ((player.transform.position - turretHead.transform.position).normalized * projAcc + transform.up * 200f);

	}
}
