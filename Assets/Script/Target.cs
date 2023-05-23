using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int MoneyPlus = 10;
    public float health = 50f;
    public void Takedamage(float amount)
    {
        health-=amount;
        if(health <= 0f)
        {
            Die();
            Money.moneyValue += MoneyPlus;

        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
