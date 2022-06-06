using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LivesController : MonoBehaviour
{
    [SerializeField] public static float health;
    public static float maxHealth = 100;

    public Slider healthSlider;

    private void Start()
    {
        health = maxHealth; 
    }

    private void Update()
    {
        healthSlider.value = health;
    }

    public void GetDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            SceneManager.LoadScene("Start");
            health = 100;
        }
    }

}
