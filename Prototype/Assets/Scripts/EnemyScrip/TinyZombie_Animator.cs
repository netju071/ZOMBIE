﻿using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private Animator anim;
    private void InitializeAnimator()
    {
        anim = GetComponent<Animator>();
        SetStatusOfMovement(false);
        SetStatusOfAttack(false);
        SetStatusOfCool(false);
    }
    public void SetStatusOfMovement(bool status)
    {
        anim.SetBool("isMoving", status);
    }
    public void SetStatusOfAttack(bool status)
    {
        anim.SetBool("isAttacking", status);
    }
    public void SetStatusOfCool(bool status)
    {
        anim.SetBool("isCool", status);
    }

    public bool GetStatusOfMovement()
    {
        return anim.GetBool("isMoving");
    }
    public bool GetStatusOfAttack()
    {
        return anim.GetBool("isAttacking");
    }
    public bool GetStatusOfCool()
    {
        return anim.GetBool("isCool");
    }
}
