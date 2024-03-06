using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public WorldSegment groundLeft, groundRight;

    public float speed = 1;

    public WorldSegment[] tiles;

    private void Update()
    {
        Vector3 delta_pos = new Vector2( -speed * Time.deltaTime, 0);
        groundLeft.transform.position += delta_pos;
        groundRight.transform.Translate(delta_pos);

        if(groundRight.transform.position.x <= 0)
        {
            var newTile = Instantiate(tiles[Random.Range(0,tiles.Length)]);

            newTile.transform.parent = gameObject.transform;

            Vector3 newTileWidth = new Vector2(newTile.Width, 0);
            Vector3 rightTileWidth = new Vector2(groundRight.Width, 0);
            newTile.transform.position = groundRight.transform.position + newTileWidth/2 + rightTileWidth/2;

            Destroy(groundLeft.gameObject);
            groundLeft = groundRight;
            groundRight = newTile;
        }
    }
}
