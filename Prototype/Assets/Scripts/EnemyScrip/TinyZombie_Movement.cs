using UnityEngine;
using UnityEngine.AI;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Vector3 targetPos;
    
    private float movingTimeInterval;
    private float movableTime;
    private float timeToMove;
    private float timeToStop;

    private void InitializeMovement()
    {
        navAgent = zombie.GetComponent<NavMeshAgent>();
        SetTargetPosition(zombie.transform.position);
        SetMovingTimeInterval(5f);
        SetMovableTime(7f);
        SetTimeToMove(0f);
        SetTimeToStop();
    }
    private void SetMovableTime(float value)
    {
        movableTime = value;
    }
    private void SetMovingTimeInterval(float value)
    {
        movingTimeInterval = value;
    }
    private void SetTimeToMove(float value)
    {
        timeToMove = value;
    }
    private void SetTimeToMove()
    {
        timeToMove = Time.time + GetMovingTimeInterval();
    }
    private void SetTimeToStop()
    {
        timeToStop = Time.time + GetMovableTime();
    }
    private void SetTargetPosition(Vector3 pos)
    {
        targetPos = pos;
    }
    private float GetMovableTime()
    {
        return movableTime;
    }
    private float GetMovingTimeInterval()
    {
        return movingTimeInterval;
    }
    private float GetTimeToMove()
    {
        return timeToMove;
    }
    private float GetTimeToStop()
    {
        return timeToStop;
    }
    private Vector3 GetTargetPosition()
    {
        return targetPos;
    }
    private void MoveToTarget()
    {
        SetStatusOfMovement(true);
        navAgent.destination = GetTargetPosition();

        if (DistanceFromPosition(GetTargetPosition()) == 0)
        {
            StopMovement();
        }
    }
    private void StopMovement()
    {
        SetStatusOfMovement(false);
        navAgent.SetDestination(zombie.transform.position);
    }
    public float DistanceFromPosition(Vector3 pos)
    {
        return Vector3.Distance(new Vector3(zombie.transform.position.x, 0, zombie.transform.position.z), new Vector3(pos.x, 0, pos.z));
    }
    public Vector3 RandomPosition()
    {
        //float minPosX = -34.94f, maxPosX = 13.5f, minPosZ = -23.26f, maxPosZ = 1.84f;
        //return new Vector3(Random.Range(minPosX, maxPosX), transform.position.y, Random.Range(minPosZ, maxPosZ));
        return new Vector3(zombie.transform.position.x + Random.Range(-5.0f, 5.0f), zombie.transform.position.y, zombie.transform.position.z + Random.Range(-5.0f, 5.0f));
    }
}
