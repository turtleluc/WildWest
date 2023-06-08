using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GsDoorBack : MonoBehaviour, IInteracteble
{

    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    public GameObject Player;

    public void Interact(Interactor interactor)
    {
        Debug.Log("Door");
        Player.transform.position = new Vector3(14f, 1.25f, -4.2f);
        Player.transform.rotation = Quaternion.Euler(0, -90, 0);
    }

   
}
