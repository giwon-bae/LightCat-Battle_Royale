using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacter : Character
{
    public Collider2D attackCollider;
    // damage, delay

    private void Start()
    {
        attackCollider.enabled = false;

        SetAttackBehavior(new MeleeAttackBehavior(damage));
    }

    public override void HandleAttack()
    {
        // delay logic

        Debug.Log("Melee Attack");
        attackCollider.enabled = true;
        Invoke("DisableAttackCollider", 0.5f);
    }

    private void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }
}
