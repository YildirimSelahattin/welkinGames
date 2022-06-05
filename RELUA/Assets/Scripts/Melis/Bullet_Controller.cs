using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Vector2 target;
    public float speed;
    public int health;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        Destroy(gameObject, 1f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHP.enemyHealth = EnemyHP.enemyHealth - 20;
        }
        if (other.tag == "skull")
        {
            Skulls.maxHealth = Skulls.maxHealth - 50;
        }
        if (other.tag == "curat")
        {
            Curat_Sorcerer.curratHealth = Curat_Sorcerer.curratHealth - 10;
        }
    }
}