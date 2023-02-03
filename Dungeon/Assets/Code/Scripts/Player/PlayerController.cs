using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;

    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    private InputAction _jumpAction;
    private Vector2 _moveDirection;

    // Start is called before the first frame update
    public void Start()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _rb = FindObjectOfType<Rigidbody2D>();
        _jumpAction = _playerInput.actions["jump"];
    }

    // Update is called once per frame
    public void Update()
    {
        _moveDirection = _playerInput.actions["move"].ReadValue<Vector2>();

        if (_jumpAction.triggered)
        {
            Debug.Log("Jumped");
        }
    }

    public void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveDirection.x * Speed, _moveDirection.y * Speed);
    }
}
