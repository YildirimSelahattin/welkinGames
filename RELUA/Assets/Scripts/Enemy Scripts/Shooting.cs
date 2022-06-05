using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    private Transform target;
    private float timeBtwShots;
    public float startShooting;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        timeBtwShots = startShooting;
    }

    private void Update()
    {
        
        Shoot();


    }

    void Shoot()
    {

        if(Vector2.Distance(transform.position,target.position) <= 8)
        {
          

            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startShooting;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }
}

