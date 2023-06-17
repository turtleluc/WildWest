using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Gun_System : MonoBehaviour
{
    public float damage = 10f;
    public float range = 20f;

    public LayerMask enemyMask;

    public int maxAmmo = 6;
    public static int currentAmmo;

    public Animator Splyfus;

    public Camera fpscam;

    public ParticleSystem Muzzle;
    public ParticleSystem Smoke;

    
    void Start()
    {
        Muzzle.Stop();
        Smoke.Stop();
        Splyfus = GetComponent<Animator>();
       
        currentAmmo = maxAmmo;   
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        Debug.DrawLine(fpscam.transform.position, fpscam.transform.position + (fpscam.transform.forward * range), Color.red);

        if (currentAmmo <= 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Reload();
            }
            return;
        }


        if (Input.GetButtonDown("Fire1") && !Time.timeScale.Equals(0))
        {
            Shoot();
            ShootAni();
        }
       
    }
    void Shoot()
    {

        RaycastHit hit;
        if (!Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW") && !Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Reload_6"))
        {

            Muzzle.Play();
            Smoke.Play();

            currentAmmo--;
            Debug.Log("Shoot");



            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range, enemyMask))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.Takedamage(damage);

                }
            }

            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }
    }

    void ShootAni()
    {
        if (!Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW") && !Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Reload_6"))
        {
            Splyfus.Play("POW");
        }
    }

    void Reload()
    {
        if (!Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW"))
        {
            Splyfus.Play("Reload_6");
            currentAmmo = maxAmmo;
        }
    }
}
