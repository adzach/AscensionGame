using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomphant : Enemy
{

    [Header("Set in Inspector: Zomphant")]
    public GameObject earthquakePrefab;
    public int startQuakes = 4;
    public int maxQuakes = 50;
    public float startDistDefault = 1f;
    public int maxDist = 3;
    public float distInc = 1f;
    public float attackTime = .05f;
    public float offset = .4f;
    

    [Header("Set Dynamically: Zomphant")]
    public float stopAttack;
    public GameObject[] earthquakes;
    public int attackNum = 0;
    public float startDist = 0f;
    public int quakes = 0;
    public bool attacking = false;
    public float attackAnimTime = 0;
    public float startRipple;



    protected override void Awake()
    {
        base.Awake();
        speed = defaultSpeed;
        earthquakes = new GameObject[maxQuakes];
    }

    protected override void Update()
    {
        base.Update();

        followChar();

        flip();
        if (attacking)
        {
            speed = 0;

            anim.CrossFade("Zomphant_Attack", 0);
            if (Time.time > startRipple)
            {
                
                attackAnimation();
            }
        }
        else
        {
            anim.CrossFade("Zomphant_Walk", 0);
            speed = defaultSpeed;
        }
        

    }



    override public void attack()
    {
        base.attack();

        if (attacking == false && offCooldown == true && distance < attackRange)
        {

            offCooldown = false;
            attacking = true;
            startDist = startDistDefault;
            quakes = startQuakes;
            startRipple = Time.time + offset;
        }
        else
        {
            offCooldown = true;
        }
    }

    public void attackAnimation()
    {
        
        if (Time.time > attackAnimTime)
        {
            
            for (int i = 0; i < quakes; i++)
            {
                earthquakes[i] = Instantiate<GameObject>(earthquakePrefab);
                earthquakes[i].GetComponent<Rigidbody>().position = toPolar(startDist, 360 / quakes * i * Mathf.PI / 180);

            }
            startDist += distInc;
            if (quakes < maxQuakes)
            {
                //quakes++;
            }
            attackAnimTime = Time.time + attackTime;
            if (attackNum == maxDist - 1)
            {
                attackNum = 0;
                attacking = false;
                var clones = GameObject.FindGameObjectsWithTag("Earthquake"); foreach (var clone in clones) { Destroy(clone); }
            }
            else
            {
                attackNum++;
            }
            
        }
        
        
       
    }

    public Vector3 toPolar(float r, float theta)
    {
        Vector3 toReturn = new Vector3(rigid.position.x + r * Mathf.Cos(theta), rigid.position.y + r * Mathf.Sin(theta), 0);
        return toReturn;
    }



}
