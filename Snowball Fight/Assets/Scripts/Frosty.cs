using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Frosty : MonoBehaviour {
    public Transform target;

    public AudioSource[] frostySounds;

	// Use this for initialization
	void Start ()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.position);


    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    IEnumerator PlaySoundEffect ()
    {
        yield return new WaitForSeconds(Random.Range(10, 60));

        frostySounds[Random.Range(0, frostySounds.Length)].Play();


        StartCoroutine(PlaySoundEffect());

    }
}
