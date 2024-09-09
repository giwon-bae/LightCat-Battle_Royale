using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // ... character status
    public int damage = 10;
    private float _moveSpeed = 10f;

    private int _level = 1;
    private int _curExp = 0;
    private int _maxExp = 100;

    protected IAttackBehavior _attackBehavior;

    public void SetAttackBehavior(IAttackBehavior attackBehavior)
    {
        _attackBehavior = attackBehavior;
    }

    public void PerformAttack(GameObject target)
    {
        _attackBehavior.Attack(target);
    }

    // Move()
    // GainEx()
    // OnLevelUp()
    // Attack()
    // ...
    public void HandleMovement(Vector2 movement)
    {
        transform.Translate(movement * _moveSpeed * Time.deltaTime);
    }

    public abstract void HandleAttack();
}
