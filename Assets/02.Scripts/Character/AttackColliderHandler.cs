using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderHandler : MonoBehaviour
{
    Character character;

    private void Start()
    {
        character = GetComponentInParent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        if (character == null) return;

        character.PerformAttack(collision.gameObject);
    }
}
