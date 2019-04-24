using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonmovement : MonoBehaviour
{
    Transform curNodeTarget;
    public Transform[] waypoints;
    public Transform dragonModel;
    int curNodeIndex = 0;
    public float moveSpeed;
    public bool isSlow = false;
    public float originalSpeed = 10f;
    

    void Start()
    {
        curNodeTarget = waypoints[0];
        moveSpeed = originalSpeed;
    }

    
    void Update()
    {
        //Makes dragon move toward nodes
        Vector3 target = new Vector3(curNodeTarget.position.x, transform.position.y, curNodeTarget.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);

        //Fixes direction dragon is looking
        Vector3 forward = target - transform.position;
        dragonModel.transform.rotation = Quaternion.LookRotation(forward);

        if (Vector3.Distance(target,transform.position) < .1f )
        {
            curNodeIndex++;

            if(curNodeIndex >= waypoints.Length)
            {
                //Damage castle 
            }
            else
            {
                curNodeTarget = waypoints[curNodeIndex];
            }

            //Need gamecontroller to update instantiated dragons with waypoints 

            
        }

        if (isSlow == true)
        {
            StartCoroutine(FastAgain());
        }
        
    }


    public void SetNodes(Transform[] nodes)
    {
        waypoints = nodes;
    }

    IEnumerator FastAgain()
    {
        yield return new WaitForSeconds(15f);
        isSlow = false;
        moveSpeed = originalSpeed;

    }
}
