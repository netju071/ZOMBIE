using UnityEngine;
public partial class TinyZombie_Controller : MonoBehaviour
{
    private float attackRange, detectRange, nextTime, attackInterval,TinyZombieDamage;
    private GameObject zombieRange, attackResource;

    private void InitializeAttack()
    {
        zombieRange = Resources.Load<GameObject>("Create/Zombie_Range");
        SetAttackRange(1.5f);
        SetDetectRange(7.0f);
        SetTinyZombieDamage(5);
        SetAttackInterval(1.0f);
    }
    private void SetAttackRange(float value)
    {
        attackRange = value;
    }
    private void SetDetectRange(float value)
    {
        detectRange = value;
    }
    private void SetAttackInterval(float value)
    {
        attackInterval = value;
    }
    private void SetNextTime(float value)
    {
        nextTime = value;
    }
    private void SetTinyZombieDamage(float value)
    {
        TinyZombieDamage = value;
    }
    public float GetAttackRange()
    {
        return attackRange;
    }
    public float GetDetectRange()
    {
        return detectRange;
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
    private void AttackTargetObject()
    {
        SetStatusOfAttack(true);
        zombie.transform.LookAt(new Vector3(player.transform.position.x, zombie.transform.position.y, player.transform.position.z));
        CoolUp();
    }
    public void CreateAttackResource()
    {
        attackResource = Instantiate(zombieRange, zombie.transform.position, zombie.transform.rotation);
        attackResource.transform.parent = gameObject.transform;
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
