using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    Text currency;
    public static int gold = 200;

    public void Start()
    {
        currency = GetComponent<Text>();
        currency.text = "Gold: " + gold.ToString();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        currency.text = "Gold: " + gold.ToString();
    }


}
