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
            
            text.text = "Lost kid: Are you the sheriff?";
        }

        if (slide == 1)
        {
            text.text = "Sheriff: Yes i am, your mom is very worried about you.";
        }

        if(slide == 2)
        {
            text.text = "Lost kid: Oh i'm sorry, you see i lost my teddy and i was looking for him.";
        }

        if (slide == 3)
        {
            text.text = "Sheriff: Come I will bring you to your mom and i'll find your teddy ok?";
        }

        if (slide == 4)
        {
            text.text = "Lost kid: Oh ok.";
        }

        if (slide == 5)
        {
            DialogToggle.SetActive(false);
            slide = 0;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

       
    }
    public void ButtonPress()
    {
        slide++;
    }

}
