using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammo : MonoBehaviour
{
    public Slider ammosliderUI;

    public void ammoslider()
    {
        ammosliderUI.value = 6;
    }

    void Update()
    {
        
    }
}
