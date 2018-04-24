using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveChar : MonoBehaviour
{
    public enum eMode { idle, move, attack, transition }

    public float speed = 5;
    public int dirHeld = -1;
    private Rigidbody2D rigid;
    private Animator anim;
    private Vector3[] directions = new Vector3[]
    {
        Vector3.right, Vector3.up, Vector3.left, Vector3.down
    };
    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow
    };

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        dirHeld = -1;
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKey(keys[i])) dirHeld = i;
        }

        if (Input.GetKey(KeyCode.RightArrow)) dirHeld = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dirHeld = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) dirHeld = 2;
        if (Input.GetKey(KeyCode.DownArrow)) dirHeld = 3;
        Vector3 vel = Vector3.zero;
        if (dirHeld > -1) vel = directions[dirHeld];

        switch (dirHeld)
        {
            case 0:
                vel = Vector3.right;
                break;
            case 1:
                vel = Vector3.up;
                break;
            case 2:
                vel = Vector3.left;
                break;
            case 3:
                vel = Vector3.down;
                break;
        }
        rigid.velocity = vel * speed;
        if (dirHeld == -1)
        {
        }
        else
        {
           
        }

    }
}