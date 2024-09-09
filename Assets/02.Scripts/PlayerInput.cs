using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Character curCharacter;

    private Vector2 _movementInput;
    private bool _attackInput;

    private void Update()
    {
        HandleInput();
    }

    public void SetCharacter(Character character)
    {
        curCharacter = character;
    }

    private void HandleInput()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _attackInput = Input.GetButtonDown("Fire1");

        if (curCharacter != null)
        {
            curCharacter.HandleMovement(_movementInput);
            if (_attackInput) curCharacter.HandleAttack();
        }
    }
}
