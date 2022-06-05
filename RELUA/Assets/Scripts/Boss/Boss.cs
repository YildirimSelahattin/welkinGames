using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public int bossHealth;
    public int maxHealth = 1000;
    public GameObject Fireball;
    void Start()
    {
        bossHealth = maxHealth;
        InvokeRepeating("Send", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        if(bossHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }
    void Send()
    {
        
        Instantiate(Fireball, transform.position, transform.rotation);
    }
}
