using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [Header("Set in Inspector: Enemy")]
    public int defaultSpeed;
    public float maxHealth = 100;
    public float attackRange;
    public float attackCoolDown;  //in seconds



    [Header("Set Dynamically: Enemy")]
    public int speed;
    public float health;
    public Vector3 dir = Vector3.zero;
    public float coolDownDone;
    public float distance;
    public bool offCooldown = true;
    public Vector3 tempHero;
    public bool first = true;
    public Vector3 heroPos;

    protected Animator anim;
    protected Rigidbody2D rigid;
    protected SpriteRenderer sRend;

    protected virtual void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        coolDownDone = Time.time + attackCoolDown;

    }

    protected virtual void Update()
    {
        anim.speed = 1;

        followChar();

        flip();

    }

    public void followChar()
    {
        //        Vector3 mousePos2D = Input.mousePosition;
        //        mousePos2D.z = -Camera.main.transform.position.z;
        //        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        if (first)
        {
             heroPos = Hero.S.transform.position;
        }
        first = false;

        float x = rigid.position.x;
        float y = rigid.position.y;
        Vector3 enemyPos = new Vector3(x, y, 0);
        
        dir = heroPos - enemyPos;
        distance = dir.magnitude;

        if (distance < attackRange)
        {
            attack();
        }

        if (distance < 1.1f)
        {
            offCooldown = true;
        }

        if (offCooldown)
        {
            heroPos = Hero.S.transform.position;
            speed = defaultSpeed;
            dir = heroPos - enemyPos;
            distance = dir.magnitude;
        }
        

        // update velocity
        dir.Normalize();
        rigid.velocity = dir * speed;
    }

    public void flip()
    {
        //flip if chasing right
        if (dir.x < 0)
        {
            sRend.flipX = false;
        }
        else
        {
            sRend.flipX = true;
        }
    }

    public virtual void attack()
    {
        // if off of cooldown
        if (Time.time > coolDownDone)
        {
            // reset cooldown
            coolDownDone = Time.time + attackCoolDown;
            offCooldown = true;
        }
        
    }

}
