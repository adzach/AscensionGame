using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour {
    Text TextBox;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setText(string Text)
    {
        TextBox = this.GetComponent<Text>();
        TextBox.text = Text;
    }
}
