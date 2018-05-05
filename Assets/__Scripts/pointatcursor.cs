using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointatcursor : MonoBehaviour 
{
	public float angle = 0;
	int xnega = 1;
	int ynega = 1;
	public Vector3 diff;
	
	// Update is called once per frame
	void Update () 
	{
		diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.z = 0;
		diff.Normalize();
       // print(diff);
		if(diff.x<0) xnega = -1;
		else xnega = 1;
		if(diff.y<0) ynega = -1;
		else ynega = 1;

		//diff = new Vector3(xnega*Mathf.Log(Mathf.Abs(diff.x)+1), diff.y ,znega * Mathf.Log(Mathf.Abs(diff.y)+1));

        angle = xnega*Mathf.Atan(Mathf.Abs(diff.x) / Mathf.Abs(diff.y))*(180/Mathf.PI);

		//diff *= 80/0.5f;
		//if(diff.z > 80) diff.z = 80;
		//if(diff.x < -80) diff.x = -80;
		//diff /= Mathf.Sqrt(90f);
		//diff = new Vector3(Mathf.Pow(diff.x,2), Mathf.Pow(diff.y,2), diff.z);
		//angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f,ynega * (-angle + 90) + 90);
	}
}
