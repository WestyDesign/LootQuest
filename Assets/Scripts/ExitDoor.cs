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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                finishSound.Play();
                CompleteLevel();
            }
        }
    }

    private void CompleteLevel()
    {

    }
}
