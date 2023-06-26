using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    GameObject Player;

    NavMeshAgent agent;

    Animator EnemyAIAnimation;

    [SerializeField] LayerMask groundlayer, playerlayer;

    Vector3 destpoint;
    bool walkpointSet;
    [SerializeField] float Walkrange;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        EnemyAIAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        Patrol();
  /*      AnimationSet();*/
    }

    void Patrol()
    {
        if (!walkpointSet)
        {
            SearchForDestination();
        }

        if (walkpointSet)
        {
            

            agent.SetDestination(destpoint);

        }
        EnemyAIAnimation.Play("WalkingEnemy");

        if (Vector3.Distance(transform.position, destpoint) < 10)
        {
            walkpointSet = false;

        }

        void SearchForDestination()
        {
            float z = Random.Range(-Walkrange, Walkrange);
            float x = Random.Range(-Walkrange, Walkrange);
            EnemyAIAnimation.Play("Enemyanimation");

            destpoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

            if (Physics.Raycast(destpoint, Vector3.down, groundlayer))
            {
                walkpointSet = true;
            }

        }
    }
}

       
/*    }
    void AnimationSet()
    {
        if (agent.acceleration != 0)
        {
        

        }
        else
        {

            EnemyAIAnimation.Play("Enemyanimation");
        }
    }
}
    */

