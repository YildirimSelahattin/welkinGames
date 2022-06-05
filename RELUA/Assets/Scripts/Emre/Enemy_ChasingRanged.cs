using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChasingRanged : MonoBehaviour
{
    public float speed = 3;
    public float stoppingDistance = 5;
    private Vector2 startingPosition;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        startingPosition = this.transform.position;
        
    }

    void Update()
    {
        Chase();
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, target.position) < 8)
        {
            
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        if(Vector2.Distance(transform.position,target.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
        }
    }
}
