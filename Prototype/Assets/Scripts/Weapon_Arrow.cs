using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Arrow : Weapon {
    protected override void ResetStat()
    {
        attackSpeed = 1.5f;
        attackDamage = 10f;
        attackRange = 8f;
        exp = 0;
        maxExp = 0;
    }

    protected override void WeaponLevelUp()
    {
        attackSpeed += 0.2f;
        attackDamage += 3f;
        attackRange += 0.5f;
    }
}
