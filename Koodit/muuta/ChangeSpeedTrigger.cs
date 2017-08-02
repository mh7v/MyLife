using UnityEngine;
using System.Collections;

public class ChangeSpeedTrigger : MonoBehaviour {
	[SerializeField]
	private bool speedUp;

	void OnTriggerEnter(Collider other) {
		if (other.transform.parent != null) {
			SideScrollerController ssc = other.transform.parent.GetComponent<SideScrollerController> ();
			if (ssc != null)
				ssc.ChangeSpeed (speedUp);
		}
	}
}