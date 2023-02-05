using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    private InputAction _damage;
    public int curHealth = 0;
    public int maxHealth = 100;

    public HealthBar healthBar;

    void Start()
    {
        _damage = new InputAction("Jump");
        curHealth = maxHealth;
    }

    void Update()
    {
        if (_damage.triggered)
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.Set(curHealth);
    }
}