using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject player;

    // Use this for initialization
    private void Awake()
    {
        player = GameObject.Find("/Player/Cha_Knight");
        InitializeMovement();
        InitializeTargeting();
        InitializeAttack();
        InitializeAnimator();
        InitializeHealth();
    }
	
	// Update is called once per frame
	private void Update()
    {
        //Debug.Log("Distance: "+DistanceFromTarget());
        //Debug.Log("isMoving: " + GetStatusOfMovement()+", isAttacking: "+GetStatusOfAttack());
        if (Input.GetMouseButton(1))
        {
            if (GetStatusOfAttack())
            {
                return;
            }
            else if (GetStatusOfMovement())
            {
                //StopMovement();
            }
            Targeting();
            if (GetTargetObjectTag()=="Enemy" && DistanceFromTarget() <= GetAttackRange())
            {
                AttackTargetObject();
            }
            else
            {
                MoveToTargetObject();
            }
        }
        else
        {

        }

        SetStatusOfAnimatorParameters();
        MoveHealthBarAlongPlayer();
    }
}
