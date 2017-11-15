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
    }
    private void StopMovement()
    {
        SetStatusOfMovement(false);
        navAgent.SetDestination(player.transform.position);
    }
}
