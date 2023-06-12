
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int MoneyPlus = 10;

    public float health = 50f;

    private float m_Thrust = 375f;

    public GameObject DetectionZone;

    Rigidbody rb;

    public NavMeshAgent Navmesh;

    public ConfigurableJoint L;
    public ConfigurableJoint R;
    public void Takedamage(float amount)
    {
        health-=amount;
        if(health <= 0f)
        {
            Die();
            Money.moneyValue += MoneyPlus;

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Navmesh =GetComponent<NavMeshAgent>();

        Navmesh.enabled = true;

        rb.freezeRotation = true;

        L.angularXMotion = ConfigurableJointMotion.Locked;
        L.angularYMotion = ConfigurableJointMotion.Locked;
        L.angularZMotion = ConfigurableJointMotion.Locked;

        R.angularXMotion = ConfigurableJointMotion.Locked;
        R.angularYMotion = ConfigurableJointMotion.Locked;
        R.angularZMotion = ConfigurableJointMotion.Locked;
    }

    void Die()
    {
        GetComponent<AI>().enabled = false;
        Navmesh.enabled= false;
        DetectionZone.gameObject.SetActive(false);

            rb.freezeRotation = false;
            rb.AddForce(transform.forward * -m_Thrust);
            rb.AddForce(transform.up * 300f);
            L.angularXMotion = ConfigurableJointMotion.Free;
            L.angularYMotion = ConfigurableJointMotion.Free;
            L.angularZMotion = ConfigurableJointMotion.Free;

            R.angularXMotion = ConfigurableJointMotion.Free;
            R.angularYMotion = ConfigurableJointMotion.Free;
            R.angularZMotion = ConfigurableJointMotion.Free;

        
    }
}
