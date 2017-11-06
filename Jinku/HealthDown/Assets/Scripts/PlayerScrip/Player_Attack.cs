using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private float attackRange, nextTime, attackInterval;
    private void InitializeAttack()
    {
        SetAttackRange(2.0f);
        SetAttackInterval(1.0f);    
    }
    private void SetAttackRange(float value)
    {
        attackRange = value;
    }
    private void SetAttackInterval(float value)
    {
        attackInterval = value;
    }
    private void SetNextTime(float value)
    {
        nextTime = value;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }
    public float GetAttackInterval()
    {
        return attackInterval;
    }
    public float GetNextTime()
    {
        return nextTime;
    }
    
    private void AttackTargetObject()
    {
        SetStatusOfAttack(true);
        player.transform.LookAt(new Vector3(targetPosition.x, player.transform.position.y, targetPosition.z));
        CoolUp();
        if (targetObject == null)
            SetStatusOfAttack(false);
    }

    public void CreatCollider()
    {
        switch (GetCurWeaponType())
        {
            case 1:
                Instantiate(sword_range, player.transform.position, player.transform.rotation);
                break;

            case 2:
                Instantiate(arrow, player.transform.position, player.transform.rotation);
                break;
            default:
                Debug.Log("[경고]: CurWeaponType값이 범위에서 벗어났습니다.");
                break;
        }
    }

    public void CoolDown()
    {
        SetStatusOfCool(true);
        nextTime = Time.time + attackInterval;
    }
    private void CoolUp()
    {
        if (nextTime <= Time.time)
        {
            SetStatusOfCool(false);
        }
    }
    //public bool BeingAttacked ()
    //{

    //}
}
