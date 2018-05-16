using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityInst : MonoBehaviour
{
    public enum Character { Ooga, otherchar1, otherchar2 };
    public Character curchar = Character.Ooga;
    protected Animator anim;
    public Animation fireanim;
    public bool running = false;
    public string animName = "fireAbility";
    public bool WaitaFrame = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        running = true;
        anim.Play(animName);
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitaFrame)
        {
            if (running && (!anim.GetCurrentAnimatorStateInfo(0).IsName(animName)))
            {
                Destroy(gameObject);
            }
        }
        WaitaFrame = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    public void ability1()
    {
        anim = GetComponent<Animator>();
        if (curchar == Character.Ooga)
        {
            anim.Play("fireAbility");
        }

        running = true;
    }

    public void ability2()
    {

    }

    public void ability3()
    {

    }
}
