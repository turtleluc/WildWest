using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MissionSelectionVisible : MonoBehaviour, IInteracteble
{

    public GameObject Missionscreen;
    public GameObject MissionneedsScreen;

    public TMP_Text Misstion_Tit;
    public TMP_Text Misstion_Des;

    int CurrentMission = 0;

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
    public void MissionActivate()
    {
        if (CurrentMission == 1)
        {
            Missions.Mission1 = true;

        }

        if (CurrentMission == 2)
        {

            Missions.Mission2 = true;



        }

        if (CurrentMission == 3)
        {

            Missions.Mission3 = true;


        }
        if (CurrentMission == 4)
        {
            
            Missions.Mission4 = true;
            

        }
        if (CurrentMission == 5)
        {
         
            Missions.Mission5 = true;

        }
        Missions.Need_current = 0;
        Missions.MissionComplete = false;
        Debug.Log("ButtonActiveate");
        
    }
    public void Mission1Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "Tutorial";
        Misstion_Des.text = "You get a very simple mission of killing one bandit. you lern that the bandits are always red and how a weapon shoots";
        CurrentMission = 1;
    }
    public void Mission2Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "Ohh no the general store is being robbed. go save the town folk and kill all bandits.";
        CurrentMission = 2;
    }
    public void Mission3Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "Lost Kid";
        Misstion_Des.text = "Talk to the Lost Kids mom and find her kid.";
        CurrentMission = 3;
    }
    public void Mission4Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "Saloon Captured";
        Misstion_Des.text = "Ohh no the saloon is being captured. go save the town folk and kill all bandits.";
    }
    public void Mission5Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "REVANGE";
        Misstion_Des.text = "The man who killed your wife has returnd to your town KILL HIM for revange (and the safety of the town folk ofcourse).";
    }
}

