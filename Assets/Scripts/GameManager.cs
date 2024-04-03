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

    public bool magnet_active;
    public void MagnetCollect()
    {
        magnet_active = true;
        Invoke(nameof(DeactivateMagnet), 5);
    }

    void DeactivateMagnet()
    {
        magnet_active = false;
    }
}
