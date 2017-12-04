using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject attackResource;
    private float attackRange, nextTime, attackInterval, playerDamage;

    private void InitializeAttack()
    {
        SetAttackRange(sword.GetComponent<Weapon_Sword>().GetRange());
        SetAttackInterval(sword.GetComponent<Weapon_Sword>().GetSpeed());
        SetAttackDamage(sword.GetComponent<Weapon_Sword>().GetDamage());
    }
    public void SetAttackRange(float value)
    {
        attackRange = value;
    }
    public void SetAttackInterval(float value)
    {
        attackInterval = value;
    }
    public void SetNextTime(float value)
    {
        nextTime = value;
    }
    public void SetAttackDamage(float value)
    {
        playerDamage = value;
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
    public float GetAttackDamage()
    {
        return playerDamage;
    }
    private void ChangeStats(int curWeapon)
    {
        switch (curWeapon)
        {
            case 1:
                SetAttackRange(sword.GetComponent<Weapon_Sword>().GetRange());
                SetAttackInterval(sword.GetComponent<Weapon_Sword>().GetSpeed());
                SetAttackDamage(sword.GetComponent<Weapon_Sword>().GetDamage());
                break;
            case 2:
                SetAttackRange(bow.GetComponent<Weapon_Bow>().GetRange());
                SetAttackInterval(bow.GetComponent<Weapon_Bow>().GetSpeed());
                SetAttackDamage(bow.GetComponent<Weapon_Bow>().GetDamage());
                break;
        }
    }
    private void AttackTargetObject()
    {
        SetStatusOfAttack(true);
        player.transform.LookAt(new Vector3(targetPosition.x, player.transform.position.y, targetPosition.z));
        CoolUp();
        if (targetObject == null)
            SetStatusOfAttack(false);
    }
    
    public void CreateAttackResource()
    {
        switch (GetCurWeaponType())
        {
            case 1:
                attackResource = Instantiate(sword_range, player.transform.position, player.transform.rotation);
                break;

            case 2:
                attackResource = Instantiate(arrow, player.transform.position, player.transform.rotation);
                break;
            default:
                Debug.Log("[경고]: CurWeaponType값이 범위에서 벗어났습니다.");
                break;
        }
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
