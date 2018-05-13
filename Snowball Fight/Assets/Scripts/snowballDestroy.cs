using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballDestroy : MonoBehaviour {

	public float deleteTimer;
    public GameObject deathParticles;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Destroy (gameObject, deleteTimer);
		
	}

    void OnCollisionEnter (Collision col)
    {
        bool isBeingHeld = false;

        ControllerGrabObject[] controllers = FindObjectsOfType<ControllerGrabObject>();

        foreach  (ControllerGrabObject controller in controllers)
        {
            isBeingHeld = isBeingHeld || controller.IsThisObjectInHand(gameObject);

        }

        if (!isBeingHeld && !col.rigidbody.CompareTag ("SnowballEnemy"))
        {
            GameObject parts = Instantiate(deathParticles, transform.position, transform.rotation);

            Destroy(parts, 5f);
            Destroy(gameObject);

        } 
    }
}
