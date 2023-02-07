using Assets.Code.Enums;
using Assets.Code.Managers;
using Assets.Code.Scripts.Combat;
using Assets.Code.Scripts.Combat.Contracts;
using Assets.Code.Services;
using Assets.Code.Services.Contracts;
using Assets.Code.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerStats Stats { get; set; }

    [Header("Attributes")]
    public float Speed = 5;
    public const int MaxHealth = 100;
    public HealthBar HealthBar;
    public int AttackSpeed = 3;

    [Header("Damage")]
    public float flashDuration = 0.5f;
    public int flashRepeat = 3;
    public Color flashColor = Color.white;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private IDamageEffectService _damageEffectService;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    private InputAction _jumpAction;
    private Vector2 _moveDirection;
    private const int _minHealth = 0;
    private bool _isAttacking = false;

    // Combat
    private IAttack _leftMouseAttack;

    // Start is called before the first frame update
    public void Start()
    {
        if (!PlayerStats.IsInitialized) PlayerManager.InitializePlayer(MaxHealth, Speed, AttackSpeed);

        HealthBar.Set(PlayerStats.Health.Value);

        _damageEffectService = new DamageEffectService();
        _playerInput = FindObjectOfType<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        _jumpAction = _playerInput.actions[nameof(Actions.Jump)];
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        SetLeftMouseAttack(gameObject.AddComponent<AreaOfEffectAttack>());
    }

    public void OnMove()
    {
        _moveDirection = _playerInput.actions[nameof(Actions.Move)].ReadValue<Vector2>();
        _rb.velocity = new Vector2(_moveDirection.x * Speed, _moveDirection.y * Speed);
    }

    public void OnJump()
    {
        SetHealth(PlayerStats.Health.Value - 10);
        StartCoroutine(_damageEffectService.Flash(_spriteRenderer, flashRepeat, flashDuration, flashColor, _originalColor));
    }

    public void OnAttack()
    {
        if(!_isAttacking)
        {
            StartCoroutine(InvokeAttack());
        }
        else
        {
            Debug.Log("On Cooldown...");
        }
    }

    private IEnumerator InvokeAttack()
    {
        _isAttacking = true;
        Debug.Log("Attack");
        _leftMouseAttack.Invoke();
        yield return new WaitForSeconds(AttackSpeed);
        _isAttacking = false;
    }

    public void SetHealth(int health)
    {
        if (health < PlayerStats.Health) StartCoroutine(_damageEffectService.Flash(_spriteRenderer, flashRepeat, flashDuration, flashColor, _originalColor));
        PlayerStats.Health = health;

        if (PlayerManager.IsDead) Die();
        HealthBar.Set(health);
    }

    public void SetLeftMouseAttack(IAttack attack)
    {
        _leftMouseAttack = attack;
    }

    private void Die()
    {
        GameSceneManager.LoadScene(SceneNames.GameOver);
    }
}
