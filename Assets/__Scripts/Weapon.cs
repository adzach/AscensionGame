using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponDefinition
{
    public string Name = "test";
    public float Speed = 10f;
    public float Damage = 10f;
    public float Firerate = 0.5f;
    public GameObject ProjectilePrefab;
    public AudioClip sound;
}

public class Weapon{
    public string Name = "";
    public GameObject ProjectilePrefab;
    public GameObject Owner;
    public AudioClip Sound;
    public float Speed = 10f;
    public float Damage = 10f;
    public float Firerate = 0.5f;
    public float LastFire = -0.5f;
    public Color color = Color.white;

    public void assignOwner(GameObject owner)
    {
        Owner = owner;
    }

    // Update is called once per frame
    public void Update () {

    }
    public void Fire()
    {

    }
}
