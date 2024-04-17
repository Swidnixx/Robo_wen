using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;
    public Text batteryInfoText;
    public Button batteryButton;
    public Text magnetInfoText;
    public Button magnetButton;

    public Text coinsText;
    int coins;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();
        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    void DisplayMagnetInfo()
    {
        string info = "Lvl " + powerupManager.Magnet.level + "\n";

        if (powerupManager.Magnet.upgraded != null)
        {
            info += "$" + powerupManager.Magnet.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            magnetButton.interactable = false;
        }


        magnetInfoText.text = info;
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerupManager.Magnet.upgradeCost)
        {
            coins -= powerupManager.Magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.Magnet = powerupManager.Magnet.upgraded;
            DisplayMagnetInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl " + powerupManager.Battery.level + "\n";

        if(powerupManager.Battery.upgraded != null)
        {
            info += "$" + powerupManager.Battery.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            batteryButton.interactable = false;
        }
  

        batteryInfoText.text = info;
    }

    public void UpgradeButtery()
    {
        if( coins >= powerupManager.Battery.upgradeCost )
        {
            coins -= powerupManager.Battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.Battery = powerupManager.Battery.upgraded;
            DisplayBatteryInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
