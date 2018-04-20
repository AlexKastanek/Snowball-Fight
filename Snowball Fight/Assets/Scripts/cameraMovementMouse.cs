using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementMouse : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivityHorizontal = 5.0f, sensitivityVertical = 3.0f;
	public float smoothing = 2.0f;

	GameObject character;

	// Use this for initialization
	void Start () 
	{

		character = this.transform.parent.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		//change in mouse position for each frame
		Vector2 mouseDelta = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		mouseDelta = Vector2.Scale (mouseDelta, new Vector2 (sensitivityHorizontal * smoothing, sensitivityVertical * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, mouseDelta.x, 1.0f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mouseDelta.y, 1.0f / smoothing);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp (mouseLook.y, -90.0f, 90.0f);

		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
		
	}
}
