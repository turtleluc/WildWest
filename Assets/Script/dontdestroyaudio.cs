using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyaudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
