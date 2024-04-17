using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BatterySO : ScriptableObject
{
    public int level = 1;
    public int upgradeCost;
    public BatterySO upgraded;

    public bool active;
    public float distance = 3;
    public float duration = 5;
}
