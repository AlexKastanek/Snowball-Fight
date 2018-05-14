using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostySpawner : MonoBehaviour {
    public GameObject frostyObject;
    public float radius = 10;
    public float waitTime = 4;
    public Transform target;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnFrosty());


    }

    // Update is called once per frame
    void Update ()
    {

		
	}

    IEnumerator SpawnFrosty ()
    {
        Vector3 newPos = new Vector3(0f, 0.33f, 0f) + RandomPointOnCircleEdge(radius);

        GameObject frosty = Instantiate(frostyObject, newPos, Quaternion.identity);
        frosty.GetComponent<Frosty>().target = target;
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(SpawnFrosty ());


    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, 0, vector2.y);
    }
}
