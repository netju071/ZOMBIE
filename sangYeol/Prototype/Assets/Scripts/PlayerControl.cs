using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour {

    private NavMeshAgent navAgent;
    private GameObject targetObject;
    private Vector3 targetPosition;
    public Animation anim;
    bool isMoving, isAttacking;

    private float attackRange;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        SetCharacterStats();
        SetCharacterState();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(1))
        {
            if (isAttacking)
            {
                return;
            }
            else if (isMoving)
            {
                StopMoving();
            }

            SetTarget();

            //Debug.DrawRay(new Vector3(transform.position.x, 1.0f, transform.position.z), new Vector3(transform.forward.x, 0f, transform.forward.z) * attackRange, Color.red);



            if (targetObject.tag == "Enemy" && DistanceFromTarget() <= attackRange)
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
            if (isMoving)
            {
                Debug.Log("걷는거 힘들다..."+DistanceFromTarget());
                if (targetObject.tag == "Enemy" && DistanceFromTarget() <= attackRange)
                {
                    StopMoving();
                    AttackTargetObject();
                }
                else
                {
                    MoveToTargetObject();
                }
            }
            else if (isAttacking)
            {
                Debug.Log("공격중이니까 말걸지마ㅡㅡ!");
                AttackTargetObject();
            }
            else
            {
                Debug.Log("지금 아무것도 안하고 있지롱~");
            }

        }

        PlayAnimation();
	}

    void SetCharacterStats()
    {
        attackRange = 1.4f;
    }

    void SetCharacterState()
    {
        isMoving = isAttacking = false;
    }

    void InitializeTarget()
    {
        targetObject = null;
        targetPosition = Vector3.zero;
    }
    void SetTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            targetObject = hit.collider.gameObject;
            targetPosition = hit.point;
        }
        else
        {
            InitializeTarget();
        }
        
    }

    void MoveToTargetObject()
    {
        isMoving = true;
        navAgent.destination = targetPosition;
        //navAgent.SetDestination(targetPosition);
        //navAgent.Move(targetPosition);
        if (DistanceFromTarget()==0)
            isMoving = false;
    }

    void StopMoving()
    {
        isMoving = false;
        navAgent.destination = transform.position;
    }

    float DistanceFromTarget()
    {
        return Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPosition.x, 0, targetPosition.z));
    }

    void AttackTargetObject()
    {
        transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
        isAttacking = true;
        Debug.Log("죽여버리겠어!");
        
        //Debug.DrawRay(transform.position, transform.forward * attackRange, Color.blue);

        RaycastHit hit;
        //Debug.DrawRay(transform.position, transform.forward * attackRange);
        if (Physics.Raycast(new Vector3(transform.position.x, 1.0f, transform.position.z), new Vector3(transform.forward.x, 0f, transform.forward.z), out hit, attackRange)) //발사 위치, 발사 방향, 충돌 결과, 최대 거리
        {
            Debug.DrawRay(new Vector3(transform.position.x, 1.0f, transform.position.z), new Vector3(transform.forward.x, 0f, transform.forward.z) * attackRange, Color.red);
            Debug.Log("Damage");
        }
        else
        {
            Debug.DrawRay(new Vector3(transform.position.x, 1.0f, transform.position.z), new Vector3(transform.forward.x, 0f, transform.forward.z) * attackRange, Color.blue);
            Debug.Log("Miss");
        }
    }

    void PlayAnimation()
    {
        if (isMoving)
        {
            anim.Play("Walk");
        }
        else if (isAttacking)
        {
            anim.Play("Attack");
        }
        else
        {
            anim.Play("Wait");
        }
    }
}