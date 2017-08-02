using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {

	public int rotationSpeed = 300;

	void Update () {
		var deadZone = 0.1f;
		if (Input.GetAxis ("Horizontal2") > deadZone || Input.GetAxis ("Horizontal2") < -deadZone)
			transform.Rotate (Vector3.back * Input.GetAxis("Horizontal2") * Time.deltaTime * rotationSpeed);
	}
} 

