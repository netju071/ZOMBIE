using UnityEngine;
using UnityEngine.AI;

public partial class Player_Controller : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private bool isMoving;
    
    private void InitializeMovement()
    {
        navAgent = player.GetComponent<NavMeshAgent>();
        SetStatusOfMovement(false);
    }
    private void SetStatusOfMovement(bool status)
    {
        isMoving = status;
    }
    public bool GetStatusOfMovement()
    {
        return isMoving;
    }
    public float DistanceFromTarget()
    {
        return Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(targetPosition.x, 0, targetPosition.z));
    }
    private void MoveToTargetObject()
    {
        SetStatusOfMovement(true);
        navAgent.destination = targetPosition;

        if (DistanceFromTarget() == 0)
        {
            StopMovement();
        }
        else
            Debug.Log("이동~");
    }
    private void StopMovement()
    {
        SetStatusOfMovement(false);
        navAgent.destination = player.transform.position;
        Debug.Log("이동을 중지하였습니다.");
    }

}
