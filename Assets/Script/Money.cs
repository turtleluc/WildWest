using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static int moneyValue = 100;
    TMP_Text money;

    void Start()
    {
        money = GetComponent<TMP_Text>();
    }

    void Update()
    {
        money.text = "$ " + moneyValue;
    }
}
