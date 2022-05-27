using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwing : MonoBehaviour
{

    private Animator anim;
    public Transform player;
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        anim = GetComponent<Animator>();
    }
    //saldýrý animasyonu
    void Update()
    {

        Swing();

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
