#region 'Using' info
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
#endregion

public class AchievementsPage : MonoBehaviour
{
    [SerializeField] TMP_Text DescText;

    [SerializeField] Button Ach1;
    [SerializeField] Button Ach2;

    public void A1()
    {
        DescText.text = "Test 1";
    }

    public void A2()
    {
        DescText.text = "Test 2";
    }
}
