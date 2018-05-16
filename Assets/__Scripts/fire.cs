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
    public int weaponNum = 0;
    public GameObject arrow;
    // Use this for initialization
    void Start () {
        AS = GetComponent<AudioSource>();
        getHero(this.transform.parent.GetComponent<Hero>());
        getWeapon();
    }
	void getHero(Hero Hero)
    {
        hero = Hero;
    }

    void getWeapon()
    {
        weapon = new CowboyWeapon();
    }
    void decreaseCount()
    {
        hero.stones -= 0.1f;
        hero.sticks -= 0.1f;
        GameObject.Find("sticktxt").GetComponent<setText>().set("" + Mathf.Round(hero.sticks + 0.49f));
        GameObject.Find("rocktxt").GetComponent<setText>().set("" + Mathf.Round(hero.stones + 0.49f));
    }
    public void enemyHit()
    {
        if (weaponNum == 1) decreaseCount();
    }
	// Update is called once per frame
	void Update () {
        hero.enabled = true;
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponNum == 2)
            {
                if (Time.time - weapon.LastFire > weapon.Firerate)
                {
                    decreaseCount();
                    GameObject.Find("bow").GetComponent<Animator>().Play("bowAnim");
                    weapon.LastFire = Time.time;
                    GetComponentsInChildren<Animator>()[0].SetBool("Walking", true);
                    float dir = ((this.transform.eulerAngles.z) * Mathf.PI) / 180;
                    dir = dir - (Mathf.PI / 2);
                    dir = -dir;
                    Vector3 direction = new Vector3(Mathf.Cos(dir), Mathf.Sin(dir), 0);
                    weapon.Fire();
                    AS.Play();
                    GameObject bullet = Instantiate<GameObject>(arrow);
                    bullet.transform.position = transform.position;
                    bullet.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z);
                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                    rigid.velocity = Speed * transform.TransformDirection(Vector3.up);
                    bullet.AddComponent<DamageComponent>();
                    bullet.GetComponent<DamageComponent>().damage = weapon.Damage;
                }
            }
            if (weaponNum == 1)
            {
                hero.spearcol.enabled = true;
            }
            if (weaponNum == 0)
            {
                hero.clubcol.enabled = true;
            }
        }
    }
}
