using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private float attackRange, nextTime, attackInterval, playerDamage;
    private bool beingAttacked;

    private void InitializeAttack()
    {
        SetAttackRange(2.0f);
        SetAttackInterval(1.0f);
        SetPlayerDamage(20f);
        SetStatusOfBeingAttacked(false);
    }
    private void SetAttackRange(float value)
    {
        attackRange = value;
    }
    private void SetAttackInterval(float value)
    {
        attackInterval = value;
    }
    private void SetPlayerDamage(float value)
    {
        playerDamage = value;
    }
    private void SetNextTime(float value)
    {
        nextTime = value;
    }
    public void SetStatusOfBeingAttacked(bool status)
    {
        beingAttacked = status;
    }
    public float GetAttackRange()
    {
        return attackRange;
    }
    public float GetAttackInterval()
    {
        return attackInterval;
    }
    public float GetPlayerDamage()
    {
        return playerDamage;
    }
    public float GetNextTime()
    {
        return nextTime;
    }
    public bool GetStatusOfBeingAttacked()
    {
        return beingAttacked;
    }
    
    private void AttackTargetObject()
    {
        SetStatusOfAttack(true);
        player.transform.LookAt(new Vector3(targetPosition.x, player.transform.position.y, targetPosition.z));
        CoolUp();
        if (targetObject == null)
            SetStatusOfAttack(false);
    }

    public void CreateCollider()
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
}
