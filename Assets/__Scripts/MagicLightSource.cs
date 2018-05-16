using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MagicLightSource : MonoBehaviour
{

    public Material reveal;
    public Light mLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        reveal.SetVector("_LightPosition", mLight.transform.position);
        reveal.SetVector("_LightDirection", -mLight.transform.forward);
//        reveal.SetFloat("_LightAngle", light.spotAngle);
    }
}
