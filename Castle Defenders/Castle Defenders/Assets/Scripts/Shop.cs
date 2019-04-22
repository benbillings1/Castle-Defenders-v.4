using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public DragonBlueprint fireDragon;
    public DragonBlueprint bombDragon;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectFireDragon()
    {
        Debug.Log("Fire Dragon Selected");
        buildManager.SelectDragonToBuild(fireDragon);
    }

    public void SelectBombDragon()
    {
        Debug.Log("Bomb Dragon Seected");
        buildManager.SelectDragonToBuild(bombDragon);
    }
}

