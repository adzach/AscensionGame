using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbutton : MonoBehaviour 
{
	Vector3 endPosition;
	Vector3 targetPosition;
	Vector3 initpos;
	public Transform baby;
	public float laserWidth = 0.025f;
	public LineRenderer laserLineRenderer;
	public bool test = false;
	// Use this for initialization
	void Start () 
	{
		Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
		laserLineRenderer.SetPositions( initLaserPositions );
		laserLineRenderer.startWidth = laserWidth/2;
		laserLineRenderer.endWidth = laserWidth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void shoot(Transform halo)
	{
		targetPosition = baby.position;
		endPosition = halo.position + new Vector3(0.1f,0,-0.1f);

		laserLineRenderer.SetPosition( 0, endPosition);
		laserLineRenderer.SetPosition( 1, targetPosition);
		test = true;
	}
}
