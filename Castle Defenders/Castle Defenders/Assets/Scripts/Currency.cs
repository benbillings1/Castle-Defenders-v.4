using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text Text;
    public static int gold;
    public int startGold = 400;
    

    public void Start()
    {
        gold = startGold;
        Text.text = "Gold: " + gold.ToString();
    }

    public void Update()
    {
        Text.text = "Gold: " + gold.ToString();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Text.text = "Gold: " + gold.ToString();
    }


}
