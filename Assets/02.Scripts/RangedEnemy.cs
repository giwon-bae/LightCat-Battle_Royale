using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public override void Attack()
    {
        if (curDelay > 0) return;

        Debug.Log("Enemy - Ranged Attack");
        curDelay = attackDelay;
    }
}
