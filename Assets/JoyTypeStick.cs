using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyTypeStick : MonoBehaviour {

	public bool isLeft;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isLeft)
			transform.position = new Vector3(Input.GetAxis("LSX")-4, Input.GetAxis("LSY")-2, 0);
		else
			transform.position = new Vector3(Input.GetAxis("RSX")+4, Input.GetAxis("RSY")-2, 0);

		x = Input.GetAxis("LSX");
		y = Input.GetAxis("LSY");
	}
}
  //movementVector.x = Input.GetAxis("LeftJoystickX") * movementSpeed;
  //movementVector.z = Input.GetAxis("LeftJoystickY") * movementSpeed;