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


    protected Animator anim;
    protected Animator attackanim;
    protected Rigidbody2D rigid;
    protected SpriteRenderer sRend;

    protected virtual void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        attackanim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        coolDownDone = Time.time + attackCoolDown;

    }

    protected virtual void Update()
    {
        anim.speed = 1;

        followChar();

        flip();
        if (health <= 0) Destroy(gameObject);

    }

    public void followChar()
    {
//        Vector3 mousePos2D = Input.mousePosition;
//        mousePos2D.z = -Camera.main.transform.position.z;
//        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		Vector3 heroPos = Hero.S.transform.position;

        float x = rigid.position.x;
        float y = rigid.position.y;
        Vector3 enemyPos = new Vector3(x, y, 0);

        dir = heroPos - enemyPos;
        distance = dir.magnitude;

        if (distance < attackRange)
        {
            attack();
        }
        else
        {
            speed = defaultSpeed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= collision.gameObject.GetComponent<DamageComponent>().damage;
    }

}
