using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GS_Door : MonoBehaviour, IInteracteble
{

    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public void Interact(Interactor interactor)
    {
        Debug.Log("Door");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
