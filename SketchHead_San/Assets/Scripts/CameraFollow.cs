using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Target object position
    [Header("Target Object")]
    public Transform target;

    // Update is called once per frame
    private void Update()
    {
        //if target position on y axis is greater than camera position
        if(target.position.y > transform.position.y)
        {
            //camera will follow the targets position
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
    }
}
