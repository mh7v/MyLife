using UnityEngine;
using System.Collections;

public class FaceForward : MonoBehaviour {
	private Quaternion startRotation;

	void Start() {
		startRotation = transform.rotation;
	}

	void Update () {
		transform.rotation = startRotation;
	}
}