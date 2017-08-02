using UnityEngine;
using System.Collections;

public class FirstPersonShooter : MonoBehaviour {

	// These are the variables for physics.
	public float gravity = 50f;
	public float terminalVelocity = 30f;

	public Rigidbody projectile;    // The projectile that shoots out on Fire1 button pressed
	public int bulletSpeed = 100;    // This decides how fast the projectiles will fly
	public bool autoFire = true;    // This decides if you shoot every frame or not

	// These are the variables for moving
	public float moveSpeed = 15.0f;
	public float jumpForce = 25f;
	public bool forceJump = false;
	private bool jumped = false;
	private CharacterController controller;

	public Vector3 moveVector {get; set;}
	public float verticalVelocity {get; set;}

	void Awake () {
		controller = gameObject.GetComponent("CharacterController") as CharacterController;
	}


	void Update () {
		Move();
		if(!controller.isGrounded && jumped && Input.GetButtonUp("Jump") && verticalVelocity > 0){
			verticalVelocity = 0f;
			jumped = false;
		}
		ProcessMovement();
		if(Input.GetButtonDown("Fire1") && projectile != null && autoFire == false){
			Rigidbody bullet;
			bullet = Instantiate (projectile, transform.position + Camera.main.transform.TransformDirection(Vector3.forward*2), transform.rotation) as Rigidbody;
			bullet.velocity = Camera.main.transform.TransformDirection(Vector3.forward * bulletSpeed);
		}
		else if(Input.GetButton("Fire1") && projectile != null && autoFire == true){
			Rigidbody bullet;
			bullet = Instantiate (projectile, transform.position + Camera.main.transform.TransformDirection(Vector3.forward*2), transform.rotation) as Rigidbody;
			bullet.velocity = Camera.main.transform.TransformDirection(Vector3.forward * bulletSpeed);
		}
	}

	public void Move(){
		var deadZone = 0.1f;
		verticalVelocity = moveVector.y;
		moveVector = Vector3.zero;
		if(Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
			moveVector += new Vector3(Input.GetAxis("Horizontal"),0,0);
		if(Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
			moveVector += new Vector3(0,0,Input.GetAxis("Vertical"));
		if((Input.GetButtonDown("Jump") && controller.isGrounded) || forceJump == true){
			verticalVelocity = jumpForce;
			jumped = true;
			forceJump = false;
		}
		moveVector = Camera.main.transform.TransformDirection (moveVector);
		moveVector *= moveSpeed;
	}

	public void ProcessMovement(){
		moveVector = new Vector3(moveVector.x, verticalVelocity, moveVector.z);
		if(moveVector.y > -terminalVelocity)
			moveVector = new Vector3(moveVector.x, (moveVector.y - gravity * Time.deltaTime), moveVector.z);
		controller.Move(moveVector * Time.deltaTime);
	}
}
