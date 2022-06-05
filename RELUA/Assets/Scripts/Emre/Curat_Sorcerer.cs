using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curat_Sorcerer : MonoBehaviour
{
    public float speed = 3;
    public float stoppingDistance = 5;
    private Vector2 startingPosition;
    private Transform target;
    public float targetX;
    public float targetY;
    public float TeleportCooldown = 5;
    public float TeleportHappens = 0;
    public static float curratHealth = 100;
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        startingPosition = this.transform.position;
    }

    void Update()
    {
        Chase();
        Teleport();
        if (curratHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, target.position) < 8)
        {

            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
        }
    }

    void Teleport()
    {

        targetX = target.position.x;
        targetY = target.position.y;
        if (Vector2.Distance(transform.position, target.position) <= 2)
        {
            if(Time.time > TeleportHappens)
            {
                transform.position = new Vector2(Random.Range(targetX + 5, targetX - 5), Random.Range(targetY + 5, -targetY - 5));
                TeleportHappens = Time.time + TeleportCooldown;
            }
          
        }
    }
}
