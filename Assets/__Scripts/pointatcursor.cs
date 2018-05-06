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
		if(diff.x<0) {
      xnega = -1;
    }
		else {
      xnega = 1;
    }
		if(diff.y<0) {
      ynega = -1;
    }
		else {
      ynega = 1;
    }

        angle = xnega*Mathf.Atan(Mathf.Abs(diff.x) / Mathf.Abs(diff.y))*(180/Mathf.PI);

		transform.rotation = Quaternion.Euler(0f, 0f,ynega * (-angle + 90) + 90);
	}
}
