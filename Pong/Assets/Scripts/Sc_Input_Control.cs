using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Input_Control : MonoBehaviour {

	public GameObject leftStick, rightStick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		leftStick.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 0f, 0f);
		rightStick.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 0f, 0f);

		if (Input.GetKey (KeyCode.W)) {
			leftStick.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 4f, 0f);
		}	
		else if (Input.GetKey (KeyCode.S)) {
			leftStick.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, -4f, 0f);
		}	

		if (Input.GetKey (KeyCode.UpArrow)) {
			rightStick.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 4f, 0f);
		}	
		else if (Input.GetKey (KeyCode.DownArrow)) {
			rightStick.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, -4f, 0f);
		}	


	}
}
