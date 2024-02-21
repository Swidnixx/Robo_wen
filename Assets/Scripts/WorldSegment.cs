using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSegment : MonoBehaviour
{
    public float Width => ground.bounds.size.x;

    public SpriteRenderer ground;
}
