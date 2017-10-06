using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momyChase : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    public float speed;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 360)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isDancing", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRunning", false);

            if (direction.magnitude > 1.5 && direction.magnitude < 3)
            {
                anim.SetBool("isWalking", true);
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isDancing", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", false);

            }
            else if (direction.magnitude > 3)
            {
                this.transform.Translate(0, 0, 0.05f * speed);
                anim.SetBool("isRunning", true);
                anim.SetBool("isDancing", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
            }
            else if (direction.magnitude < 1.5)
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isDancing", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isDancing", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

    }
}
