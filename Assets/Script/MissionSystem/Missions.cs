using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

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

    private bool MissionComplete = false;

    static public bool Mission1 = false;
    static public bool Mission2 = false;
    static public bool Mission3 = false;
    static public bool Mission4 = false;
    static public bool Mission5 = false;

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

        if (!Mission2)
        {
            Needs = 2;
            Mission_Text.text = "Kill All Bandits";
            Mission_Needs.text = "Bandits Killed " + Need_current + "/" + Needs;


            if (Need_current >= Needs || MissionComplete)
            {
                MissionComplete = true;

                Mission_Text.text = "Go Back To The Office And Select Mission 2";
                Mission_Needs.text = "";
                Mission2B.interactable = true;

                if (MissionComplete && Need_current >= Needs)
                {
                    moneyplus(150);
                    Need_current = 0;

                }
            }

            /*if (Need_current >= Needs)
            {
                Mission_Text.text = "Go Back To The Office And Select Mission 2";
                Mission_Needs.text = "";
                Mission2B.interactable = true;
                moneyplus(150);
                Need_current = 0;

            }*/
            return;
        }

        if (!Mission3)
        {
            Mission_Text.text = "Go Catch Piggs";
            Mission_Needs.text = "Piggs Catched " + Need_current + "/" + Needs;

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

        if (!Mission4)
        {
            Mission_Text.text = "Go Talk To The Mom";
            Mission_Needs.text = "Stage Of Mission " + Need_current + "/" + Needs;
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

