using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwing : MonoBehaviour
{

    private Animator anim;
    public Transform player;
    private Transform target;
    public SpriteRenderer sr;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }
    //saldýrý animasyonu
    void Update()
    {

        Swing();
        if (target.position.x < transform.position.x)
        {
            sr.flipX = true;
            
        }
        else
        {
            sr.flipX = false;

        }

        void Swing()
        {
            if (Vector2.Distance(transform.position, player.position) <= 1.5f)
            {

                anim.SetBool("target_in_range", true);

            }
            else anim.SetBool("target_in_range", false);
        }


    }
}
