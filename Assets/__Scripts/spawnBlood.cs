using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBlood : MonoBehaviour {
    public GameObject blood;
    GameObject abilityHolder;
	// Use this for initialization
	void Start () {
        abilityHolder = GameObject.Find("abilityHolder");
    }

    public void makeBlood()
    {
        //print("made blood");
        Instantiate(blood, this.transform.position+ transform.TransformDirection(Vector3.up), this.transform.rotation, abilityHolder.transform);
    }
}
