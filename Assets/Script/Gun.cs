using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletprefab;
    public float bulletspeed;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet= Instantiate(bulletprefab, bulletSpawnpoint.position,bulletSpawnpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnpoint.forward* bulletspeed;
        }
    }
      

}
