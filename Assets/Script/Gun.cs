using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletprefab;
    public float bulletspeed;
    public int Timer;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Ammo.Ammovalue > 0)
            {

                var bullet = Instantiate(bulletprefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnpoint.forward * bulletspeed;
                Ammo.Ammovalue -= 1;
                Debug.Log(Timer);
                animator.GetComponent<Animator>().SetBool("Shoot", true);
            }

        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            animator.GetComponent<Animator>().SetBool("Shoot", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Ammo.Ammovalue < 6)
            {
                do
                {


                    Ammo.Ammovalue++;
                } while (Ammo.Ammovalue < 6);
            }
        }
    }




}
