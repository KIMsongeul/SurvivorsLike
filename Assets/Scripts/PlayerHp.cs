using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int hp = 5;
    public bool isDied = false;
    
    private Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Die();
    }

    public void Die()
    {
        if (hp <= 0)
        {
            anim.SetBool("Die",true);
            isDied = true;
        }
    }
}
