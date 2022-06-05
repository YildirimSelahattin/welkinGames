using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skulls : MonoBehaviour
{
    //takip sistemi
    public float speed = 2f;
    private Transform target;
    //collider
    private float area = 0.5f;
    private Collider2D skullHit;
    // effect için
    public ParticleSystem explosionEffect;
    public SpriteRenderer sr;
    public bool birkere = true;
    // hasar verme sistemi 
    private float damage;
    public LivesController health;
    // hasar alma sistemi
    public static float maxHealth = 100;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        Chase();
        Explode();
        OnTriggerEnter2D(skullHit);
        Debug.Log(maxHealth);
        if(maxHealth <= 0)
        {
            DestroyObject();
        }
        
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    
    void Explode()
    {
        skullHit = Physics2D.OverlapCircle(transform.position, area);
    }
   

    private void OnDrawGizmosSelected()
    {
        if (transform.position == null)
            return;
        Gizmos.DrawWireSphere(transform.position, area);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("player") && birkere)
        {
            var emission = explosionEffect.emission;
            var duration = explosionEffect.duration;
            emission.enabled = true;
            explosionEffect.Play();
            birkere = false;

            
            Destroy(sr);
            Invoke(nameof(DestroyObject), duration);
            LivesController.health = LivesController.health - 20;

            if (LivesController.health <= 0)
            {
                SceneManager.LoadScene("Start");
                LivesController.health = 100;
            }
        }
    }
   void DestroyObject()
    {
        Destroy(gameObject);
    }



}
