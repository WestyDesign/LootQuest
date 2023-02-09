#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

public class MainMenu : MonoBehaviour
{
    /*
        Click on the buttons, then add one of the two methods below via the 'OnClicked' part that handles events in the inspector.         
    */

    public GameObject playButton; // play button

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    { SceneManager.LoadScene("GameScene"); } // Loads the first level

    public void Level2()
    { SceneManager.LoadScene("Level2"); } // loads the second level

    public void Level3()
    { SceneManager.LoadScene("Level3"); } // loads the second level

    public void Level4()
    { SceneManager.LoadScene("Level4"); } // loads the second level

    public void Level5()
    { SceneManager.LoadScene("Level5"); } // loads the second level

    public void Level6()
    { SceneManager.LoadScene("Level6"); } // loads the second level

    public void QuitGame()
    {
        Debug.Log("QUIT!"); // Prints 'QUIT' if testing this in the editor.
        Application.Quit(); // Closes the game.
    }
}