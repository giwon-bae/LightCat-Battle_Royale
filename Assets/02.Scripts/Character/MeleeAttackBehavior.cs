using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBehavior : IAttackBehavior
{
    private int _attackDamage;

    public MeleeAttackBehavior(int damage)
    {
        _attackDamage = damage;
    }

    public void Attack(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy == null) return;

        enemy.TakeDamage(_attackDamage);
    }
}
