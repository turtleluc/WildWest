using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GsDoorToInside : MonoBehaviour, IInteracteble
{

    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    public GameObject Player;

    public void Interact(Interactor interactor)
    {
        Debug.Log("Door");
        Player.transform.position = new Vector3(145f, 22f, -322f);
        Player.transform.rotation = Quaternion.Euler(0, 180, 0);
    }


}
