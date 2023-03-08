# region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

public class ExitDoor : MonoBehaviour
{
    private AudioSource finishSound;
    [SerializeField] private GameObject LCUI;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted) // won't work for the crab, probably a good thing
            // also - if 'levelCompleted' is later used to track level unlocks, this may need to be tweaked
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                finishSound.Play();
                levelCompleted = true; // prevents sound effect spam
                LCUI.SetActive(true);
            }
        }
    }

    public void CompleteLevel() // for loading the next level
    { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1); }

    public void ReplayLevel() // reloads the current level.
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public void BacktoMenu() // for loading the next level
    {
        DataManager.Instance.SaveGame();
        SceneManager.LoadScene("MainMenu"); // loads the menu scene    
    }
}