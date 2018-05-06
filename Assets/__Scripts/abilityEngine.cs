using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityEngine : MonoBehaviour {
    public enum Character {Ooga, RaoulTheIlluminator, otherchar2};
    public Character curchar = Character.Ooga;
    public GameObject fireAbility;
    public GameObject abilityHolder;
    public bool canAbility1 = true;
    public countdownSM countMan;
    public int cooldownVal = 10;

    // Use this for initialization
    void Start ()
    {
        abilityHolder = GameObject.Find("abilityHolder");
        countMan = GameObject.Find("ability1txt").GetComponent<countdownSM>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("1")&&canAbility1) ability1();
        if (Input.GetKeyDown("2")) ability2();
        if (Input.GetKeyDown("3")) ability3();
    }

    public void ability1()
    {
        if(curchar==Character.Ooga)
        {
            GameObject tempabl = Instantiate(fireAbility,this.transform.position,this.transform.rotation,abilityHolder.transform);
            tempabl.SendMessage("ability1");
        }
        canAbility1 = false;
        countMan.countdown(this.gameObject,cooldownVal,"1");
    }

    public void ability2()
    {

    }

    public void ability3()
    {

    }

    public void finishedCount1()
    {
        canAbility1 = true;
    }
}
