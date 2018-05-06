using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelector : MonoBehaviour {
    [Header("Set in Inspector")]
    public string[] HeroNames = { "Mage","Cowboy","Gasman"};
    public Sprite[] Heads;
    public Animator[] Guns;
    public float[] healths;
    public float[] Firerates;
    public GameObject[] projectiles;
    public float[] Speeds;
    static Weapon CowboyWeapon = new CowboyWeapon();
    static Weapon MageWeapon = new MageWeapon();
    static Weapon GasManWeapon = new GasmanWeapon();
    public Weapon[] weapons = new Weapon[] {new MageWeapon(), new CowboyWeapon(),new GasmanWeapon()};
    HeroInfo[] HeroInfos;

    // Use this for initialization
    void StartHeroInfo () {
        HeroInfos = new HeroInfo[HeroNames.Length];
        print("this is the hero info length: " + HeroInfos.Length);
		for (int i = 0; i < HeroNames.Length; i++)
        {
            weapons[i].Firerate = Firerates[i];
            weapons[i].ProjectilePrefab = projectiles[i];
            weapons[i].Speed = Speeds[i];
            HeroInfo test = new HeroInfo(HeroNames[i], Heads[i], Guns[i], healths[i], weapons[i]);
            HeroInfos[i] = test;
            print("test "+test.HeroName);
            print((HeroInfos[i] == null)+" if null there is error");
        }
        print("heroInfo null test "+HeroInfos[0].HeroName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public HeroInfo getHero(string HeroName)
    {
        StartHeroInfo();
        foreach(HeroInfo HI in HeroInfos)
        {
            print(HI.HeroName);
            print(HeroName);
            if (HI.HeroName == HeroName)
            {
                print("returning "+HI.HeroName);
                return HI;
            }
        }
        return HeroInfos[0];
    }
}