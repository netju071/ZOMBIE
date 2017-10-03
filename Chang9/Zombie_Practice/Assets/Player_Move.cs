using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public Animation anim;
	void Start ()
    {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("a"))
        {
            anim.Play("Attack");            
        }
        if (Input.GetKeyDown("s"))
        {
            anim.Play("Wait");
        }
        if (Input.GetKeyDown("d"))
        {
            anim.Play("Walk");
        }
        if (Input.GetKeyDown("f"))
        {
            anim.Play("Damage");
        }
    }

}
