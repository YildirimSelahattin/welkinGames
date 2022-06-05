using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballComing : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    // hasar verme sistemi 
    private int damage;
    public PlayerHealth playerhealth;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        damage = playerhealth.maxHealth / 8;
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        Destroy(gameObject, 4);
    }
    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            LivesController.health = LivesController.health - 20;

            if (LivesController.health <= 0)
            {
                SceneManager.LoadScene("Start");
                LivesController.health = 100;
            }
            Destroy(gameObject);
        }       
    }

}
