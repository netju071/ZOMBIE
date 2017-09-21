using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private float moveSpeed = 10f;
    private float rotateSpeed = 3f;

    private CharacterController controller;
    private Vector3 targetPosition;
    private bool isMoving;

    public Animation anim;
    
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {

        //if the player clicked on the screen, find out where
        if (Input.GetMouseButton(1)) //Right Mouse Button
        {
            SetTargetPosition();
        }
        //if we are still moving, then move the player
        if (isMoving)
            MovePlayer();

        if (isMoving)
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Idle");
        }

    }

    //Sets the target position we will travel too.
    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        //set the player to move
        isMoving = true;
    }

    //Moves the player in the right direction and also rotates them to look at the target position.
    //When the player gets to the target position, stop them from moving.
    void MovePlayer()
    {
        //transform.LookAt(targetPosition);
        Quaternion rotateAngle = Quaternion.LookRotation(targetPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, rotateSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //if we are at the target position, then stop moving
        if (transform.position == targetPosition)
            isMoving = false;
        //Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

}
