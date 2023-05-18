using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    public static int Ammovalue = 6;
    TMP_Text ammo;

    void Start()
    {
        ammo = GetComponent<TMP_Text>();
    }

    void Update()
    {
        ammo.text = "Ammo = " + Ammovalue + "/6";
    }
}
