using UnityEngine;
using System.Collections;

public class SideScrollerController : MonoBehaviour{
	public float maxScrollingSpeed = 50f;
	public float minScrollingSpeed = 0f;
	public float currentScrollingSpeed = 0f;
	public float scrollingSpeedStep = 5f;
	public float audioSpeedStep = 0f;
	private AudioSource audSour;
	public float moveSpeed = 15f;
	private CharacterController controller;
	public CharacterController cameraController;
	public Vector3 moveVector { get; set; }

	void Awake (){
		controller = gameObject.GetComponent ("CharacterController") as CharacterController;
		if (audioSpeedStep != 0f)
			audSour = gameObject.GetComponent<AudioSource> ();
	}

	void Update (){
		Move ();
		ProcessMovement ();
	}

	private void Move (){
		var deadZone = 0.1f;
		moveVector = Vector3.zero;
		if (Input.GetAxis ("Horizontal") > deadZone || Input.GetAxis ("Horizontal") < -deadZone)
			moveVector += new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
		if (Input.GetAxis ("Vertical") > deadZone || Input.GetAxis ("Vertical") < -deadZone) {
			moveVector += new Vector3 (0, Input.GetAxis ("Vertical"), 0);
		}
		moveVector *= moveSpeed;
		if (Input.GetKeyDown (KeyCode.N)) {
			ChangeSpeed (false);
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			ChangeSpeed (true);
		}
	}

	public void ChangeSpeed(bool change) {
		if (!change) {
			if (currentScrollingSpeed - scrollingSpeedStep > minScrollingSpeed) {
				currentScrollingSpeed -= scrollingSpeedStep;
				if (audioSpeedStep != 0)
					audSour.pitch -= audioSpeedStep;
			} else {
				currentScrollingSpeed = minScrollingSpeed;
				if (audioSpeedStep != 0)
					audSour.pitch = 1;
			}
		} else {
			if (currentScrollingSpeed + scrollingSpeedStep < maxScrollingSpeed) {
				currentScrollingSpeed += scrollingSpeedStep;

				if (audioSpeedStep != 0)
					audSour.pitch += audioSpeedStep;
			} else
				currentScrollingSpeed = maxScrollingSpeed;
		}
	}

	private void ProcessMovement (){
		moveVector = new Vector3 (moveVector.x, moveVector.y, 0);
		Vector3 parentMoveVector = new Vector3 (currentScrollingSpeed, 0, 0);
		Vector3 scrollingVector = new Vector3 (currentScrollingSpeed, 0, 0);
		controller.Move (scrollingVector * Time.deltaTime);
		cameraController.Move (parentMoveVector * Time.deltaTime);
		controller.Move (moveVector * Time.deltaTime);
	}
}
