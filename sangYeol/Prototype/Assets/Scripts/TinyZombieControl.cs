using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyZombieControl : MonoBehaviour {
    private GameObject player;

    private float moveSpeed = 2.1f;
    private float rotateSpeed = 3.74f;
    private bool isMoving, isAttacking;

    public Animation anim;

    // Use this for initialization
    void Start () {
        isMoving = isAttacking = false;
        player = GameObject.Find("Cha_Knight");
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) > 1.5f)
        {
            isMoving = true;
            isAttacking = false;
            MoveZombie();
        }
        else
        {
            isAttacking = true;
        }

        if (isMoving)
        {
            anim.Play("crippledWalk");
        }
        else if (isAttacking)
        {
            anim.Play("hit");
        }
        else
        {
            anim.Play("idle02");
        }
    }

    void MoveZombie()
    {
        Quaternion rotateAngle = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, rotateSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        //if we are at the target position, then stop moving
        if (Vector3.Distance(player.transform.position, transform.position) <= 1.5f)
        {
            isMoving = false;
            isAttacking = true;
        }
    }
}
