using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sword : Weapon
{
    protected override void ResetStat()
    {
        attackSpeed = 1.5f;
        attackDamage = 15f;
        attackRange = 2f;
        exp = 0;
        maxExp = 0;
    }

    protected override void WeaponLevelUp()
    {
        attackSpeed += 0.3f;
        attackDamage += 4f;
    }
}
