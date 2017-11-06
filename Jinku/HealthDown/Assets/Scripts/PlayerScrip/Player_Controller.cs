using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject player;
    private bool isCollider;
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.Find("/Player/Cha_Knight");
        InitializeAnimator();
        InitializeWeapon();
        InitializeMovement();
        InitializeTargeting();
        InitializeAttack();
        InitializeHealth();
    }
	
	// Update is called once per frame
	private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetStatusOfAttack())
            {
                if (GetStatusOfCool() == false)
                {
                    return;
                }
                else
                {
                    SetStatusOfAttack(false);
                }
            }
            else if (GetStatusOfMovement())
            {
                StopMovement(); //수정 요망
            }

            Targeting();

            if(GetTargetObjectTag() == "Enemy" && DistanceFromTarget() <= GetAttackRange())
            {
                AttackTargetObject();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            }
            else
            {
                MoveToTargetObject();
            }
        }

        if (GetStatusOfMovement())
        {
            if (GetTargetObjectTag() == "Enemy" && DistanceFromTarget() <= GetAttackRange())
            {
                StopMovement();
                AttackTargetObject();
            }
            else
            {
                MoveToTargetObject();
            }
        }
        else if (GetStatusOfAttack())
        {
            AttackTargetObject();
        }
        SwapWeapon();
        MoveHealthBarAlongPlayer();
        
    }
    ////////////////////////////////////////// collider statuse change function
    public void SetStatusOfCollider(bool status)
    {
        isCollider = status;
    }
    public bool GetStatusOfCollider()
    {
        return isCollider;
    }
    ///////////////////////////////////////////////
}