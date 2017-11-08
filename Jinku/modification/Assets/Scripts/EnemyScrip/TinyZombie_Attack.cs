using UnityEngine;
public partial class TinyZombie_Controller : MonoBehaviour
{
    private float attackRange, nextTime, attackInterval,TinyZombieDamage;
    GameObject zombieRange;
    private bool beingAttacked;
    private void InitializeAttack()
    {
        zombieRange = Resources.Load<GameObject>("Create/Zombie_Range");
        SetAttackRange(1.5f);
        SetTinyZombieDamage(5);
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
    private void SetTinyZombieDamage(float value)
    {
        TinyZombieDamage = value;
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
    public float GetNextTime()
    {
        return nextTime;
    }
    public float GetTinyZombieDamage()
    {
        return TinyZombieDamage;
    }
    public bool GetStatusOfBeingAttacked()
    {
        return beingAttacked;
    }
    private void AttackTargetObject()
    {
        SetStatusOfAttack(true);
        zombie.transform.LookAt(new Vector3(player.transform.position.x, zombie.transform.position.y, player.transform.position.z));
        CoolUp();

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
    public void CreateCollider()
    {
        Instantiate(zombieRange, zombie.transform.position, zombie.transform.rotation);
    }

}
