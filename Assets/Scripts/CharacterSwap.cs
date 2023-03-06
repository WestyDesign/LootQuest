#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class CharacterSwap : MonoBehaviour
{
    public Transform character; // the main man, cap'n clown nose
    public List<Transform> possibleCharacters; // list the transforms of cap'n and crabby
    public int whichCharacter; // keeps track of who the player is controlling
    public Animator playerAnim;
    public Animator crabAnim;
    public CameraController cam;

    private void Start()
    {
        crabAnim.SetBool("OutOfControl", true);
        playerAnim.SetBool("OutOfControl", false);

        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // if X is pressed
        {
            if (whichCharacter == 0) // and ye're the captain
            {
                playerAnim.SetBool("OutOfControl", true);
                crabAnim.SetBool("OutOfControl", false);
                cam.notCrab = false;
                whichCharacter = possibleCharacters.Count - 1; // become crab
            }
            else
            {
                crabAnim.SetBool("OutOfControl", true);
                playerAnim.SetBool("OutOfControl", false);
                cam.notCrab = true;
                whichCharacter -= 1; // else ye're the crab, become captain
            }
            Swap();
        }
        else if (character.GetComponent<PlayerMovement>().enabled) // if the current character is enabled
        {
            for (int i = 0; i < possibleCharacters.Count; i++)
            {
                if (possibleCharacters[i] != character)
                {
                    possibleCharacters[i].GetComponent<PlayerMovement>().enabled = false;
                }
            }
        }
    }

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        character.GetComponent<PlayerMovement>().enabled = true;

        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }   
}
