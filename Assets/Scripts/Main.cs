using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	[Header ("Set in Inspector")]
	public GameObject[] levels;
	public Vector3 levelPos;

	[Header ("Set Dynamically")]
	public GameObject level;

	// Use this for initialization
	void Start () {
		level = Instantiate<GameObject> (levels [0]);
		level.transform.position = levelPos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
