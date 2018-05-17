using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [Header("Set in Inspector: Enemy")]
    public int defaultSpeed;
    public float maxHealth = 100;
    public float attackRange;
    public float attackCoolDown;  //in seconds
	public GameObject blood;

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
	GameObject abilityHolder;

    protected virtual void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        coolDownDone = Time.time + attackCoolDown;
		abilityHolder = GameObject.Find("abilityHolder");
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

	public void makeBlood(Collider2D collision)
	{
		Instantiate(blood, collision.transform.position + collision.transform.TransformDirection(Vector3.up), collision.transform.rotation, abilityHolder.transform);
	}

	public void OnTriggerEnter2D(Collider2D collision)
    {
		switch (collision.gameObject.name) {
		case "Arrow(Clone)":
			health -= 25;
			break;
		case "club":
			health -= 50;
			break;
		case "spear":
			health -= 75;
			fire.F.enemyHit ();
			break;
        case "ability (1)(Clone)":
            health -= 90;
            break;
        default:
			print ("Enemy triggered by non-weapon: " + collision.gameObject.name);
			break;
		}
		makeBlood (collision);
    }

}
