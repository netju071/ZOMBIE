using UnityEngine;
using UnityEngine.AI;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private NavMeshAgent navAgent;


    private void InitializeMovement()
    {
        navAgent = zombie.GetComponent<NavMeshAgent>();
    }

    private void MoveToTargetObject()
    {
        SetStatusOfMovement(true);
        navAgent.destination = player.transform.position;

        if (DistanceFromTarget() == 0)
        {
            StopMovement();
        }
    }
    private void StopMovement()
    {
        SetStatusOfMovement(false);
        navAgent.SetDestination(zombie.transform.position);
    }

}
