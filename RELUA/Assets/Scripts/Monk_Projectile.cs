using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

