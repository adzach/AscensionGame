using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroInfo{
        public string HeroName;
        public Sprite Head;
        public Animator Gun;
        public float health;
        public Weapon weapon;
    public HeroInfo(string HN, Sprite H, Animator G, float h, Weapon w)
    {
        HeroName = HN;
        Head = H;
        Gun = G;
        health = h;
        weapon = w;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
