using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //private float rotateSpeed = 3.74f;
    

    private Vector3 targetPosition;
    private NavMeshAgent navComponent;
    private GameObject enemy;
    private float distance;
    private float attackRange = 7f;

    private bool isEnemy, isMoving, isAttacking;

    public Animation anim;

    // Use this for initialization
    void Start () {
        navComponent = GetComponent<NavMeshAgent>();
        isEnemy = isMoving = isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1)) //Right Mouse Button
        {
            GetTargetPosition(); //Find out where the player clicked on the screen and Make sure object is enemy
            BrakePlayer();


            //isMoving = false; 
            navComponent.SetDestination(transform.position); //클릭하면 이동 정지


            

            if (isEnemy)
            {
                distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z));

                if (distance <= attackRange)
                {
                    //isMoving = false;
                    isAttacking = true;
                }
                else
                {
                    MovePlayer();
                }
            }

            else //클릭한 위치가 스테이지이므로, 해당 위치로 이동한다.
            {
                MovePlayer();
            }




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

        

    }

    //Play Animation
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

    //Get the target position
    void GetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        IsEnemy(ray);
    }

    
    //Check for enemies at the target position
    void IsEnemy(Ray ray_)
    {
        RaycastHit hit;
        Physics.Raycast(ray_, out hit);
        if (hit.collider.gameObject.tag == "Enemy")
        {
            isEnemy = true;
            enemy = GameObject.Find(hit.collider.gameObject.name);
        }
        else
        {
            isEnemy = false;
        }
    }

    //Moves the player in the right direction and also rotates them to look at the target position.
    //When the player gets to the target position, stop them from moving.
    void MovePlayer()
    {
        isMoving = true;
        navComponent.SetDestination(targetPosition);

        //if we are at the target position, then stop moving
        if (transform.position == targetPosition)
            isMoving = false;

        //Quaternion rotateAngle = Quaternion.LookRotation(targetPosition - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, rotateSpeed * Time.deltaTime);

        //transform.LookAt(targetPosition);


        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

    void BrakePlayer()
    {
        isMoving = false;
        navComponent.SetDestination(transform.position);
    }

}