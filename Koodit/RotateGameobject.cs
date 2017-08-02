using UnityEngine;
using System.Collections;

public class RotateGameobject : MonoBehaviour {

	public float rotationSpeed = 10f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back * Time.deltaTime * rotationSpeed);
	}
}
