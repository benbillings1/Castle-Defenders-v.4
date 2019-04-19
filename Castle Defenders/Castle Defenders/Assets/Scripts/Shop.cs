using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseFireDragon()
    {
        Debug.Log("Fire Dragon Bought");
        buildManager.SetDragonToBuild(buildManager.standardDragonPrefab);
    }

    public void PurchaseBombDragon()
    {
        Debug.Log("Bomb Dragon Bought");
        buildManager.SetDragonToBuild(buildManager.anotherDragonPrefab);
    }
}

