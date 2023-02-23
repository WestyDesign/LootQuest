#region 'using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#endregion

public class LevelSelect : MonoBehaviour
{
    public DataManager dataManager;
    public TextMeshProUGUI level1Text;
    //public TextMeshProUGUI level2Text;
    //public TextMeshProUGUI level3Text;

    private void Start()
    {
        DataManager.Instance.LoadGame(); // loads the game

        float level1Percentage = ((float)DataManager.Instance.Level1Silver + (float)DataManager.Instance.Level1Gold) / 15f;
        level1Percentage = Mathf.Clamp01(level1Percentage); // clamp the percentage value between 0 and 1

        int level1PercentageInt = (int)(level1Percentage * 100f); // convert the percentage to an integer between 0 and 100
        level1Text.text = level1PercentageInt + "%";


        // Calculate percentages for each level based on collectibles picked up
        //float level2Percentage = ((float)dataManager.Level2Silver + (float)dataManager.Level2Gold + 3f * ((float)dataManager.Level2Green + (float)dataManager.Level2Red + (float)dataManager.Level2Blue)) / 20f;
        //float level3Percentage = ((float)dataManager.Level3Silver + (float)dataManager.Level3Gold + 3f * ((float)dataManager.Level3Green + (float)dataManager.Level3Red + (float)dataManager.Level3Blue)) / 20f;

        // Display percentages for each level in TextMeshPro components
        //level2Text.text = "Level 2: " + (int)(level2Percentage * 100f) + "%";
        //level3Text.text = "Level 3: " + (int)(level3Percentage * 100f) + "%";
    }
}