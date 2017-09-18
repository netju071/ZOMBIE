using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public Animator anim;
    private float inputH;
    private float inputV;
    private bool run;
    private float inputA;
    private bool attack;
    public Rigidbody rbody;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
        attack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Damage", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("Attack", -1, 0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            attack= true;
        }
        else
        {
            attack = false;
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        anim.SetBool("run", run);
        anim.SetBool("attack", attack);
        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if (moveZ <= 0f)
        {
            moveX = 0f;
        }
        rbody.velocity = new Vector3(moveX, 0f, moveZ);

    }
}
