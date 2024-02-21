using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public WorldSegment groundLeft, groundRight;
    public float speed = 1;

    private void Update()
    {
        Vector3 delta_pos = new Vector2( -speed * Time.deltaTime, 0);
        groundLeft.transform.position += delta_pos;
        groundRight.transform.Translate(delta_pos);

        if(groundRight.transform.position.x <= 0)
        {
            Vector3 tileWidth = new Vector2(groundLeft.Width, 0);
            groundLeft.transform.position = groundRight.transform.position + tileWidth;

            var tmp = groundRight;
            groundRight = groundLeft;
            groundLeft = tmp;
        }
    }
}
