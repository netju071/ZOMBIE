﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    public float attackSpeed, 
        attackDamage, 
        attackRange, 
        exp, maxExp;

	void Start () {
        ResetStat();
	}
	
    protected abstract void ResetStat();

	public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public float GetAttackDamage()
    {
        return attackDamage;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    protected abstract void WeaponLevelUp();

    public void IncreaseExp(float earned)
    {
        Debug.Log("호출!");
        exp += earned;
        if(exp>=maxExp)
        {
            WeaponLevelUp();
            maxExp += 10f;
            exp = 0;
        }
    }
}
