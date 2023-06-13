using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Gun_System : MonoBehaviour
{
    public float damage = 10f;
    public float range = 20f;

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
        if (Time.timeScale > 0f)
        {
            if (currentAmmo <= 0)
            {
                if (Input.GetKey(KeyCode.R))
                {

                    Reload();

                }
                return;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                ShootAni();
            }
        }
    

    }

    void Shoot()
    {

        RaycastHit hit;
        if (!this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW") && !this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Reload_6"))
        {
            Ammo ammoUI = GetComponent<Ammo>();
            Muzzle.Play();
            Smoke.Play();

            currentAmmo--;

            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range)) 
            { 
                Debug.Log(hit.transform.name);

                Target target =  hit.transform.GetComponent<Target>();
                if (target != null) 
                {
                    target.Takedamage(damage);

                }
            }
        }
    }

    void ShootAni()
    {
        if (!this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW") && !this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("Reload_6"))
        {

            Splyfus.Play("POW");
        }
    }

    void Reload()
    {
        if (!this.Splyfus.GetCurrentAnimatorStateInfo(0).IsName("POW"))
        {
            Splyfus.Play("Reload_6");
                currentAmmo = maxAmmo;
        }
    }
}
