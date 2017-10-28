using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    public GameObject bow, sward, arrow, sward_effect;

    private bool isAttacking;
    private float attackRange, curDelay, attackCoolTime;
    private int curWeapon;

    private void InitializeAttack()
    {
        SetStatusOfAttack(false);
        SetAttackRange(1.4f);
        SetCurWeaponType(1);
        SetAttackCoolTime(0.3f);
        bow.SetActive(false);
    }

    private void SetStatusOfAttack(bool status)
    {
        isAttacking = status;
    }

    private void SetAttackRange(float value)
    {
        attackRange = value;
    }

    public bool GetStatusOfAttack()
    {
        return isAttacking;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    private void AttackTargetObject()
    {
        //player.transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));

        curDelay = 0;
        if (GetCurWeaponType() == 1)
            Instantiate(sward_effect, player.transform.position, player.transform.rotation);

        else if (GetCurWeaponType() == 2)
            Instantiate(arrow, player.transform.position, player.transform.rotation);

        Debug.Log("공격!");
    }

    private int GetCurWeaponType()
    {
        return curWeapon;
    }

    private void SetCurWeaponType(int type)
    {
        curWeapon = type;
    }

    private float GetAttackCoolTime()
    {
        return attackCoolTime;
    }

    private void SetAttackCoolTime(float time)
    {
        attackCoolTime = time;
    }

    private void CheckAttackCoolTime()
    {
        curDelay += Time.deltaTime;
        if(curDelay>attackCoolTime)
        {
            SetStatusOfAttack(false);
        }
    }

    private void SwapWeapon(int type)
    {
        if(type==1)
        {
            sward.SetActive(true);
            bow.SetActive(false);
        }

        else if(type==2)
        {
            sward.SetActive(false);
            bow.SetActive(true);
        }

        SetCurWeaponType(type);
    }
}
