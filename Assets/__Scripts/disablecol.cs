using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablecol : MonoBehaviour {
    Collider2D col;
    bool start = true;
    float starttime;
    float dur = 0.5f;
    public string animname = "";

	// Use this for initialization
	void Awake () {
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(col.isActiveAndEnabled && start)
        {
            starttime = Time.time;
            start = false;
            GetComponent<Animator>().Play(animname);
        }
        if(!start && (Time.time-starttime)>dur)
        {
            col.enabled = false;
            start = true;
        }
	}
}
