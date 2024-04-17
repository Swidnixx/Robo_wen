using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MagnetSO : ScriptableObject
{
    public int level = 1;
    public int upgradeCost;
    public MagnetSO upgraded;

    public bool magnet_active;
    public float magnet_distance = 3;
    public float magnet_duration = 5;
}
