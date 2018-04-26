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

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running&&(!anim.GetCurrentAnimatorStateInfo(0).IsName("fireAbility")))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("fireAbility") && other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Destroy(other.gameObject);
        }
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
