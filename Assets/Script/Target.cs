using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int MoneyPlus = 10;
    public float health = 50f;
    private float m_Thrust = 300f;
    Rigidbody rb;

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
        rb.freezeRotation = false;
        rb.AddForce(transform.forward * m_Thrust);
        L.angularXMotion = ConfigurableJointMotion.Free;
        L.angularYMotion = ConfigurableJointMotion.Free;
        L.angularZMotion = ConfigurableJointMotion.Free;

        R.angularXMotion = ConfigurableJointMotion.Free;
        R.angularYMotion = ConfigurableJointMotion.Free;
        R.angularZMotion = ConfigurableJointMotion.Free;
    }
}
