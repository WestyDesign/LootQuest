#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#endregion

public class ItemCollector : MonoBehaviour
{
    int silverCoins = 0; // keeps track of the silver coins collected
    int goldCoins = 0; // ditto, gold
    bool redGem;
    bool blueGem;
    bool greenGem;
    [SerializeField] TMP_Text silverCoinsText;
    [SerializeField] TMP_Text goldCoinsText;
    [SerializeField] Image blueGemUI;
    [SerializeField] Image redGemUI;
    [SerializeField] Image greenGemUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin_S"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            silverCoins++;
            silverCoinsText.text = silverCoins + " / 10";
        }

        if (collision.gameObject.CompareTag("Coin_G"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            goldCoins++;
            goldCoinsText.text = goldCoins + " / 5";
        }

        if(collision.gameObject.CompareTag("Gem_R"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            redGem = true;
            redGemUI.GetComponent<Image>().color = new Color32(255,255,255,255); // makes the image 'white', aka not silhouetted
        }

        if(collision.gameObject.CompareTag("Gem_B"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            blueGem = true;
            blueGemUI.GetComponent<Image>().color = new Color32(255,255,255,255); // makes the image 'white', aka not silhouetted
        }

        if(collision.gameObject.CompareTag("Gem_G"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            greenGem = true;
            greenGemUI.GetComponent<Image>().color = new Color32(255,255,255,255); // makes the image 'white', aka not silhouetted
        }
    }
}
