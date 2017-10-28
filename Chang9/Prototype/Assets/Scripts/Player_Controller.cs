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
            else
            {
                SetStatusOfMovement(true);
            }
            Targeting();

        }
        //if (GetTargetObjectTag()=="Enemy" && DistanceFromTarget() <= GetAttackRange())
        if (Input.GetMouseButtonDown(0) && !GetStatusOfAttack())
        {
            SetStatusOfAttack(true);
            StopMovement();
            AttackTargetObject();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(1);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(2);
        }
        MoveToTargetObject();
        CheckAttackCoolTime();
        SetStatusOfAnimatorParameters();
        MoveHealthBarAlongPlayer();
    }
}
