using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Aitest
{
    [DisallowMultipleComponent]
    public class AIRefrences : MonoBehaviour
    {
        public NavMeshAgent navMeshagent;
        [Header("Stats")]

        public float pathupdatedelay = 0.2f;

        public void Awake()
        {
            navMeshagent = GetComponent<NavMeshAgent>();
        }
    }
}
  

