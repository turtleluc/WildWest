using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class Hurteffect : MonoBehaviour
{

    public Volume Postproces;
    private Vignette Redscreen;


    // Start is called before the first frame update
    void Start()
    {
        Redscreen.active = true;
    }
    // Update is called once per frame
    public void Effect()
    {
        Redscreen.active = true; 
    }
     
}
