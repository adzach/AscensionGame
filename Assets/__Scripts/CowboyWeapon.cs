using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyWeapon : Weapon {
    public string Name = "Cowboy";
    public GameObject ProjectilePrefab;
    public GameObject Owner;
    public AudioClip Sound;
    public float Speed = 10f;
    public float Damage = 10f;
    public float Firerate = 0.5f;
    public float LastFire = -0.5f;
    public Color color = Color.white;

    // Use this for initialization
    void Start () {
        ProjectilePrefab = Resources.Load("Prefabs/Cowboy Bullet") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Fire()
    {

    }

}
