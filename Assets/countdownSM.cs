using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownSM : MonoBehaviour {
    public GameObject retSM;
    public Text t;
    bool counting = false;
    public int count = 0;
    public int intercount = 0;
    public string abilityNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(counting)
        {
            if (count == 0)
            {
                retSM.SendMessage("finishedCount"+abilityNum);
                counting = false;
            }
            t.text = count+"";
            intercount++;
            if(intercount==60)
            {
                intercount = 0;
                count--;
            }
        }
	}

    public void countdown(GameObject retme, int start, string abnum)
    {
        retSM = retme;
        counting = true;
        count = start;
        abilityNum = abnum;
    }
}
