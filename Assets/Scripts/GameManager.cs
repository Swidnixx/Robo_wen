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
    public Text coinsText;
    public GameObject gameOverPanel;

    public float worldScrollingSpeed;
    private float score;
    private int coins;

    public MagnetSO magnet;
    public bool battery_active;

    // Update is called once per frame
    void FixedUpdate()
    {
        score += worldScrollingSpeed;
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
    }

    public void MagnetCollect()
    {
        if (magnet.magnet_active)
        {
            CancelInvoke(nameof(DeactivateMagnet));
        }

        magnet.magnet_active = true;
        Invoke(nameof(DeactivateMagnet), 5);
    }

    void DeactivateMagnet()
    {
        magnet.magnet_active = false;
    }


    public void BatteryCollect()
    {
        if(battery_active)
        {
            CancelInvoke(nameof(DeactivateBattery));
        }
        battery_active = true;
        Invoke(nameof(DeactivateBattery), 5);
    }

    void DeactivateBattery()
    {
        battery_active = false;
    }
}
