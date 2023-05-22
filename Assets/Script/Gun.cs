using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 20f;

    public Camera fpscam;

    public ParticleSystem Muzzle;
    public ParticleSystem Smoke;

    private void Start()
    {
        Muzzle.Stop();
        Smoke.Stop();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        Muzzle.Play();
        Smoke.Play();

        RaycastHit hit;
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
