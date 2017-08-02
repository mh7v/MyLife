using UnityEngine;
using System.Collections;

public class DeactivateWithTagTrigger : MonoBehaviour {
	[SerializeField]
	private string tag = "Player";

	void OnTriggerEnter(Collider other) {
		if (other.tag == tag)
			Destroy(other.gameObject);
	}
}