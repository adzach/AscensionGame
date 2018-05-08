//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class HeroSelector : MonoBehaviour {
//    [Header("Set in Inspector")]
//    string[] HeroNames = { "Mage","Cowboy","Gasman"};
//    Sprite[] Heads = new Sprite[3];
//    Animator[] Guns = new Animator[3];
//    float[] healths = {400f, 200f, 150f};
//    float[] Firerates = {0.5f, 1.0f, 0.1f};
//    GameObject[] projectiles; 
//    float[] Speeds = {10f, 7f, 5f};
//    static Weapon CowboyWeapon = new CowboyWeapon();
//    static Weapon MageWeapon = new MageWeapon();
//    static Weapon GasManWeapon = new GasmanWeapon();
//    Weapon[] weapons = new Weapon[] {new MageWeapon(), new CowboyWeapon(),new GasmanWeapon()};
//    HeroInfo[] HeroInfos = new HeroInfo[3];
//
//    void Awake(){
//        projectiles = new GameObject[3];
//        Heads[0] = Resources.Load<Sprite>("Mage head");
//        //this.gameObject.AddComponent<SpriteRenderer>().sprite = Heads[0];
//        Heads[1] = Resources.Load<Sprite>("Cowboy head") as Sprite;
//        //this.gameObject.AddComponent<SpriteRenderer>().sprite = Heads[1];
//        Heads[2] = Resources.Load<Sprite>("Gas Man") as Sprite;
//        //this.gameObject.AddComponent<SpriteRenderer>().sprite = Heads[2];
//        projectiles[0] = Resources.Load<GameObject>("Mage Bullet");
//        //Instantiate<GameObject>(projectiles[0]);
//        projectiles[1] = Resources.Load<GameObject>("Cowboy Bullet");
//        //Instantiate<GameObject>(projectiles[1]);
//        projectiles[2] = Resources.Load<GameObject>("Gas");
//        //Instantiate<GameObject>(projectiles[2]);
//    }
//
//    // Use this for initialization
//    void StartHeroInfo () {
//        Awake();
//        print("this is the hero info length: " + HeroInfos.Length);
//		for (int i = 0; i < HeroNames.Length; i++)
//        {
//            weapons[i].Firerate = Firerates[i];
//            weapons[i].ProjectilePrefab = projectiles[i];
//            weapons[i].Speed = Speeds[i];
//            HeroInfo test = new HeroInfo(HeroNames[i], Heads[i], Guns[i], healths[i], weapons[i]);
//            HeroInfos[i] = test;
//            print("test "+test.HeroName);
//            print((HeroInfos[i] == null)+" if null there is error");
//        }
//        print("heroInfo null test "+HeroInfos[0].HeroName);
//	}
//	
//	 Update is called once per frame
//	void Update () {
//		
//	}
//
//    public HeroInfo getHero(string HeroName)
//    {
//        StartHeroInfo();
//        foreach(HeroInfo HI in HeroInfos)
//        {
//            print(HI.HeroName);
//            print(HeroName);
//            if (HI.HeroName == HeroName)
//            {
//                print("returning "+HI.HeroName);
//                return HI;
//            }
//        }
//        return HeroInfos[0];
//    }
//}