using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject dragon;

    

    void Start()
    {
        
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


}
