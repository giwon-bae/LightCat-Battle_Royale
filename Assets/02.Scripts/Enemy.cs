using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // status
    // hp, damage, armor, expPoints, ...
    public int hp = 50;
    private int _damage;
    private int _armor;
    private int _expPoints;

    public float detectingRange = 10f;
    public float attackRange = 3f;
    public float moveSpeed = 2f;

    public float attackDelay = 3f;
    public float curDelay = 0f;

    protected Character _targetCharacter;
    protected bool _isTracking = false;
    protected bool _isInAttackRange = false;

    // action
    // move - findTarget, Move
    // aggressive -> findTarget, Move
    // passive -> onAttacked, Move

    public virtual void Update()
    {
        if (curDelay > 0) curDelay -= Time.deltaTime;


        if (_targetCharacter == null) return;

        float distanceToCharacter = Vector2.Distance(transform.position, _targetCharacter.transform.position);

        if (distanceToCharacter <= detectingRange)
        {
            if (distanceToCharacter > attackRange)
            {
                Move();
            }
            else
            {
                Attack();
            }
        }
    }


    // findTarget
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Character character = collision.GetComponent<Character>();
        if (character == null) return;

        _targetCharacter = character;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Character character = collision.GetComponent<Character>();
        if (_targetCharacter == character)
        {
            _targetCharacter = null;
        }
    }

    // move
    private void Move()
    {
        if (_targetCharacter == null) return;

        transform.position = Vector3.MoveTowards(transform.position, _targetCharacter.transform.position, moveSpeed * Time.deltaTime);
    }

    // attack
    public abstract void Attack();

    // take damage
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("curHp : " + hp);

        if (hp <= 0)
        {
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }
}
