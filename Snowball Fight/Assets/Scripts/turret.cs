using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

	public GameObject projectile;

	//public Material lightMaterial;

	private GameObject turretHead, player, playerHead, light;

	public float projAcc = 10f;

	public AudioClip beep1, beep2, shot;

	private Material lightMaterial;

	private bool shooting = false, shootingInit = false, timerLoaded = false, beep2Played = false;
	private float shootTimer = 0f;

	private AudioSource aSource;

	void Awake()
	{

		aSource = GetComponent <AudioSource>();

	}

	// Use this for initialization
	void Start () {

		turretHead = this.gameObject.transform.GetChild (1).gameObject;
		light = this.gameObject.transform.GetChild (3).gameObject;
		player = GetComponentInParent<turretController> ().player;
		//playerHead = player.gameObject.transform.GetChild (3).gameObject;

		light.GetComponent<Renderer> ().material = new Material (Shader.Find ("Standard"));
		lightMaterial = light.GetComponent<Renderer> ().material;
		lightMaterial.color = Color.green;
		lightMaterial.EnableKeyword ("_EMISSION");
		lightMaterial.SetColor ("_EmissionColor", Color.green);


	}
	
	// Update is called once per frame
	void Update () {

		turretHead.transform.LookAt(player.transform);

		if (shootingInit) 
		{
			aSource.PlayOneShot (beep1, 0.7f);
			shootingInit = false;
			lightMaterial.color = Color.yellow;
			lightMaterial.SetColor ("_EmissionColor", Color.yellow);
			shootTimer = 0f;
			timerLoaded = true;
		}

		if (timerLoaded) 
		{
			shootTimer += Time.deltaTime;
			if (shootTimer > 3) {
				aSource.PlayOneShot (shot, 0.7f);
				beep2Played = false;
				fireProjectile ();
				shooting = false;
				timerLoaded = false;
				lightMaterial.color = Color.green;
				lightMaterial.SetColor ("_EmissionColor", Color.green);
			} 
			else if (shootTimer > 2 && !beep2Played) 
			{
				aSource.PlayOneShot (beep2, 0.7f);
				beep2Played = true;
				lightMaterial.color = Color.red;
				lightMaterial.SetColor ("_EmissionColor", Color.red);
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
