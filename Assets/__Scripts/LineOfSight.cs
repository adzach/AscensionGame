using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {
    public Collider2D coll;
    public bool looking = false;
    public List<GameObject> seeing = new List<GameObject>();
    public List<GameObject> visible = new List<GameObject>();
    public int angleRange = 30;
    public int precision = 50;
	// Use this for initialization
	void Start ()
    {
        //coll = gameObject.GetComponent<Collider>();
	}

    // Update is called once per frame
    void Update()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (coll.Raycast(ray, out hit, 100.0F))
        {
            looking = true;
            hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else looking = false;*/
        markTargets();
        displayTargets();
       
    }


    public void markTargets()
    {
        for(int i = -angleRange; i<=angleRange; i+= 2*angleRange/precision)
        {
            this.gameObject.transform.localEulerAngles = new Vector3(
                 this.gameObject.transform.localEulerAngles.x,
                  this.gameObject.transform.localEulerAngles.y,
                   this.gameObject.transform.localEulerAngles.z + i);
            //print(this.gameObject.transform.localEulerAngles.y+" "+i);
            markTarget();

            this.gameObject.transform.localEulerAngles = new Vector3(
                  this.gameObject.transform.localEulerAngles.x,
                  this.gameObject.transform.localEulerAngles.y,
                   this.gameObject.transform.localEulerAngles.z - i);
        }
    }

    public void markTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("hideLOS"))
            {
                if (!seeing.Contains(hit.collider.gameObject))
                {
                    seeing.Add(hit.collider.gameObject);
                    print("did something");
                    
                }
            }
        }
    }

    public void displayTargets()
    {
        for (int i = 0; i < seeing.Count; i++)
        {
            seeing[i].GetComponent<SpriteRenderer>().enabled = true;
            if (visible.Contains(seeing[i])) visible.Remove(seeing[i]);
        }
        for (int i = 0; i < visible.Count; i++)
        {
            visible[i].GetComponent<SpriteRenderer>().enabled = false;
            //print(visible.Count + "");
        }
        

        visible.Clear();
        for (int i = 0; i < seeing.Count; i++)
        {
            visible.Add(seeing[i]);
        }
        seeing.Clear();
    }
    
}
