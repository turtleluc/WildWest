using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missions : MonoBehaviour
{

    public TMP_Text Mission_Text;
    public TMP_Text Mission_Needs;

    public Button Mission1B;
    public Button Mission2B;
    public Button Mission3B;
    public Button Mission4B;
    public Button Mission5B;

    static public int Needs = 9;
    static public int Need_current = 0;

    static public bool MissionComplete = false;

    static public bool Mission1 = false;
    static public bool Mission2 = false;
    static public bool Mission3 = false;
    static public bool Mission4 = false;
    static public bool Mission5 = false;

    public GameObject Bandits1;
    public GameObject Bandits2;
    public GameObject Bandits3;
    public GameObject Bandits4;
    public GameObject Bandits5;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MissionManager();
    }
    void MissionManager()
    {
        if (!Mission1)
        {
            Mission_Text.text = "Go To The Sherrift Office To Select A Mission";
            Mission_Needs.text = "";
            Mission2B.interactable = false;

            

            return;
        }

        // Mission 1
        if (!Mission2)
        {
            
            Needs = 1;
            Mission_Text.text = "Complete The Tutorial";
            Mission_Needs.text = "Kill The Bandit. bandits are always the color red";
            Bandits1.active = true;

            if (Need_current >= Needs || MissionComplete)
            {
                MissionComplete = true;

                Mission_Text.text = "Go Back To The Office And Select Mission 2";
                Mission_Needs.text = "";
                Mission2B.interactable = true;
            
                if (MissionComplete && Need_current >= Needs)
                {
                    moneyplus(50);
                    Need_current = 0;

                }
            }

            return;
        }

        // Mission 2
        if (!Mission3)
        {
            
            Needs = 3;
            Mission_Text.text = "Kill All Bandits";
            Mission_Needs.text = "Bandits Killed " + Need_current + "/" + Needs;
            Bandits2.active = true;

            if (Need_current >= Needs || MissionComplete)
            {
                MissionComplete = true;

                Mission_Text.text = "Go Back To The Office And Select Mission 3";
                Mission_Needs.text = "";
                Mission3B.interactable = true;

                if (MissionComplete && Need_current >= Needs)
                {
                    moneyplus(75);
                    Need_current = 0;

                }
            }
            return;

        }

        // Mission 3
        if (!Mission4)
        {
            Needs = 4;
            Mission_Text.text = "Go Talk To The Mom";
            Mission_Needs.text = "";
            Bandits3.active = true;
            if (LostKid.dialogEnded)
            {
                Mission_Text.text = "Search The Kid And Kill The Bandits";
                Mission_Needs.text = "Bandits Killed " + Need_current + "/" + Needs;
            }
            if (Need_current >= Needs || MissionComplete)
            {
                MissionComplete = true;

                Mission_Text.text = "Go Back To The Office And Select Mission 4";
                Mission_Needs.text = "";
                Mission4B.interactable = true;

                if (MissionComplete && Need_current >= Needs)
                {
                    moneyplus(150);
                    Need_current = 0;

                }
            }
            return;
        }


        // Mission 4
        if (!Mission5)
        {
            Needs = 3;
            Mission_Text.text = "Kill The Bandits";
            Mission_Needs.text = "Bandits Killed " + Need_current + "/" + Needs;
            Bandits4.active = true;

            if (Need_current >= Needs || MissionComplete)
            {
                MissionComplete = true;

                Mission_Text.text = "Go Back To The Office And Select Mission 4";
                Mission_Needs.text = "";
                Mission4B.interactable = true;

                if (MissionComplete && Need_current >= Needs)
                {
                    moneyplus(50);
                    Need_current = 0;

                }
            }
            return;
        }

        // Mission 5
        if (Mission5)
        {

            Mission_Text.text = "Defeat The Outlaw";
            Mission_Needs.text = "";
            Bandits5.active = true;
            if (Need_current >= Needs || MissionComplete)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            }
            return;
        }

    }

    public void ButtonClick()
    {
        Need_current++;
    }

    void moneyplus(int plus)
        {
            Money.moneyValue += plus;
        }
}

