using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    TMP_Text ammo;

    void Start()
    {
        ammo = GetComponent<TMP_Text>();
    }

    void Update()
    {
        ammo.text = "Ammo = " + Gun_System.currentAmmo + "/6";
    }
}
