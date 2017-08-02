using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DieAfterAllChildrenPerish : MonoBehaviour {

	void Update () {
		if (transform.childCount == 0)
			//SceneManager.LoadScene (0);
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
