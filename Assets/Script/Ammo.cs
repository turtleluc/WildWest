using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammo : MonoBehaviour
{
    public Slider ammosliderUI;

    public void Start()
    {

    }
    void Update()
    {
        ammosliderUI.value = Gun_System.currentAmmo;
    }
}
