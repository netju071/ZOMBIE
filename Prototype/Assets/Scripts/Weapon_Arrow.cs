using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Arrow : Weapon {
    protected override void ResetStat()
    {
        attackSpeed = 1f;
        attackDamage = 10f;
        attackRange = 8f;
        exp = 0;
        maxExp = 10f;
    }

    protected override void WeaponLevelUp()
    {
        attackSpeed -= attackSpeed / 5;
        attackDamage += 3f;
        attackRange += 0.5f;
    }
}
