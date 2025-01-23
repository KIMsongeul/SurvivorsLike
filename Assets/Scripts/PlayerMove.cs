using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4f;
    private Vector2 movement = new Vector2();


    private PlayerHp playerHp;
    
    private Rigidbody2D rigid;
    private Animator anim;
    
    private static readonly int Run = Animator.StringToHash("Run");

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerHp = GetComponent<PlayerHp>();
    }
    
    private void FixedUpdate()
    {
        if (!playerHp.isDied)
        {
            Move();
        }
    }

    private void Update()
    {
        TransformScale();
    }
    public void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement.Normalize();

        rigid.velocity = movement * speed;
        
        //animator의 SetFloat를 이용해서 movement.magnitude 즉 movement의 값을 Run에 넣는다.
        anim.SetFloat(Run,movement.magnitude);
        
    }

    public void TransformScale()
    {
        //만약 x의 입력값이 0보다 작으면
        if (movement.x < 0)
        {
            //Scale의 x값에 -1을 해 좌우반전 시키기
            transform.localScale =new Vector3(-1, 1, 1);
        }
        //x의 입력값이 0보다 크면
        else if (movement.x > 0)
        {
            //Scale의 x값에 1을 해 원래로 돌아오기
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
