using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelector : MonoBehaviour {
    public string[] HeroNames;
    public Sprite[] Heads;
    public Animator[] Guns;
    public float[] healths;
    public float[] Firerates;
    public GameObject[] projectiles;
    public float[] speeds;
    static Weapon CowboyWeapon = new CowboyWeapon();
    static Weapon MageWeapon = new MageWeapon();
    static Weapon GasManWeapon = new GasmanWeapon();
    public Weapon[] weapons = new Weapon[] {MageWeapon, CowboyWeapon, GasManWeapon};
    HeroInfo[] HeroInfos;

    // Use this for initialization
    void Start () {
        HeroInfos = new HeroInfo[HeroNames.Length];
		for (int i = 0; i < HeroNames.Length; i++)
        {
            weapons[i].Firerate = Firerates[i];
            weapons[i].ProjectilePrefab = projectiles[i];
            weapons[i].Speed = Speeds[i];
            HeroInfos[i] = new HeroInfo(HeroNames[i], Heads[i], Guns[i], healths[i], weapons[i]);
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public HeroInfo getHero(string HeroName)
    {
        foreach(HeroInfo HI in HeroInfos)
        {
            if (HI.HeroName == HeroName)
            {
                return HI;
            }
        }
        return null;
    }
}