using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	static public Hero S;
    [SerializeField]
    public HeroInfo heroInfo;
    public HeroSelector heroSelector;
    [Header ("Set in Inspector")]
	public float speed = 30;
    public float health = 300;

	void Awake () {
        GetComponent<Health>().setHero(this);
        if (S == null) {
			S = this;
		} else {
			Debug.LogError ("Attempted to assign second hero");
		}
    }

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (-5, -5, -1);
	}

    // Update is called once per frame
    /*
    void Update () {
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;
	}
    */
    /*
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
            print("Hi =" + HI);
            this.heroInfo = HI;
            print(" test "+this.heroInfo.HeroName);
            return true;
        }
        Debug.LogError("failed to set character");
        return false;
    }
    */
    public void damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            die();
        }
    }
    public void die()
    {
        print("you died");
        this.gameObject.active = false;
    }
}
