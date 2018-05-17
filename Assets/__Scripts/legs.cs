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
        
        GetComponent<Animator>().SetBool("Walking", ((a&&!d) || (d&&!a) || (s&&!w)|| (w&&!s)));
        if (d&&!a)
        {
            angle = 270;
        }
        if (a&&!d)
        {
            angle = 90;
        }
        if (w && !s)
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
        if (s&&!w)
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
                    angle = 225;
                }
            }
        }
        if (a || s || d || w)
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f,angle-180);
    }
}
