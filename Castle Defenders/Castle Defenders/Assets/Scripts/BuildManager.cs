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
    

    private GameObject dragonToBuild;

    public GameObject GetDragonToBuild()
    {
        return dragonToBuild;
    }

    public void SetDragonToBuild(GameObject dragon)
    {
        dragonToBuild = dragon;
    }
}
