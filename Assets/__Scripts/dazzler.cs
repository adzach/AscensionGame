//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class dazzler : MonoBehaviour {
//    private ParticleSystem PS;
//    private Color SC;
//	// Use this for initialization
//	void Start () {
//        PS = GetComponent<ParticleSystem>();
//        SC = PS.startColor;
//    }
//	
//	// Update is called once per frame
//	void FixedUpdate () {
//        
//        float r = Random.Range(-0.2f, 0.2f);
//        float g = Random.Range(-0.2f, 0.2f);
//        float b = Random.Range(-0.2f, 0.2f);
//        float a = Random.Range(-0.2f, 0.2f);
//        PS.startColor = new Color(SC.r + r, SC.g + g, SC.b + b, SC.a+a);
//    }
//}
