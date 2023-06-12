using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MissionSelectionVisible : MonoBehaviour, IInteracteble
{

    public GameObject Missionscreen;
    public GameObject MissionneedsScreen;

    public TMP_Text Misstion_Tit;
    public TMP_Text Misstion_Des;


    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    

    public void Interact(Interactor interactor)
    {
        Missionscreen.active = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        MissionneedsScreen.active = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Missionscreen.active = false;
            MissionneedsScreen.active = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void Mission1Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "Ohh no the general store is being robbed. go save the town folk and kill or cature all bandits.";
    }
    public void Mission2Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "General-Store Robbery";
    }
    public void Mission3Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "General-Store Robbery";
    }
    public void Mission4Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "General-Store Robbery";
    }
    public void Mission5Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "General-Store Robbery";
    }
}

