using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 v = GetComponent<Rigidbody>().velocity;
        if (v.magnitude < 0.01)
        {
            v = Vector3.zero;
        }
        else
        {
            v = v * 0.99f;
        }
        GetComponent<Rigidbody>().velocity = v;
    }
}
