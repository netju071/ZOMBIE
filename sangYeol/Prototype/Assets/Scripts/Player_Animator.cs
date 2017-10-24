using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private Animator anim;
    
    private void InitializeAnimator()
    {
        anim = GetComponent<Animator>();
    }
    private void SetStatusOfAnimatorParameters()
    {
        anim.SetBool("isMoving", GetStatusOfMovement());
        anim.SetBool("isAttacking", GetStatusOfAttack());
    }
}
