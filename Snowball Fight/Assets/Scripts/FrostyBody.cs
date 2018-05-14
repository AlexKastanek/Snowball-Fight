using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class FrostyBody : MonoBehaviour {
    public bool isHead = false;
    public bool isArms = false;
    public Transform target;
    public GameObject deathParticles;
    private NavMeshAgent myAgent;

	// Use this for initialization
	void Start ()
    {
        target = GetComponentInParent<Frosty>().target;
        myAgent = GetComponentInParent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isHead || isArms)
        {
            transform.LookAt(target);

            if (isArms)
            {
                Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
                this.transform.LookAt(targetPostition);

            }

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

                Transform[] otherParts = transform.parent.GetComponentsInChildren<Transform>();

                foreach (Transform t in otherParts)
                {
                    GameObject poof = Instantiate(deathParticles, t.position, t.rotation);

                    Destroy(poof, 5f);

                }

                Destroy(transform.parent.gameObject);

                

            } else
            {
                GameObject poof = Instantiate(deathParticles, transform.position, transform.rotation);

                Destroy(poof, 5f);

                if (myAgent.speed == 3.5f)
                {
                    myAgent.speed = 2f;

                } else if (myAgent.speed == 2f)
                {
                    myAgent.speed = 0.5f;

                }

                Destroy(gameObject);


            }

        }
    }
}
