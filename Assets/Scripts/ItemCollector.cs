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
    [SerializeField] TMP_Text silverCoinsText; // UI text showing silver coins collected
    [SerializeField] TMP_Text goldCoinsText; // ditto, gold
    [SerializeField] Image blueGemUI; // UI image that becomes coloured in when blue gem collected
    [SerializeField] Image redGemUI; // ditto, red
    [SerializeField] Image greenGemUI; // ditto, green
    [SerializeField] AudioSource silverCoinSound;
    [SerializeField] AudioSource goldCoinSound;
    [SerializeField] AudioSource gemSound;

    private void Start()
    {
        DataManager.Instance.LoadGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin_S"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            silverCoins++;
            DataManager.Instance.Level1Silver++;
            silverCoinSound.Play();
            silverCoinsText.text = silverCoins + " / 10";
        }

        if (collision.gameObject.CompareTag("Coin_G"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            goldCoins++;
            DataManager.Instance.Level1Gold++;
            goldCoinSound.Play();
            goldCoinsText.text = goldCoins + " / 5";
        }

        if (collision.gameObject.CompareTag("Gem_R"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            redGem = true;
            gemSound.Play();
            redGemUI.GetComponent<Image>().color = new Color32(255, 255, 255, 255); // makes the image 'white', aka not silhouetted
        }

        if (collision.gameObject.CompareTag("Gem_B"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            blueGem = true;
            gemSound.Play();
            blueGemUI.GetComponent<Image>().color = new Color32(255, 255, 255, 255); // makes the image 'white', aka not silhouetted
        }

        if (collision.gameObject.CompareTag("Gem_G"))
        {
            Destroy(collision.gameObject); // destroys the collectible when it's been touched
            greenGem = true;
            gemSound.Play();
            greenGemUI.GetComponent<Image>().color = new Color32(255, 255, 255, 255); // makes the image 'white', aka not silhouetted
        }


        DataManager.Instance.SaveGame(); // saves the game
    }
}