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

    void Start()
    {
        dragonToBuild = standardDragonPrefab;
    }

    private GameObject dragonToBuild;

    public GameObject GetDragonToBuild()
    {
        return dragonToBuild;
    }
}
