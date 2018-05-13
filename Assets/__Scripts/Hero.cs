using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	static public Hero S;
    public HeroInfo heroInfo;
    public HeroSelector heroSelector;

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
    public GameObject spear;
    private GameObject bow;
    public Collider2D clubcol;
    public Collider2D spearcol;


    void Awake () {
        heroSelector = GameObject.Find("Main Camera").GetComponent<HeroSelector>();
		if (heroSelector == null) {
			Debug.LogError ("heroSelector not assigned!");
		}

        if (S == null) {
			    S = this;
        } else {
          Debug.LogError ("Attempted to assign second hero");
        }
        PlayerPrefs.SetString("Hero_Name", "Ooga");
//        selectHero();
		// Temporary fix to problem
		heroInfo.HeroName = "Ooga";
		heroInfo.weapon = new Weapon ();

        walkSpeed = (float)(speed + (agility));
        sprintSpeed = walkSpeed + (walkSpeed / 2);

        
    }

	// Use this for initialization
	void Start () {
        club = GameObject.Find("club");
        spear = GameObject.Find("spear");
        bow = GameObject.Find("bow");
        clubcol = club.GetComponent<Collider2D>();
        spearcol = spear.GetComponent<Collider2D>();
        spearcol.enabled = false;
        bow.SetActive(false);
        spear.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
                moveCode2();

        /*float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");
		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;*/

        if (sticks > 2 && stones > 2)
        {
            if (GetComponentInChildren<fire>().weaponNum != 2)
            {
               club.SetActive(false);
                spear.SetActive(false);
                bow.SetActive(true);

                GetComponentInChildren<fire>().weaponNum = 2;
            }
        }
        else if (sticks > 0 && stones > 0)
        {
            if (GetComponentInChildren<fire>().weaponNum != 1)
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
//<<<<<<< HEAD
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	

//<<<<<<< HEAD
    
//=======

    //}    
//>>>>>>> origin/caveman

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("stick"))
        {
            Destroy(other.gameObject);
            sticks++;
            GameObject.Find("sticktxt").GetComponent<setText>().set("" + Mathf.Round(sticks+0.49f));
        }
        if (other.CompareTag("rock"))
        {
            Destroy(other.gameObject);
            stones++;
            GameObject.Find("rocktxt").GetComponent<setText>().set("" + Mathf.Round(stones + 0.49f));
        }
    }

    void moveCode2()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                            Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
}
