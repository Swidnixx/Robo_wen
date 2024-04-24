using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple GMs in the scene");
        }
        instance = this;
    }
    #endregion

    public Text scoreText;
    public Text highScoreText;
    public Text coinsText;
    public GameObject gameOverPanel;

    public float worldScrollingSpeed;
    private float score;
    private int coins;
    private float highScore;

    public PowerupManager pm;

    private void Start()
    {
        pm.Magnet.magnet_active = false;
        pm.Battery.active = false;

        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();

        highScore = PlayerPrefs.GetFloat("HighScore");
        highScoreText.text = highScore.ToString("0");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score += worldScrollingSpeed;
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString("0");
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        UpdateOnScreen();
    }

    void UpdateOnScreen()
    {
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CoinCollect()
    {
        coins++;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
        SoundManager.instance.PlayCoinSfx();
    }

    public void MagnetCollect()
    {
        if (pm.Magnet.magnet_active)
        {
            CancelInvoke(nameof(DeactivateMagnet));
        }

        pm.Magnet.magnet_active = true;
        Invoke(nameof(DeactivateMagnet), pm.Magnet.magnet_duration);
    }

    void DeactivateMagnet()
    {
        pm.Magnet.magnet_active = false;
    }


    public void BatteryCollect()
    {
        if(pm.Battery.active)
        {
            CancelInvoke(nameof(DeactivateBattery));
        }
        pm.Battery.active = true;
        Invoke(nameof(DeactivateBattery), pm.Battery.duration);
    }

    void DeactivateBattery()
    {
        pm.Battery.active = false;
    }
}
