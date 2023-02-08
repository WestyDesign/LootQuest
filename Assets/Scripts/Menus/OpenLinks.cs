#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class OpenLinks : MonoBehaviour
{
    public void WestyCredit()
    { Application.OpenURL("https://westydesign.itch.io/"); }

    public void ArtCredit()
    { Application.OpenURL("https://pixelfrog-assets.itch.io/treasure-hunters"); }

    public void FontCredit()
    { Application.OpenURL("https://www.wfonts.com/font/dimitri-swank"); }

    public void SoundCredit()
    { Application.OpenURL("https://www.zapsplat.com"); }

    public void QuestionnaireLink()
    { Application.OpenURL("https://forms.gle/UTPj2thL54yQryxMA"); }
}