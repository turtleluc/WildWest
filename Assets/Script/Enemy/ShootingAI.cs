using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    // Start is called before the first frame update

    bool Detected;
    GameObject Target;
    public Transform enemy;

    public GameObject Projectile;
    public Transform Shootingpoint;

    public float shootspeed = 1.5f;
    public float timetoshoot = 1.5f;
    public float deletetimer;

    float originaltime;

    void Start()
    {
        originaltime = timetoshoot;
    }

    // Update is called once per frame
    void Update()
    {
        deletetimer += Time.deltaTime;
        if (Detected) 
        {
            enemy.LookAt(Target.transform.position);
        }
        
    
    }
    private void FixedUpdate()
    {
        if (Detected)
        {
            timetoshoot -= Time.deltaTime;

            if(timetoshoot < 0) 
            { 
                ShootPlayer();
                timetoshoot = originaltime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Detected= true;
            Target = other.gameObject;
        }
    }

    public void ShootPlayer()
    {
        GameObject currentbullet = Instantiate(Projectile, Shootingpoint.position, Shootingpoint.rotation);
        Rigidbody rig = currentbullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward*shootspeed,ForceMode.VelocityChange);
        

       if(deletetimer <= 5)
            
            deletetimer = 0;
    }
}
