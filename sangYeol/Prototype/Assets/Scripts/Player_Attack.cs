using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private bool isAttacking;
    private float attackRange;

    private void InitializeAttack()
    {
        SetStatusOfAttack(false);
        SetAttackRange(1.4f);
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
        SetStatusOfAttack(true);
        player.transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
        Debug.Log("공격!");
    }
}
