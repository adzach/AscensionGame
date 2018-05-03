using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    static public Hero S;

    //[Header("Set in Inspector")]
    private float speed = 20;
    public enum MoveCode {moveCode1,moveCode2,moveCode3};
    public MoveCode moveWith = MoveCode.moveCode1;
    private float walkSpeed;
    public float curSpeed;
    private float maxSpeed;
    private float agility = 5;
    private float sprintSpeed;

    void Awake () {
		if (S == null) {
			S = this;
		} else {
			Debug.LogError ("Attempted to assign second hero");
		}

        walkSpeed = (float)(speed + (agility));
        sprintSpeed = walkSpeed + (walkSpeed / 2);
    }

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if(moveWith==MoveCode.moveCode1)moveCode1();
        else if (moveWith == MoveCode.moveCode2) moveCode2();
    }

    void moveCode1()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
    }

    void moveCode2()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    
    }
}
