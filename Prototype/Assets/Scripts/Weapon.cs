using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected float attackSpeed;
    protected float attackDamage;
    protected float attackRange;
    protected float exp, maxExp;

    void Start()
    {
        ResetStat();
    }

    protected abstract void ResetStat();

    public void SetSpeed(float value)
    {
        attackSpeed = value;
    }

    public void SetDamage(float value)
    {
        attackDamage = value;
    }

    public void SetRange(float value)
    {
        attackRange = value;
    }

    public float GetSpeed()
    {
        return attackSpeed;
    }

    public float GetDamage()
    {
        return attackDamage;
    }

    public float GetRange()
    {
        return attackRange;
    }

    protected abstract void WeaponLevelUp();

    public void IncreaseExp(float earned)
    {
        exp += earned;
        if(exp>=maxExp)
        {
            WeaponLevelUp();
            maxExp += 10f;
            exp = 0;
        }
    }
}
