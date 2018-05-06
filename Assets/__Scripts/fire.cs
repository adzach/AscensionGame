using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
    public Weapon weapon;
    public Hero hero;
    public float Speed = 10;
    public Animator gun;
    public Sprite head;
    public AudioSource AS;
    // Use this for initialization
    void Start () {
        AS = GetComponent<AudioSource>();
        print("hero health = " + this.transform.parent.GetComponent<Hero>().health);
        getHero(transform.parent.GetComponent<Hero>());
        getWeapon();
        getHead();
        getGun();
        AS.clip = weapon.Sound;
    }
	void getHero(Hero Hero)
    {
        hero = Hero;
        print("hero name:" + hero.heroInfo.HeroName);
    }
    public void updateCharacter()
    {
        AS.clip = weapon.Sound;
        getWeapon();
        getGun();
        getHead();
    }
    void getWeapon()
    {
        weapon = hero.heroInfo.weapon;
    }
    void getHead()
    {
        head = hero.heroInfo.Head;
        SpriteRenderer[] sr = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in sr)
        {
            if (s.tag == "head")
            {
                s.sprite = head;
            }
        }
    }
    void getGun()
    {
        gun = hero.heroInfo.Gun;
        Animator[] sr = GetComponentsInChildren<Animator>();
        Animator a;
        foreach(Animator s in sr)
        {
            if (s.tag == "gun")
            {
                a = s;
            }
        }
        a = gun;
    }
	// Update is called once per frame
	void Update () {
        GetComponentsInChildren<Animator>()[0].SetBool("Firing", false);
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - weapon.LastFire > weapon.Firerate)
            {
                weapon.LastFire = Time.time;
                GetComponentsInChildren<Animator>()[0].SetBool("Firing", true);
                float dir = ((this.transform.eulerAngles.z) * Mathf.PI) / 180;
                dir = dir - (Mathf.PI / 2);
                dir = -dir;
                Vector3 direction = new Vector3(Mathf.Cos(dir), Mathf.Sin(dir), 0);
                //print(dir+" dir");
                weapon.Fire();
                AS.Play();
                GameObject bullet = Instantiate<GameObject>(weapon.ProjectilePrefab);
                bullet.transform.position = transform.position;
                bullet.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z);
                Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                rigid.velocity = Speed * transform.TransformDirection(Vector3.up);
                print(rigid.velocity);
                bullet.AddComponent<DamageComponent>();
                bullet.GetComponent<DamageComponent>().damage = weapon.Damage;
            }
        }
    }
}
