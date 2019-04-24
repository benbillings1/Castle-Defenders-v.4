using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public DragonBlueprint fireDragon;
    public DragonBlueprint bombDragon;
    public DragonBlueprint timeDragon;

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
        Debug.Log("Bomb Dragon Selected");
        buildManager.SelectDragonToBuild(bombDragon);
    }

    public void SelectTimeDragon()
    {
        Debug.Log("Time Dragon Selected");
        buildManager.SelectDragonToBuild(timeDragon);
    }
}


