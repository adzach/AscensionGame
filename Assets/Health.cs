<<<<<<< HEAD
﻿using System.Collections;
=======
﻿using System;
using System.Collections;
>>>>>>> origin/CharlieCharacterBranch
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
<<<<<<< HEAD
    Hero hero;
    private float LastDamage = -1;
    private float invTime = 1f;
    // Use this for initialization
    void Start () {
        Hero hero = GetComponent<Hero>();
    }
=======
    private Hero hero;
	// Use this for initialization
	void Start () {
		
	}
>>>>>>> origin/CharlieCharacterBranch
	
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< HEAD
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - LastDamage > invTime)
        {
            GameObject GO = collision.gameObject;
            print("collison: " + GO.tag +" "+ GO.name);
            if (GO.tag.Equals("Enemy") || GO.tag.Equals("Enemy Bullet"))
            {
                Hero hero = GetComponent<Hero>();
                hero.damage(collision.gameObject.GetComponent<DamageComponent>().damage);
                LastDamage = Time.time;
            }
        }
    }
    */
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - LastDamage > invTime)
        {
            GameObject GO = collision.gameObject;
            //print("collison: " + GO.tag + " " + GO.name);
            if (GO.tag.Equals("Enemy") || GO.tag.Equals("Enemy Bullet"))
            {
                Hero hero = GetComponent<Hero>();
                hero.damage(collision.gameObject.GetComponent<DamageComponent>().damage);
                LastDamage = Time.time;
            }
        }
    }
=======
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hero.damage(10f);
        }
        if (other.tag == "Enemy Projectiles")
        {
            hero.damage(other.GetComponent<DamageComponent>().damage);
        }
    }

    internal void setHero(Hero hero)
    {
        this.hero = hero;
    }
>>>>>>> origin/CharlieCharacterBranch
}
