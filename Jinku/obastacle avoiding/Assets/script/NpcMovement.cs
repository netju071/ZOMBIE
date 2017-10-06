using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;

    public float MoveSpeed = 3.0f;
    public float RotationSpeed = 3.0f;

    bool IsWaypoint = true;
    bool IsSearch = false;
    bool isCollider = false;

    public Animation anim;
    public GameObject Target;

    public Transform wayPoint;
    private Transform player;
    public NavMeshAgent navecomponet;

    void Start()
    {
        navecomponet = this.gameObject.GetComponent<NavMeshAgent>();
        anim.Play("Idle");
        currentPoint = 0;
    }

    void Update()
    {
        Searching();
        if (IsSearch)
            Chasing();
        else
            Moving();
        
    }
    void Searching()
    {
        if (Vector3.Distance(Target.transform.position, transform.position) < 10.0f)
            IsSearch = true;
        else
            IsSearch = false;
    }
    void Chasing()
    {
        if (Vector3.Distance(Target.transform.position, transform.position) > 1.5f)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), 3f);
            //transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * MoveSpeed);
            player = Target.transform;
            //using navgation
            navecomponet.SetDestination(player.position);
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * MoveSpeed);
            anim.CrossFade("Run", 0.5f,PlayMode.StopAll);
        }
        else if (!isCollider)
        {
            //if 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), 3f);
            anim.CrossFade("Attack",2.0f,PlayMode.StopAll);
        }
            
    }
    void Moving()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(patrolPoints[currentPoint].transform.position - transform.position), 3f);
        //transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].transform.position, Time.deltaTime * MoveSpeed);
        //Using navigation
        wayPoint = patrolPoints[currentPoint].transform;
        navecomponet.SetDestination(wayPoint.position);
        anim.CrossFade("Run", 0.5f);
        if (Vector3.Distance(patrolPoints[0].transform.position, transform.position) < 3.0f)
            currentPoint = 1;
        else if (Vector3.Distance(patrolPoints[1].transform.position, transform.position) < 3.0f)
            currentPoint = 0;
        Searching();
    }
    //Attack condition
    void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "player")
        {
           isCollider = true;
            //InvokeRepeating("decreasHealth", 0.1f, 0.1f);
        }
        else
        {
            isCollider = false;
            //InvokeRepeating("decreasHealth", 0.1f, 0.1f);
        }
    }
}