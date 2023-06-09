using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
	

	public float walkSpeed = 5.0f;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;

 

    public Animator Splyfus;
    

    Rigidbody rigidbodyR;

	float jumpForce = 250.0f;
	bool grounded;
	public LayerMask groundedMask;
/*
    public int maxhealth = 100;
    public int currenthealth;*/

    public Health healthbar;

    public GameObject Panel;


    public ConfigurableJoint L;
    public ConfigurableJoint R;
    void Start()
	{
		
		rigidbodyR = GetComponent<Rigidbody>();
/*        currenthealth =  maxhealth;*/
        Panel.SetActive(false);
        Time.timeScale = 1f;

    }


	void Update()
	{
        Move();
    }



	void FixedUpdate()
	{
		rigidbodyR.MovePosition(rigidbodyR.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
	}

	void Move()
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

 

}
