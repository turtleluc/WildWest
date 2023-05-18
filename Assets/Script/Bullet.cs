using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    private LayerMask Enemy;

    void Awake()
    {
       Destroy(gameObject,life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)


            Destroy(collision.gameObject);
            Destroy(gameObject);
    }
}
