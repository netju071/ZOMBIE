using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Move : MonoBehaviour {
    
    private float rotateSpeed = 3.74f;
    private float attackRange = 7f;
    private float attackTime = 0.5f, curAttackTime=1f;
    private Vector3 targetPosition;
    private bool isMoving, isEnemy;

    public Animation anim;
    private NavMeshAgent navComp;
    void Start()
    {
        isMoving = isEnemy = false;
        navComp = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        curAttackTime += Time.deltaTime;
        
        if (curAttackTime > attackTime)
        {
            if (Input.GetMouseButton(1))
            {
                isMoving = true;
                GetTargetPosition();
                MovePlayer();
            }

            if (Input.GetMouseButtonDown(0))
            {
                anim.Play("Attack");
                targetPosition = transform.position;
                MovePlayer();
                curAttackTime = 0;
            }

            else if (isMoving)
            {
                anim.Play("Walk");
            }
            else
            {
                anim.Play("Wait");
            }
        }
    }
    
    void GetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            targetPosition = ray.GetPoint(point);
        }

        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (hit.collider.gameObject.name == "Enemy")
        {
            isEnemy = true;
        }
    }
    void MovePlayer()
    {
        navComp.SetDestination(targetPosition);
        if (transform.position == targetPosition)
            isMoving = false;
    }

}
