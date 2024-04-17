using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text soundText;
    public Text coinsText;
    public Text highscoreText;

    int coins;
    float highscore;

    public GameObject menuPanel;
    public GameObject shopPanel;

    public PowerupManager powerupManager;

    Shop shop;
    private void Start()
    {
        shop = GetComponent<Shop>();
        powerupManager.Init();
        BackToMenu();

        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();

        highscore = PlayerPrefs.GetFloat("HighScore", 0);
        highscoreText.text = highscore.ToString("f0");
    }

    public void GoToShop()
    {
        shop.Refresh();
        SoundManager.instance.PlayMenuButtonSfx();
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        SoundManager.instance.PlayMenuButtonSfx();
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();
    }

    public void PlayButton()
    {
        SoundManager.instance.PlayMenuButtonSfx();
        SceneManager.LoadScene(1);
    }

    public void SoundButton()
    {
        SoundManager.instance.PlayMenuButtonSfx();
        SoundManager.instance.ToggleMuted();
        if(SoundManager.instance.muted)
        {
            soundText.text = "Sound On";
        }
        else
        {
            soundText.text = "Sound Off";
        }
    }

    public void ExitGame()
    {
        SoundManager.instance.PlayMenuButtonSfx();
        Application.Quit();
    }
}
