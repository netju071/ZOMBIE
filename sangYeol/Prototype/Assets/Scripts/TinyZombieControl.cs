using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyZombieControl : MonoBehaviour {
    private GameObject player;

    private float distance;
    private float detectionRange = 8.8f;
    private float attackRange = 1.5f;

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

        distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z));
        if (isAttacking)
        {
            return;
        }
        if (distance <= attackRange)
        {
            isMoving = false;
            isAttacking = true;
        }
        else if(distance <= detectionRange)
        {
            isAttacking = false;
            MoveZombie();
        }
        else
        {
            isAttacking = isMoving = false;
        }

        PlayAnimation();        
    }

    void PlayAnimation()
    {
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
        isMoving = true;
        Quaternion rotateAngle = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, rotateSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z));
        if (distance <= attackRange)
        {
            isMoving = false;
            isAttacking = true;
        }
            
    }
}
