using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomphant : Enemy
{

    [Header("Set in Inspector: Zomphant")]
    public GameObject earthquakePrefab;
    public int startQuakes = 4;
    public int maxQuakes = 25;
    public int startDistDefault = 1;
    public int maxDist = 3;
    public float attackTime = .2f;
    

    [Header("Set Dynamically: Zomphant")]
    public float stopAttack;
    public GameObject[] earthquakes;
    public int attackNum = 0;
    public int startDist = 0;
    public int quakes = 0;
    public bool attacking = false;
    public float attackAnimTime = 0;



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
        if(Time.time > attackAnimTime)
        {
            var clones = GameObject.FindGameObjectsWithTag("Earthquake"); foreach (var clone in clones) { Destroy(clone); }
        }
        if (attacking)
        {
            attackAnimation();
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
            startDist++;
            quakes = quakes + 7;
            attackAnimTime = Time.time + attackTime;
            if(attackNum == maxDist - 1)
            {
                attackNum = 0;
                attacking = false;
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
