using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnSign : MonoBehaviour {

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag ("Snowball"))
        {
            SceneManager.LoadScene(0);

        }

    }
}
