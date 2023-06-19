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
        Player.transform.position = new Vector3(26.30f, 16.50f, -22f);
        Player.transform.rotation = Quaternion.Euler(0, -95, 0);
    }

   
}
