using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombunny : Enemy {

    [Header("Set in Inspector: Zombunny")]
    public int attackSpeed;
    public float attackDurration;

    [Header("Set Dynamically: Zombunny")]
    public float stopAttack;
    


    protected override void Awake()
    {
        base.Awake();
        speed = defaultSpeed;
        coolDownDone = Time.time + attackCoolDown;
    }

    protected override void Update()
    {

        base.Update();
    }

    

    override public void attack()
    {
        // if off of cooldown
        if (Time.time > coolDownDone)
        {
            // reset cooldown
            coolDownDone = Time.time + attackCoolDown + attackDurration;
            // start attacking and start timer for that attack
            stopAttack = Time.time + attackDurration;
            offCooldown = true;
        }
        else
        {
            offCooldown = false;
        }

        // if attacking, go in, otherwise keep regular speed
        if (Time.time < stopAttack)
        {
            speed = attackSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }

    }

    


    }
