using System.Collections;
using System.Collections.Generic;

using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class Hurteffect : MonoBehaviour
{

    public Volume Postproces;
    public float timer = 0f;
    public float Addeverysecond = 1f; 
    public int DelayAmount = 1;


    // Start is called before the first frame update
    void Start()
    {
        Postproces.weight = 0;
    }

    void Update()
    {
        Debug.Log(timer);

        if(Postproces.weight < 0)
        {
            Postproces.weight = 0f;
        }
        
        if (Postproces.weight == 1)
        {
            timer += Addeverysecond * Time.deltaTime;
        }

        if (timer >= 1)
        {
            Postproces.weight -= 0.01f;
            timer = 1;

        }

        if (Postproces.weight == 0)
        {
            timer = 0;
        }
    }
    // Update is called once per frame
    public void Effect()
    {
        Postproces.weight = 1;

    }
}