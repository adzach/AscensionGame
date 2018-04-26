using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasmanWeapon : Weapon {

    public string Name = "Gasman";
    public GameObject ProjectilePrefab = Resources.Load("Prefabs/Gas") as GameObject;
    public GameObject Owner;
    public AudioClip Sound;
    public float Speed = 10f;
    public float Damage = 10f;
    public float Firerate = 0.5f;
    public float LastFire = -0.5f;
    public Color color = Color.white;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
