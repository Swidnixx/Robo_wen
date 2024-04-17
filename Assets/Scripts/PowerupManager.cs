using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PowerupManager : ScriptableObject
{
    [SerializeField] BatterySO _battery;
    [SerializeField] MagnetSO _magnet;

    public BatterySO Battery
    {
        get { return _battery; }
        set
        {
            _battery = value;
            // When setting powerup, save it's config file name to PlayerPrefs
            PlayerPrefs.SetString("BatteryLevel", _battery.name);
            Debug.Log(_battery.name + " has been saved in PlayerPrefs");
        }
    }
    public MagnetSO Magnet
    {
        get { return _magnet; }
        set
        {
            _magnet = value;
            PlayerPrefs.SetString("MagnetLevel", _magnet.name);
            Debug.Log(_magnet.name + " has been saved in PlayerPrefs");
        }
    }

    public void Init()
    {
        //Read current powerup level from PlayerPrefs on startup
        // Stay at default if not found
        BatterySO tmp = Resources.Load<BatterySO>(PlayerPrefs.GetString("BatteryLevel"));
        if (tmp != null)
        {
            _battery = tmp;
            Debug.Log("Battery: " + tmp.name + " has been loaded!");
        }

        MagnetSO tmp2 = Resources.Load<MagnetSO>(PlayerPrefs.GetString("MagnetLevel"));
        if (tmp2 != null)
        {
            _magnet = tmp2;
            Debug.Log("Magnet: " + tmp2.name + " has been loaded!");
        }
    }
}
