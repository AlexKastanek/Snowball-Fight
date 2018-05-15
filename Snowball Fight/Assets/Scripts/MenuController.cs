using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    //Menu Sets
    public GameObject mainMenuSet;
    public GameObject playMenuSet;
    public GameObject controlsMenuSet;

	// Use this for initialization
	void Start ()
    {
        mainMenuSet.SetActive (true);
        playMenuSet.SetActive (false);
        controlsMenuSet.SetActive(false);

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void ChangeMenuSet (int set)
    {
        if (set == 0) //Main
        {
            mainMenuSet.SetActive(true);
            playMenuSet.SetActive(false);
            controlsMenuSet.SetActive(false);

        } else if (set == 1) //Play
        {
            mainMenuSet.SetActive(false);
            playMenuSet.SetActive(true);
            controlsMenuSet.SetActive(false);

        } else if (set == 2) //Instructions/Controls
        {
            mainMenuSet.SetActive(false);
            playMenuSet.SetActive(false);
            controlsMenuSet.SetActive(true);

        } else
        {
            Debug.Log("ERROR: Unrecognized menu set " + set);

        }

    }
}
