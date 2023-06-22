
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int MoneyPlus = 10;

    public float health = 50;

    private float m_Thrust = 375;

    private AudioSource Deathsound;

    private int Addeverysecond = 1;
    private float deletetimer = 0;


    public GameObject ArmL;
    public GameObject ArmR;

    Rigidbody rb;

    public NavMeshAgent Navmesh;

    public ConfigurableJoint L;
    public ConfigurableJoint R;
    
    public void Takedamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Navmesh =GetComponent<NavMeshAgent>();

        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = true;

        Deathsound = GetComponent<AudioSource>();
        
        ArmL.GetComponentInChildren<BoxCollider>().enabled = false;
        ArmR.GetComponentInChildren<BoxCollider>().enabled = false;


        rb.freezeRotation = true;

        L.angularXMotion = ConfigurableJointMotion.Locked;
        L.angularYMotion = ConfigurableJointMotion.Locked;
        L.angularZMotion = ConfigurableJointMotion.Locked;

        R.angularXMotion = ConfigurableJointMotion.Locked;
        R.angularYMotion = ConfigurableJointMotion.Locked;
        R.angularZMotion = ConfigurableJointMotion.Locked;
    }

    void Update()
    {
        Debug.Log(deletetimer);
    }
    void Die()
    {
           
            GetComponent<AI>().enabled = false;
            Navmesh.enabled= false;

            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<BoxCollider>().enabled = false;

            ArmL.GetComponentInChildren<BoxCollider>().enabled = true;
            ArmR.GetComponentInChildren<BoxCollider>().enabled = true;


            rb.freezeRotation = false;
            rb.AddForceAtPosition(transform.forward * -m_Thrust, rb.transform.position + (Vector3.up * 1.5f));
            rb.AddForce(transform.up * 300f);

            L.angularXMotion = ConfigurableJointMotion.Free;
            L.angularYMotion = ConfigurableJointMotion.Free;
            L.angularZMotion = ConfigurableJointMotion.Free;

            R.angularXMotion = ConfigurableJointMotion.Free;
            R.angularYMotion = ConfigurableJointMotion.Free;
            R.angularZMotion = ConfigurableJointMotion.Free;



        Deathsound.Play();
        Missions.Need_current++;
        deletetimer += Addeverysecond * Time.deltaTime;

        if (deletetimer > 5)
        {
            Destroy(gameObject);
            deletetimer = 0;
        }
    }
}
