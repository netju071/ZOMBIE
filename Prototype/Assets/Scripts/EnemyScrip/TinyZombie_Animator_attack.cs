using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyZombie_Animator_attack : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().CreateCollider();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameObject.Find("/Player").GetComponent<Player_Controller>().GetStatusOfBeingAttacked() == true)
        {
            GameObject.Find("/Player").GetComponent<Player_Controller>().DecreaseHealth(GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().GetTinyZombieDamage());
        }
        //GameObject.Find("/Player").GetComponent<Player_Controller>().DecreaseHealth(GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().GetTinyZombieDamage());
        Resources.Load<GameObject>("Create/Zombie_Range").GetComponent<Zombie_Range>().DestoryCollider();
        GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().CoolDown();
        //Debug.Log("Onanimator");
        //Debug.Log(GameObject.Find("/Player").GetComponent<Player_Controller>().GetStatusOfCollider());
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
