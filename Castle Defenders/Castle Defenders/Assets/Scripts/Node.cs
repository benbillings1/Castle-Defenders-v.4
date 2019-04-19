using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject dragon;
    private Renderer rend;
    private Color startColor;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseDown()
    {
        if (dragon != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject dragonToBuild = BuildManager.instance.GetDragonToBuild();
        dragon = (GameObject)Instantiate(dragonToBuild, transform.position, transform.rotation);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
