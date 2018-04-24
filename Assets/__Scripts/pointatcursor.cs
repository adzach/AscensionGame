using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointatcursor : MonoBehaviour 
{
	float angle = 0;
	int xnega = 1;
	int znega = 1;
	public Vector3 diff;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.y = 0;
		diff.Normalize();
       // print(diff);
		if(diff.x<0) xnega = -1;
		else xnega = 1;
		if(diff.z<0) znega = -1;
		else znega = 1;

		//diff = new Vector3(xnega*Mathf.Log(Mathf.Abs(diff.x)+1), diff.y ,znega * Mathf.Log(Mathf.Abs(diff.y)+1));

        angle = xnega*Mathf.Atan(Mathf.Abs(diff.x) / Mathf.Abs(diff.z))*(180/Mathf.PI);

		//diff *= 80/0.5f;
		//if(diff.z > 80) diff.z = 80;
		//if(diff.x < -80) diff.x = -80;
		//diff /= Mathf.Sqrt(90f);
		//diff = new Vector3(Mathf.Pow(diff.x,2), Mathf.Pow(diff.y,2), diff.z);
		//angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, -znega*(-angle + 90)+90, 0f);
	}
}
