using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonmovement : MonoBehaviour
{
    Transform curNodeTarget;
    public Transform[] waypoints;
    public Transform dragonModel;
    int curNodeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        curNodeTarget = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Makes dragon move toward nodes
        Vector3 target = new Vector3(curNodeTarget.position.x, transform.position.y, curNodeTarget.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10f);

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
    }
}
