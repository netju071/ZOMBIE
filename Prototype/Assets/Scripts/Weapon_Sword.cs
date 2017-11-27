using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sword : Weapon
{
    protected override void ResetStat()
    {
        attackSpeed = 1f;
        attackDamage = 15f;
        attackRange = 2f;
        exp = 0;
        maxExp = 10;
    }

    protected override void WeaponLevelUp()
    {
        attackSpeed -= attackSpeed / 5;
        attackDamage += 4f;
    }
}
