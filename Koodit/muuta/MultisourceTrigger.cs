using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultisourceTrigger : MonoBehaviour {
	private int count;
	[SerializeField]
	private GameObject source;
	[SerializeField]
	private int activateCount;
	[SerializeField]
	private GameObject target;
	private enum Mode {
		Activate      = 0, // Activate the target GameObject
		Deactivate    = 1, // Deactivate target GameObject
	}
	[SerializeField]
	private Mode action = Mode.Activate;

	void OnTriggerStay(Collider other) {
		if(other.name == source.name)
			count++;
		if (count >= activateCount)
			ActivateTrigger();
	}

	void ActivateTrigger() {
		switch (action) {
		case Mode.Activate:
			target.SetActive(true);
			break;
		case Mode.Deactivate:
			target.SetActive(false);
			break;
		}
	}

	void Update () {
		count = 0;
	}
}
