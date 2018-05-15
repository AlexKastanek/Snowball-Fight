using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerPickMenu : MonoBehaviour {
    private MenuController menuController;
    public LineRenderer laserPointer;
    public Transform pointer;           //Empty gameobject, the Z axis is the direction the user is pointing the controller at

    public bool pointingAtButton = false;
    public GameObject pointedButton;    //Null if pointingAtButton = false

    public Material greenMaterial;
    public Material redMaterial;
    public Material defaultMaterial;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start ()
    {
        menuController = FindObjectOfType<MenuController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetHairTrigger ())
        {
            RaycastHit hit;

            //Do a cast which can only hit the buttons
            if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, 50f, ~LayerMask.GetMask ("player", "hand")))
            {
                laserPointer.enabled = true;

                if (hit.rigidbody && hit.rigidbody.CompareTag ("Button"))
                {
                    pointingAtButton = true;
                    pointedButton = hit.rigidbody.gameObject;
                    laserPointer.material = greenMaterial;

                    pointedButton.GetComponent<MeshRenderer>().material = greenMaterial;

                } else
                {
                    pointingAtButton = false;
                    
                    if (pointedButton)
                    {
                        pointedButton.GetComponent<MeshRenderer>().material = defaultMaterial;
                        pointedButton = null;
          
                    }

                    laserPointer.material = redMaterial;

                }

                laserPointer.SetPosition(0, transform.position);
                laserPointer.SetPosition(1, hit.point);



            } else
            {
                Ray ray;

                ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

                if (pointedButton)
                {
                    pointedButton.GetComponent<MeshRenderer>().material = defaultMaterial;
                    pointedButton = null;

                }

                laserPointer.enabled = true;

                pointingAtButton = false;
                pointedButton = null;
                laserPointer.SetPosition(0, transform.position);
                laserPointer.SetPosition(1, ray.GetPoint (50));
                laserPointer.material = redMaterial;


                

            }
        } else
        {
            if (pointedButton)
            {
                pointedButton.GetComponent<MeshRenderer>().material = defaultMaterial;
                //pointedButton = null;

            }

            laserPointer.enabled = false;

        }

        if (Controller.GetHairTriggerUp ())
        {
            if (pointingAtButton)
            {
                string buttonName = pointedButton.name;

                if (buttonName == "PlayButton")
                {
                    menuController.ChangeMenuSet(1);

                } else if (buttonName == "InstructionsButton")
                {
                    menuController.ChangeMenuSet(2);

                } else if (buttonName == "ReturnButton")
                {
                    menuController.ChangeMenuSet(0);

                } else if (buttonName == "DodgeEasy")
                {
                    PlayerPrefs.SetInt("NumTurrets", 3);
                    SceneManager.LoadScene(1);

                } else if (buttonName == "DodgeMedium")
                {
                    PlayerPrefs.SetInt("NumTurrets", 5);
                    SceneManager.LoadScene(1);

                } else if (buttonName == "DodgeHard")
                {
                    PlayerPrefs.SetInt("NumTurrets", 8);
                    SceneManager.LoadScene(1);

                } else if (buttonName == "SnowmanPlay")
                {
                    SceneManager.LoadScene(2);

                }

            }

            pointedButton.GetComponent<MeshRenderer>().material = defaultMaterial;
            pointingAtButton = false;
            pointedButton = null;
            laserPointer.enabled = false;

        }

    }
}


