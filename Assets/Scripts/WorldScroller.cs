using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public WorldSegment groundLeft, groundRight;

    public GameObject gleft, gRight;

    public float speed = 1;

    public WorldSegment[] tiles;

    private void FixedUpdate()
    {
        Vector3 delta_pos = new Vector2( -speed * Time.deltaTime, 0);
        groundLeft.transform.position += delta_pos;
        groundRight.transform.Translate(delta_pos);

        if(groundRight.transform.position.x <= 0)
        {
            var newTile = Instantiate(tiles[Random.Range(0,tiles.Length)]);

            newTile.transform.parent = gameObject.transform;

            Vector3 tileWidth = new Vector2(groundLeft.Width, 0);
            groundLeft.transform.position = groundRight.transform.position + tileWidth;


            groundRight = groundLeft;
            groundLeft = newTile;

            //Destroy(gleft);
            gleft = newTile.gameObject;
        }
    }
}
