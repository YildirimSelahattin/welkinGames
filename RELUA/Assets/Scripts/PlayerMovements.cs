using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private float attackTime= .25f;
    private float attackCounter= .25f;
    private bool isAttacking;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown=1f;
    private float dashCounter;
    private float dashCoolCounter;
    void Start(){
        activeMoveSpeed = Score.moveSpeed;
    }
    void Update()
    {
     movement.x=Input.GetAxisRaw("Horizontal");
    movement.y=Input.GetAxisRaw("Vertical");
    animator.SetFloat("Horizontal",movement.x);
    animator.SetFloat("Vertical",movement.y);
    animator.SetFloat("Speed",movement.sqrMagnitude);

    if(Input.GetAxisRaw("Horizontal")==1 ||Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical") ==1 || Input.GetAxisRaw("Vertical")==-1 ){
        animator.SetFloat("lastMoveX",Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("lastMoveY",Input.GetAxisRaw("Vertical"));
    }
    if(isAttacking){
        Score.moveSpeed=0;
        attackCounter -= Time.deltaTime;
        if(attackCounter <=0){
            animator.SetBool("isAttacking",false);
            isAttacking= false;
                Score.moveSpeed = 5f;
        }
    }

    if(Input.GetKeyDown(KeyCode.T)){
        attackCounter = attackTime;
        animator.SetBool("isAttacking",true);
        isAttacking = true;
    }
  
    /* DASHING*/
    if(Input.GetKeyDown(KeyCode.Space)){
        if(dashCoolCounter<=0 && dashCounter<=0){
                Score.moveSpeed = dashSpeed;
            dashCounter =dashLength;
        }
    }
    if(dashCounter>0){
        dashCounter -= Time.deltaTime;
        if(dashCounter<=0){
                Score.moveSpeed = 5f;
            dashCoolCounter = dashCooldown;
        }
    }
    if(dashCoolCounter >0){
        dashCoolCounter -= Time.deltaTime;
    }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Score.moveSpeed * Time.fixedDeltaTime);
    }
    //alttaki kod: dusmanin tag'ini enemy yapiyorsun ona saldirinca yok oluyor
      private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
        }
    }

    public void SpeedUp(int a)
    {
        Score.moveSpeed = (Score.moveSpeed * a / 1000) + Score.moveSpeed;
    }
    public void HealthUp()
    {
        LivesController.health = 100;
    }
}


