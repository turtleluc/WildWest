using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 1f;
    [SerializeField] private LayerMask interactebleMask;

    private readonly Collider[] colliders = new Collider[3];

    [SerializeField] private int numFound;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, colliders, interactebleMask);

        if (numFound > 0 )
        {
            var interacteble = colliders[0].GetComponent<IInteracteble>();
            if ( interacteble != null && Input.GetKeyUp(KeyCode.E)) 
            {
                interacteble.Interact(this);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
