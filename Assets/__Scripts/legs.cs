using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legs : MonoBehaviour {
    public bool a;
    public bool s;
    public bool d;
    public bool w;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float angle = this.gameObject.transform.rotation.z;
        a = Input.GetKey("a");
        s = Input.GetKey("s");
        d = Input.GetKey("d");
        w = Input.GetKey("w");
        
        GetComponent<Animator>().SetBool("Walking", (a || s || d || w));
        if (d)
        {
            angle = 270;
        }
        if (a)
        {
            angle = 90;
        }
        if (w)
        {
            angle = 0;
            if (a)
            {
                angle = 45;
            }
            else
            {
                if (d)
                {
                    angle = -45;
                }
            }
        }
        if (s)
        {
            angle = 180;
            if (a)
            {
                angle = 135;
            }
            else
            {
                if (d)
                {
                    angle = 225f;
                }
            }
        }
        if (a || s || d || w)
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f,angle);
    }
}
