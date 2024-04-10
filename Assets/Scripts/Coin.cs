using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 1;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(GameManager.instance.magnet.magnet_active)
        {
            Vector2 myPosition = transform.position;
            Vector2 playerPosition = player.position;

            float distanceToPlayer = Vector2.Distance(myPosition, playerPosition);

            if(distanceToPlayer < 5)
            {
                Vector2 direction = (playerPosition - myPosition) / distanceToPlayer;
                transform.position += (Vector3)direction * Time.deltaTime * speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.CoinCollect();
            Destroy(gameObject);
        }
    }
}
