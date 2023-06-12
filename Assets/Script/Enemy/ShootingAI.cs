using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
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


    public float range = 20f;

    private int damage = 10;

    public float originaltime;

    void Start()
    {
        originaltime = timetoshoot;
    }

    // Update is called once per frame
    void Update()
    {
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

            if(timetoshoot <= 0) 
            {
                timetoshoot = originaltime;
                ShootPlayer();
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

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            PlayerMovement playerhealth = GetComponent<PlayerMovement>();

                playerhealth.TakeDamage(10);
        }
    }
}