using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Move : MonoBehaviour {

    private float moveSpeed = 1f;
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
        if(isMoving || Input.GetMouseButton(1))
        {
            if(Input.GetMouseButton(1))
                GetTargetPosition();

            isMoving = false;
            if (isEnemy && (Vector3.Distance(transform.position, targetPosition) <= attackRange))
            {
                Debug.Log("Attack!");
                isEnemy = isMoving = false;
            }

            else
            {
                isMoving = true;
                MovePlayer();
            }

        }
        if(curAttackTime > attackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.Play("Attack");
                isMoving = false;
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
        //Quaternion rotateAngle = Quaternion.LookRotation(targetPosition - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, rotateSpeed * Time.deltaTime);

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
       navComp.SetDestination(isMoving == true ? targetPosition : transform.position);
        if (transform.position == targetPosition)
            isMoving = false;
    }

}
