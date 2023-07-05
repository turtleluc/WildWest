using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ShootingAI : MonoBehaviour
{
    // Start is called before the first frame update

    bool Detected;
    GameObject Target;
    public Transform enemy;

    public GameObject HealthbarUI;
    public Volume RedscreenUI;

    public Transform Shootingpoint;

    public Animator BanditMator;

    public float shootspeed = 1.5f;
    public float timetoshoot;

    public float range = 20f;

    public float originaltime;


    void Start()
    {
        originaltime = timetoshoot;
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (gameObject.transform.forward * range), Color.red);
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
            BanditMator.Play("Shooting");

            if (timetoshoot <= 0) 
            {
                timetoshoot = originaltime;
                ShootPlayer();

            }
            
        }

       

        else
        {
            BanditMator.Play("Enemyanimation");
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Detected = false;
           
        }
    }

    public void ShootPlayer()
    {
        RaycastHit hit;

        Health playerhealth = HealthbarUI.GetComponent<Health>();
/*        Hurteffect HurteffectUI = RedscreenUI.GetComponent<Hurteffect>();*/

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {

             playerhealth.TakeDamage();
            /* HurteffectUI.Effect();*/

        }
    }
}
