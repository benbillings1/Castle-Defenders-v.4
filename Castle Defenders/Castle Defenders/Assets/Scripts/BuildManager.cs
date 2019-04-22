using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Buildmanager in scene!");
        }
        instance = this;
        
    }

    public GameObject standardDragonPrefab;
    public GameObject anotherDragonPrefab;
    

    private DragonBlueprint dragonToBuild;
    
    public bool CanBuild { get { return dragonToBuild != null; } }

    public void BuildDragonOn (Node node)
    {
        if (Currency.gold < dragonToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        Currency.gold -= dragonToBuild.cost;


        GameObject dragon = (GameObject)Instantiate(dragonToBuild.prefab, node.transform.position, Quaternion.identity);
        node.dragon = dragon;

        Debug.Log("Dragon built! Gold left: " + Currency.gold.ToString());
    }

    public void SelectDragonToBuild(DragonBlueprint dragon)
    {
        dragonToBuild = dragon;
    }
}
