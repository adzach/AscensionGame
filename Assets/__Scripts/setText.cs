using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setText : MonoBehaviour {
    public Text t;

    public void set(string txt)
    {
        t.text = txt;
    }
}
