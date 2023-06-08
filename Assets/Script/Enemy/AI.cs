using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Aitest
{
    public class AI : MonoBehaviour
    {

        public Transform target;

        private AIRefrences enemyrefrences;

        private float shootdistances;

        private float pathUpdateDeadline;

        private void Awake()
        {
            enemyrefrences = GetComponent<AIRefrences>();    
        }

        // Start is called before the first frame update
        void Start()
        {
            shootdistances = enemyrefrences.navMeshagent.stoppingDistance;

        }

        // Update is called once per frame
        void Update()
        {
            if(target!= null) 
            {
                bool inRange = Vector3.Distance(transform.position, target.position) <= shootdistances;

                if(inRange) 
                {
                    Lookattarget();
                }
                else
                {
                    UpdatePath();
                }
            }
        }

        private void Lookattarget()
        {
            Vector3 lookPos = target.position- transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation =Quaternion.Slerp(transform.rotation,rotation,0.2f);

        }
        private void UpdatePath()
        {
            /*NavMeshAgent.SetDestination(target.position);*/   

            if(Time.time >= pathUpdateDeadline) 
            {
                Debug.Log("Updating Path");
                pathUpdateDeadline= Time.time+ enemyrefrences.pathupdatedelay;
                enemyrefrences.navMeshagent.SetDestination(target.position);
            }
        }
    }
}

