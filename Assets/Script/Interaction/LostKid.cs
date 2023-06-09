using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LostKid : MonoBehaviour, IInteracteble
{

   

    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public GameObject DialogToggle;
    public TMP_Text text;
    private int slide = 0;
    public static bool dialogEnded = false;

    public void Interact(Interactor interactor)
    {
        if (Missions.Mission3 == true)
        { 
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        DialogToggle.SetActive(true);
        }
    }

    void Update()  
    {
        dialog();
    }   


    void dialog()
    {
        if (slide == 0) 
        {
            
            text.text = "The Mother: Are you the sheriff?";
        }

        if (slide == 1)
        {
            text.text = "Sheriff: Yes i am.";
        }

        if(slide == 2)
        {
            text.text = "The Mother: My son has been kidnapped!!!!";
        }

        if (slide == 3)
        {
            text.text = "Sheriff: OH MY CACTUS! Where is he?";
        }

        if (slide == 4)
        {
            text.text = "The Mother: They went past the crashed train. I dont know where they are now.  ";
        }

        if (slide == 5)
        {
            DialogToggle.SetActive(false);
            slide = 0;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            dialogEnded = true;
        }

       
    }
    public void ButtonPress()
    {
        slide++;
    }

}
