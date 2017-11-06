using UnityEngine;
using UnityEngine.AI;

public partial class Player_Controller : MonoBehaviour
{
    private NavMeshAgent navAgent;

    
    private void InitializeMovement()
    {
        navAgent = player.GetComponent<NavMeshAgent>();
    }
    
    private void MoveToTargetObject()
    {
        SetStatusOfMovement(true);
        navAgent.destination = targetPosition;

        if (DistanceFromTarget() == 0)
        {
            StopMovement();
        }
        //else
        //    Debug.Log("이동~");
    }
    private void StopMovement()
    {
        SetStatusOfMovement(false);
        navAgent.SetDestination(player.transform.position);
        //Debug.Log("이동을 중지하였습니다.");
    }

}
