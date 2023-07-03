using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Gun_System : MonoBehaviour
{
    public float damage = 10f;
    public float range = 20f;

    public LayerMask enemyMask;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private AudioClip Gunsound;
    private AudioClip Reloadsound;


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
        Gunsound = GetComponent<AudioClip>();
        Reloadsound = GetComponent<AudioClip>();
        

        currentAmmo = maxAmmo;   
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        Debug.DrawLine(fpscam.transform.position, fpscam.transform.position + (fpscam.transform.forward * range), Color.red);
        
        
        if (Input.GetButtonDown("Fire1") && !Time.timeScale.Equals(0) && currentAmmo > 0)
        {
            Shoot();
            ShootAni();
        }


        if (currentAmmo < 6)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Reload();
            }
            return;
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
            audioSource1.Play();
        }
    }

    void Reload()
    {
        if (!Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW"))
        {
            Splyfus.Play("Reload_6");
            audioSource2.Play();

            if (!Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Reload_6"))
            {
                currentAmmo = maxAmmo;
            }
        }
    }
}
