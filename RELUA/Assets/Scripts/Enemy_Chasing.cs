using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chasing : MonoBehaviour
{
    public float speed = 3;
    public float stoppingDistance = 1;
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
        if (Vector2.Distance(transform.position, target.position) <= 5)
        {
            if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }        
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
        }
    }
}

