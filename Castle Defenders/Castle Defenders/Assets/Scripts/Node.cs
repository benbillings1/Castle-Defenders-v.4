using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    [Header("Optional")]
    public GameObject dragon;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {

        if (!buildManager.CanBuild)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (dragon != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildDragonOn(this);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
