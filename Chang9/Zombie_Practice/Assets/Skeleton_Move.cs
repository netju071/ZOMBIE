using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Move : MonoBehaviour {

    public Animator anim;
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("a"))
        {
            anim.Play("Attack");
        }

        if(Input.GetKeyDown("s"))
        {
            anim.Play("Skill");
        }
        
    }
}
