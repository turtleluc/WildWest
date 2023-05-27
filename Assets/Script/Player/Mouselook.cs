using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{

    public float Camerasensativity;

    public Transform PlayerBody;

    float xRotation = 0f;

    public Animator Camfus;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
        MoveAni();
    }
    void MoveAni()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
        {
            if (!this.Camfus.GetCurrentAnimatorStateInfo(0).IsName("ViewBobbing"))
            {
                    Camfus.Play("ViewBobbing");
            }

           

            /*if (!this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Walking") || !this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW") || !this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Reloading_6"))
            {
                


            }*/
        }

    }
    void Mouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * Camerasensativity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Camerasensativity * Time.deltaTime;

            xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation =Quaternion.Euler(xRotation, 0f, 0f);
                PlayerBody.Rotate(Vector3.up* mouseX);
    }
    
}
