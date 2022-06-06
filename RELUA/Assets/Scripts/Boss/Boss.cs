using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public static float bossHealth = 1000;
    public GameObject Fireball;
    void Start()
    {
        InvokeRepeating("Send", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void Die()
    {
        if(bossHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Send()
    {
        
        Instantiate(Fireball, transform.position, transform.rotation);
    }
}
