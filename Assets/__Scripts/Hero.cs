using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	static public Hero S;
    public HeroInfo heroInfo;
    public HeroSelector heroselector;
    [Header ("Set in Inspector")]
    private float speed = 20;
    public float health = 300;
    private float walkSpeed;
    public float curSpeed;
    private float maxSpeed;
    private float agility = 5;
    private float sprintSpeed;
    public float sticks = 0;
    public float stones = 0;
    private GameObject club;
    private GameObject spear;
    private GameObject bow;
    public Collider2D clubcol;
    public Collider2D spearcol;
    public TextSetter TS;

    void Awake () {
        /*
        heroselector = GameObject.Find("Main Camera").GetComponent<HeroSelector>();
		if (heroSelector == null) {
			Debug.LogError ("heroSelector not assigned!");
		}
        */
        if (S == null) {
			    S = this;
        } else {
          Debug.LogError ("Attempted to assign second hero");
        }
        PlayerPrefs.SetString("Hero_Name", "Cowboy");
//        selectHero();

        walkSpeed = (float)(speed + (this.agility));
        sprintSpeed = walkSpeed + (walkSpeed / 2);
        
    }
    void Start()
    {
        heroInfo.HeroName = "Ooga";
        heroInfo.weapon = new Weapon();
        walkSpeed = (float)(speed + (agility));
        sprintSpeed = walkSpeed + (walkSpeed / 2);
        club = GameObject.Find("club");
        spear = GameObject.Find("spear");
        bow = GameObject.Find("bow");
        clubcol = club.GetComponent<Collider2D>();
        spearcol = spear.GetComponent<Collider2D>();
        spearcol.enabled = false;
        bow.SetActive(false);
        spear.SetActive(false);
        damage(0);
    }
    void changeHero(string character)
    {
        if (PlayerPrefs.HasKey("Hero_Name"))
        {
            string oldPlayer = PlayerPrefs.GetString("Hero_Name");
            PlayerPrefs.SetString("Hero_Name", character);
            if (!selectHero())
            {
                PlayerPrefs.SetString("Hero_Name", oldPlayer);
            }
        }
        PlayerPrefs.SetString("Hero_Name", character);
        if (!selectHero())
        {
            PlayerPrefs.DeleteKey("Hero_Name");
        }
    }
    bool selectHero()
    {
        if (PlayerPrefs.HasKey("Hero_Name"))
        {
            string Name = PlayerPrefs.GetString("Hero_Name");
            HeroInfo HI = heroselector.getHero(Name);
            print("Hi =" + HI);
            this.heroInfo = HI;
            print(" test "+this.heroInfo.HeroName);
            return true;
        }
        Debug.LogError("failed to set character");
        return false;
    }
    public void damage(float damage)
    {
        health -= damage;
        GameObject.Find("healthtxt").GetComponent<TextSetter>().setText("Health: " + health);
        if (health <= 0)
        {
            die();
        }
    }
    public void die()
    {
        print("dead");
    }
	
	// Update is called once per frame
	void Update () {

		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		Vector3 pos = transform.position;
        float x = xAxis * speed * Time.deltaTime;
        float y = yAxis * speed * Time.deltaTime;

        pos.x += x;
		pos.y += y;
        
        transform.position = pos;

        if (sticks >= 3 && stones >= 3)
        {
            if (GetComponentInChildren<fire>().weaponNum < 2)
            {
                club.SetActive(false);
                spear.SetActive(false);
                bow.SetActive(true);

                GetComponentInChildren<fire>().weaponNum = 2;
            }
        }
        else if (sticks >= 1 && stones >= 1)
        {
            if (GetComponentInChildren<fire>().weaponNum < 1)
            {
                club.SetActive(false);
                spear.SetActive(true);
                bow.SetActive(false);

                GetComponentInChildren<fire>().weaponNum = 1;
            }
        }
        else
        {
            if (GetComponentInChildren<fire>().weaponNum != 0)
            {
                club.SetActive(true);
                spear.SetActive(false);
                bow.SetActive(false);

                GetComponentInChildren<fire>().weaponNum = 0;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stick"))
        {
            Destroy(other.gameObject);
            sticks++;
        }
        if (other.CompareTag("rock"))
        {
            Destroy(other.gameObject);
            stones++;
        }
    }
}
