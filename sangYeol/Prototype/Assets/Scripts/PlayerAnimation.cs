using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animation anim;

    // Use this for initialization
    void Awake()
    {
        //Debug.Log(GetComponent<PlayerStatus>().GetStatusOfMovement());
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnimation();
	}

    void PlayAnimation()
    {
        if (GetComponent<PlayerStatus>().GetStatusOfMovement())
        {
            anim.Play("Walk");
        }
        else if (GetComponent<PlayerStatus>().GetStatusOfAttack())
        {
            anim.Play("Attack");
        }
        else
        {
            anim.Play("Wait");
        }
    }
}
