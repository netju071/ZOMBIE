﻿using UnityEngine;

public class Player_Animator_Attack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("/Player").GetComponent<Player_Controller>().CreateCollider();
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().GetStatusOfBeingAttacked() == true)
        {
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().DecreaseHealth(GameObject.Find("/Player").GetComponent<Player_Controller>().GetPlayerDamage());
        }

        GameObject.Find("/Player").GetComponent<Player_Controller>().CoolDown();

        if (GameObject.Find("/Player").GetComponent<Player_Controller>().GetCurWeaponType()==1)
        {
            Resources.Load<GameObject>("Create/Sword_Range").GetComponent<Sword_Range>().DestoryCollider();
        }

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
