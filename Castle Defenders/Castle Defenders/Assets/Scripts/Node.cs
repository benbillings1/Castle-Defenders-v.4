using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject dragon;
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
        if (buildManager.GetDragonToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseDown()
    {
        if (buildManager.GetDragonToBuild() == null)
        {
            return;
        }

        if (dragon != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject dragonToBuild = buildManager.GetDragonToBuild();
        dragon = (GameObject)Instantiate(dragonToBuild, transform.position, transform.rotation);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
