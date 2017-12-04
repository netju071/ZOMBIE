using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject player;

    // Use this for initialization
    private void Start()
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

            if(GetTargetObjectTag() == "Enemy" && DistanceFromTargetObject() <= GetAttackRange())
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
            if (GetTargetObjectTag() == "Enemy" && DistanceFromTargetObject() <= GetAttackRange())
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Range")
            DecreaseHealth(other.gameObject.transform.parent.GetComponent<TinyZombie_Controller>().GetTinyZombieDamage());
    }
}