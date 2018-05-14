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
        /*
        AS.Play();
        GameObject bullet = Instantiate<GameObject>(weapon.ProjectilePrefab);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z);
        Rigidbody rigid = bullet.GetComponent<Rigidbody>();
        rigid.velocity = Speed * direction;
        print(rigid.velocity);
        bullet.AddComponent<DamageComponent>();
        bullet.GetComponent<DamageComponent>().damage = weapon.Damage;
        */
    }
}
