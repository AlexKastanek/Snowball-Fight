using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FrostyBody : MonoBehaviour {
    public bool isHead = false;
    public Transform target;
    public GameObject deathParticles;

	// Use this for initialization
	void Start ()
    {
        target = GetComponentInParent<Frosty>().target;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isHead)
        {
            transform.LookAt(target);

        }
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag ("Snowball"))
        {
            Debug.Log("OoF OWCH OWWIE MY SNOW BONES");

            if (isHead)
            {
                FindObjectOfType<levelController>().incrementPlayerScore();

                Destroy(transform.parent.gameObject);

            } else
            {
                Destroy(gameObject);


            }

        }
    }
}
