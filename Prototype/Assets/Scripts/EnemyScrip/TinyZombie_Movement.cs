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
    public void SetMovableTime(float value)
    {
        movableTime = value;
    }
    public void SetMovingTimeInterval(float value)
    {
        movingTimeInterval = value;
    }
    public void SetTimeToMove(float value)
    {
        timeToMove = value;
    }
    public void SetTimeToMove()
    {
        timeToMove = Time.time + GetMovingTimeInterval();
    }
    public void SetTimeToStop()
    {
        timeToStop = Time.time + GetMovableTime();
    }
    public void SetTargetPosition(Vector3 pos)
    {
        targetPos = pos;
    }
    public float GetMovableTime()
    {
        return movableTime;
    }
    public float GetMovingTimeInterval()
    {
        return movingTimeInterval;
    }
    public float GetTimeToMove()
    {
        return timeToMove;
    }
    public float GetTimeToStop()
    {
        return timeToStop;
    }
    public Vector3 GetTargetPosition()
    {
        return targetPos;
    }
    private void MoveToTarget()
    {
        SetStatusOfMovement(true);
        navAgent.destination = GetTargetPosition();

        if (DistanceFromPosition(GetTargetPosition()) == 0 || GetTimeToStop() <= Time.time)
        {
            StopMovement();
            SetTimeToMove();
        }
    }
    private void StopMovement()
    {
        SetStatusOfMovement(false);
        navAgent.SetDestination(zombie.transform.position);
    }
    private float DistanceFromPosition(Vector3 pos)
    {
        return Vector3.Distance(new Vector3(zombie.transform.position.x, 0, zombie.transform.position.z), new Vector3(pos.x, 0, pos.z));
    }
    private Vector3 RandomPosition()
    {
        return new Vector3(zombie.transform.position.x + Random.Range(-5.0f, 5.0f), zombie.transform.position.y, zombie.transform.position.z + Random.Range(-5.0f, 5.0f));
    }
}
