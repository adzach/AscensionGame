using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablecol : MonoBehaviour {
    Collider2D col;
    bool start = true;
    public string animname = "";
    bool animing= false;

	// Use this for initialization
	void Awake () {
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (col.isActiveAndEnabled && start)
        {
            start = false;
            GetComponent<Animator>().Play(animname);
        }
        if (!start && animing && (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animname)))
        {
            col.enabled = false;
            start = true;
            animing = false;
        }
        if (!animing && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animname))
        {
            animing = true;
        }
        
    }
}
