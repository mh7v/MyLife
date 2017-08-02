﻿using UnityEngine;
using System.Collections;

public class ResponsivePlatformerController : MonoBehaviour {

	public float gravity = 50f;
	public float terminalVelocity = 30f;
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
	}

	public void Move(){
		var deadZone = 0.1f;
		verticalVelocity = moveVector.y;
		moveVector = Vector3.zero;
		if(Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
			moveVector += new Vector3(Input.GetAxis("Horizontal"),0,0);
		if((Input.GetButtonDown("Jump") && controller.isGrounded) || forceJump == true){
			verticalVelocity = jumpForce;
			jumped = true;
			forceJump = false;
		}
		moveVector *= moveSpeed;
	}

	public void ProcessMovement(){
		moveVector = new Vector3((moveVector.x), verticalVelocity, 0);
		if(moveVector.y > -terminalVelocity)
			moveVector = new Vector3(moveVector.x, (moveVector.y - gravity * Time.deltaTime), 0);
		controller.Move(moveVector * Time.deltaTime);
	}
}
