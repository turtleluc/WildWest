using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	

	public float walkSpeed = 5.0f;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;

	

	Rigidbody rigidbodyR;

	float jumpForce = 250.0f;
	bool grounded;
	public LayerMask groundedMask;



	
	void Start()
	{
		
		rigidbodyR = GetComponent<Rigidbody>();
		
	}


	void Update()
	{


		if (Input.GetKey(KeyCode.LeftShift))
        {
			walkSpeed = 7.0f;
		}

		else
        {
			walkSpeed = 5.0f;
		}



		// movement
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		



			// jump
			if (Input.GetButtonDown("Jump"))
		{
			if (grounded)
			{
				rigidbodyR.AddForce(transform.up * jumpForce);
			}
		}

		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

	}

	void FixedUpdate()
	{
		rigidbodyR.MovePosition(rigidbodyR.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
	}

	
}
