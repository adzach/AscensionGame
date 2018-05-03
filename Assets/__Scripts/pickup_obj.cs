using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_obj : MonoBehaviour {
    private int dontspwn = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if(dontspwn>0) dontspwn--;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dontspwn > 0) Destroy(gameObject);
    }
}
