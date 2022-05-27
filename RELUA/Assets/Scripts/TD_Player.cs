using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class TD_Player : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _anim;

    [SerializeField] float _moveSpeed = 500;
    public GameObject directionRoot;
    public GameObject playerSprite;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        DirectionAttach();
    }  
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");

        bool move = ix != 0 || iy != 0;
        _anim.SetBool("move", move);

        float isUp = 0;

        if(iy > 0)
        {
            isUp = 0.5f;
        }
        else if(iy < 0)
        {
            isUp = 1;
        }

        _anim.SetFloat("isUp", isUp);

        if (move)
        {
            Vector2 moveDir = new Vector2(ix, iy/1.25f);

            _rb.AddRelativeForce(moveDir * _moveSpeed, ForceMode2D.Force);
        }

    }

    void DirectionAttach()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 playerPos = transform.position;
        Vector2 offset = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);

        directionRoot.transform.up = offset.normalized;

        float axe = directionRoot.transform.rotation.eulerAngles.z;
        //Debug.Log(axe);

        bool right = axe > 180;

        float currentDir = playerSprite.transform.rotation.x;

        if (currentDir != 1 && Input.GetKeyDown(KeyCode.D))
        {
            turn(1);
        }
        if (currentDir != -1 && Input.GetKeyDown(KeyCode.A))
        {
            turn(-1);
        }
        
    }

    void turn(int dir)
    {
        Vector2 scale = new Vector2(dir, 1);
        playerSprite.transform.localScale = scale;
    }
}
