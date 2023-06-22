using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Health : MonoBehaviour
{
    public Slider slider;

    public GameObject Panel;

    public float health;
    public int maxHealth;
    public int damage;

    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;

    }
    void Update()
    {
        slider.value = health;
        Dead();
    }

    public void SetMaxHealth()
    {
 
    }

    public void SetHealth()
    {

    }

    public void TakeDamage()
    {
        health -= damage;
    }

    void Dead()
    {
        if (health <= 0)
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
