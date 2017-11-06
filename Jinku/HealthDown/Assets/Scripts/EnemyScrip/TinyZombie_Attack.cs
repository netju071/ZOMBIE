using UnityEngine;
public partial class TinyZombie_Controller : MonoBehaviour
{
    private float attackRange, nextTime, attackInterval;
    GameObject zombieRange;
    private void InitializeAttack()
    {
        zombieRange = Resources.Load<GameObject>("Create/Zombie_Range");
        SetAttackRange(1.5f);
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
            //Debug.Log("CoolUp!");
            SetStatusOfCool(false);
        }
    }
    public void TmpFunc()
    {
        Instantiate(zombieRange, zombie.transform.position, zombie.transform.rotation);
        //Debug.Log("tmpFunc()");
        //OnTriggerEnter();
    }
    private void OnTriggerEnter()
    {
        //Debug.Log("OnTriggerEnter()");
        //decreasehealth();
    }

}
