using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDector : MonoBehaviour {
    Hero hero;
	// Use this for initialization
	void Start () {
        hero = GetComponentInParent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        hero.damage(collision.gameObject.GetComponent<DamageComponent>().damage);
    }
}
