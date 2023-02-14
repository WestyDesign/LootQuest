# region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class ExitDoor : MonoBehaviour
{
    private AudioSource finishSound;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            finishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {

    }
}
