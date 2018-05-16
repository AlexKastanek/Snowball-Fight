using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrostySpawner : MonoBehaviour {
    public GameObject frostyObject;
    public float radius = 10;
    public float waitTime = 10;
    public Transform target;
    public levelController lController;
    public int scoreStep = 100;

    private int maxScoreReached = 0;
    private bool shouldStopSpawning = false;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnFrosty());


    }

    // Update is called once per frame
    void Update ()
    {
        int currentScore = lController.GetScore();

        if (currentScore > maxScoreReached)
        {
            maxScoreReached = currentScore;

        }

        if (maxScoreReached >= 7.5 * scoreStep) //375
        {
            waitTime = 2;

        } else if (maxScoreReached >=  4.5 * scoreStep) //225
        {
            waitTime = 4;

        }
        else if (maxScoreReached >= 2.5 * scoreStep) //125
        {
            waitTime = 6;

        }
        else if (maxScoreReached >= 1 * scoreStep) //50
        {
            waitTime = 8;

        }

        if (currentScore < 0)
        {
            shouldStopSpawning = true;

            Frosty[] allFrosties = FindObjectsOfType<Frosty>();

            foreach (Frosty f in allFrosties)
            {
                Destroy(f.gameObject);

            }

            //Gameover stuff here
            PlayerPrefs.SetInt("Score", maxScoreReached);
            SceneManager.LoadScene(4);

        }


    }

    IEnumerator SpawnFrosty ()
    {
        if (!shouldStopSpawning)
        {
            Vector3 newPos = new Vector3(0f, 0.33f, 0f) + RandomPointOnCircleEdge(radius);

            GameObject frosty = Instantiate(frostyObject, newPos, Quaternion.identity);
            frosty.GetComponent<Frosty>().target = target;
            yield return new WaitForSeconds(waitTime);

            StartCoroutine(SpawnFrosty());

        } else
        {
            yield return new WaitForSeconds (0);

        }

    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, 0, vector2.y);
    }
}
