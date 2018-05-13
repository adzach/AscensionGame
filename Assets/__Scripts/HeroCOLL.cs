using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeroCOLL : MonoBehaviour {
	static public Hero S;
    public HeroInfo heroInfo;
    public HeroSelector heroSelector;
    [Header ("Set in Inspector")]
    private float speed = 20;
    private float health = 300;
    public TextSetter textsetter;
    public float Health{
        set
        {
            GameObject GO = GameObject.Find("healthtxt");
            if (GO)
            {
                textsetter = GO.GetComponent<TextSetter>();
            }
            print(health);
            health += value;
            if (health > 0 && textsetter!= null) { 
                textsetter.setText("Health: " + health);
            }
            else
            {
                print("that which sleeps may forever lie, and in strange eons even death may die");
                //GameObject.Find("Main Camera").GetComponent<Main>().Restart();
            }
        }
        get
        {
            return health;
        }
    }
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


    void Awake () {
        print("awake");
        heroSelector = GameObject.Find("Main Camera").GetComponent<HeroSelector>();
		if (heroSelector == null) {
			//Debug.LogError ("heroSelector not assigned!");
		}

        if (S == null) {
			    //S = this;
        } else {
          Debug.LogError ("Attempted to assign second hero");
        }
        PlayerPrefs.SetString("Hero_Name", "Ooga");
        //        selectHero();
        // Temporary fix to problem
        print("test");
    }

	// Use this for initialization
	void Start () {
        print("a");
        heroInfo.HeroName = "Ooga";
        print("b");
        heroInfo.weapon = new Weapon();
        print("c");
        walkSpeed = (float)(speed + (agility));
        print("d");
        sprintSpeed = walkSpeed + (walkSpeed / 2);
        print("start");
        club = GameObject.Find("club");
        spear = GameObject.Find("spear");
        bow = GameObject.Find("bow");
        clubcol = club.GetComponent<Collider2D>();
        spearcol = spear.GetComponent<Collider2D>();
        spearcol.enabled = false;
        bow.SetActive(false);
        spear.SetActive(false);
        //Health = 0;
        print("go to execute");
    }

    // Update is called once per frame
    void Update () {
        print("update");
        moveCode2();
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
            HeroInfo HI = heroSelector.getHero(Name);
            this.heroInfo = HI;
            return true;
        }
        Debug.LogError("failed to set character");
        return false;
    }
    public void damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }
    public void die()
    {

    }    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("stick"))
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

    void moveCode2()
    {
        print("moving");
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
}
