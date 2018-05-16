using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	public GameObject snowball;

	public float throwVel;

	private SteamVR_TrackedObject trackedObj;

	// 1
	private GameObject collidingObject; 
	// 2
	private GameObject objectInHand;

	private GameObject snowballInstance;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void SetCollidingObject(Collider col)
	{
		// 1
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{
			return;
		}
		// 2
		collidingObject = col.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (Controller.GetHairTriggerDown ()) 
		{


			if (collidingObject && collidingObject.layer == 11) 
			{
				snowballInstance = collidingObject;
				//snowballInstance.gameObject.GetComponent<SphereCollider> ().enabled = false;
				GrabObject ();
			}
			else if (collidingObject && collidingObject.layer == 8) 
			{
				snowballInstance = Instantiate (snowball, transform.position + new Vector3(0f, -0.2f, 0.02f), Quaternion.identity);
                //snowballInstance.gameObject.GetComponent<SphereCollider> ().enabled = false;
                transform.GetComponent<AudioSource>().Play();
                GrabSnowball();
			}

		}

		if (Controller.GetHairTriggerUp ()) 
		{

			if (objectInHand) 
			{
				//snowballInstance.gameObject.GetComponent<SphereCollider> ().enabled = true;
				ReleaseObject ();
			}

		}
		
	}

	private void GrabObject()
	{
		// 1
		objectInHand = collidingObject;
		collidingObject = null;
		// 2
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}

	private void GrabSnowball()
	{
		// 1
		objectInHand = snowballInstance;
		collidingObject = null;
		// 2
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}

	// 3
	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject()
	{
		// 1
		if (GetComponent<FixedJoint>())
		{
			// 2
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());
			// 3
			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity * throwVel;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity * throwVel;
		}
		// 4
		objectInHand = null;
	}

	// 1
	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}

	// 2
	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}

	// 3
	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

    public bool IsThisObjectInHand (GameObject sentObject)
    {
        if (sentObject == objectInHand)
        {
            return true;

        } else
        {
            return false;

        }

    }
}
