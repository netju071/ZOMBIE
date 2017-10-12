using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private float moveSpeed = 4.2f;
    private float rotateSpeed = 3.74f;
    private float attackRange = 7f;

    //private CharacterController controller;
    private Vector3 targetPosition;
    private NavMeshAgent navComponent;

    private bool isMoving, isEnemy;

    public Animation anim;
    
    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        navComponent = GetComponent<NavMeshAgent>();


        isMoving = isEnemy = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1)) //Right Mouse Button
        {
            isMoving = false;

            //if the player clicked on the screen, find out where
            GetTargetPosition();

            if (isEnemy && (Vector3.Distance(transform.position, targetPosition) <= attackRange)) //클릭한 위치에 적이 위치하고 공격 가능하면 공격
            {
                Debug.Log("공격!");
                isEnemy = false;
                isMoving = false;
            }
            else
            {
                //set the player to move
                isMoving = true;
                MovePlayer();
            }
        }

        //if we are still moving, then move the player
        else if (isMoving)
        {
            if (isEnemy && (Vector3.Distance(transform.position, targetPosition) <= attackRange)) //클릭한 위치에 적이 위치하고 공격 가능하면 공격
            {
                Debug.Log("공격!");
                isEnemy = false;
                isMoving = false;
            }
            else
            {
                MovePlayer();
            }
        }

        if (isMoving)
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Wait");
        }

    }

    //Get the target position
    void GetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        //Check for enemies at the target position
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (hit.collider.gameObject.name == "Enemy")
        {
            isEnemy = true;
        }
    }

    //Moves the player in the right direction and also rotates them to look at the target position.
    //When the player gets to the target position, stop them from moving.
    void MovePlayer()
    {
        //Quaternion rotateAngle = Quaternion.LookRotation(targetPosition - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, rotateSpeed * Time.deltaTime);
        
        //transform.LookAt(targetPosition);
        navComponent.SetDestination(targetPosition);

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //if we are at the target position, then stop moving
        if (transform.position == targetPosition)
            isMoving = false;

        //Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

}