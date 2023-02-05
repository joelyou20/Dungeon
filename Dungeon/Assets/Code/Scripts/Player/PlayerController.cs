using Assets.Code.Enums;
using Assets.Code.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed = 5;
    public const int MaxHealth = 100;
    [Range(0, MaxHealth)] public int Health = MaxHealth;
    public HealthBar HealthBar;

    [Header("Damage")]
    public float flashDuration = 0.5f;
    public int flashRepeat = 3;
    public Color flashColor = Color.white;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    private InputAction _jumpAction;
    private Vector2 _moveDirection;

    private const int _minHealth = 0;

    // Start is called before the first frame update
    public void Start()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        _jumpAction = _playerInput.actions["jump"];
        HealthBar.Set(MaxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void OnMove()
    {
        _moveDirection = _playerInput.actions["move"].ReadValue<Vector2>();
        _rb.velocity = new Vector2(_moveDirection.x * Speed, _moveDirection.y * Speed);
    }

    public void OnJump()
    {
        SetHealth(Health - 10);
        StartCoroutine(Flash());
    }

    public void SetHealth(int health)
    {
        if (health < Health) StartCoroutine(Flash());
        Health = health;

        if (Health == _minHealth) Die();
        HealthBar.Set(health);
    }

    private void Die()
    {
        GameSceneManager.LoadScene(SceneNames.GameOver);
    }

    private IEnumerator Flash()
    {
        for (int i = 0; i < flashRepeat; i++)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
