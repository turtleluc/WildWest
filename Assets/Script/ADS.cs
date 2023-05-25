using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{

    public Animator Aimfus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.Aimfus.GetCurrentAnimatorStateInfo(0).IsName("POW") && !this.Aimfus.GetCurrentAnimatorStateInfo(0).IsName("Reload_6"))
        {
            Aim();
        }
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Aimfus.Play("Aim");
        }

        else if (Input.GetMouseButtonUp(1))
        {
            Aimfus.Play("Idle");
        }
        
    }
}
