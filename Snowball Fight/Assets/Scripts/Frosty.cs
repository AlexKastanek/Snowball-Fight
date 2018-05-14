using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Frosty : MonoBehaviour {
    public Transform target;

    public AudioSource[] frostySounds;

    public float damageDistance;

    private bool isDamaging = false;
    public float damageWait = 1f;

    private levelController lController;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(PlaySoundEffect());

        lController = FindObjectOfType<levelController>();

        GetComponent<NavMeshAgent>().SetDestination(target.position);
        damageDistance = GetComponent<NavMeshAgent>().stoppingDistance;
        damageDistance += damageDistance * 0.5f;

    }

    // Update is called once per frame
    void Update ()
    {
        //transform.LookAt(target);
        Vector3 offset = target.position - transform.position;

        if (!isDamaging && offset.magnitude <= damageDistance)
        {
            StartCoroutine(DoDamage());

        }

    }

    IEnumerator PlaySoundEffect ()
    {
        yield return new WaitForSeconds(Random.Range(10, 60));

        frostySounds[Random.Range(0, frostySounds.Length)].Play();


        StartCoroutine(PlaySoundEffect());

    }

    IEnumerator DoDamage ()
    {
        isDamaging = true;

        lController.decrementPlayerScore();

        yield return new WaitForSeconds(damageWait);

        isDamaging = false;

    }
}
