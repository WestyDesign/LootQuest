#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

// Using this tutorial: https://youtu.be/GChUpPnOSkg

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player; // the player's position

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}