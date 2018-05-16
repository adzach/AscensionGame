using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    Hero hero;
    private float LastDamage = -1;
    private float invTime = 1f;

	void Start() {
		hero = GetComponent<Hero>();
	}

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - LastDamage > invTime)
        {
            GameObject GO = collision.gameObject; 
            DamageComponent DC = collision.gameObject.GetComponent<DamageComponent>();
                if (DC) {
                    hero.damage(DC.damage);
                    LastDamage = Time.time;
                }
        }
    }
}
