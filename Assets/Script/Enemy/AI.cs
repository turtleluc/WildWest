using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class AI : MonoBehaviour
    {
    GameObject Player;

    NavMeshAgent agent;

    [SerializeField] LayerMask groundlayer, playerlayer;

    Vector3 destpoint;
    bool walkpointSet;
    [SerializeField] float Walkrange;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet)
        {
            Searchfordest();
        }
        if (walkpointSet)
        {
            agent.SetDestination(destpoint);
        }
        if (Vector3.Distance(transform.position, destpoint) < 10) walkpointSet = false;
    }

    void Searchfordest()
    {
        float z = Random.Range(-Walkrange, Walkrange);
        float x = Random.Range(-Walkrange, Walkrange);

        destpoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destpoint, Vector3.down, groundlayer))
        {
            walkpointSet= true;
        }
    }

}
    

