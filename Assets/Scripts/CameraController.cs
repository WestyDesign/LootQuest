#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

// Using this tutorial: https://youtu.be/GChUpPnOSkg

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player; // the player's position
    [SerializeField] Transform crab; // the crab's position

    public bool notCrab = true;

    void Update()
    {
        if(notCrab == true)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(crab.position.x, crab.position.y, transform.position.z);
        }
    }
}