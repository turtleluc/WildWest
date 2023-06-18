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

        Debug.Log("ButtonActiveate");
        
    }
    public void Mission1Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "Ohh no the general store is being robbed. go save the town folk and kill or cature all bandits.";
        CurrentMission = 1;
    }
    public void Mission2Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store Robbery";
        Misstion_Des.text = "General-Store Robbery";
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
        Misstion_Tit.text = "Gen dpoija djja lj; lbbery";
        Misstion_Des.text = "Genkskajjd j jj adj jalskj k obbery";
    }
    public void Mission5Sel()
    {
        MissionneedsScreen.active = true;
        Misstion_Tit.text = "General-Store ljah ds lkk; lk ;lk a lkjfkjbery";
        Misstion_Des.text = "General-Stord hab kl d; ;obbery";
    }
}

