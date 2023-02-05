using Assets.Code.Managers;
using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int AttackStrength = 5;
    public int AttackSpeed = 5;

    private float _attackSpeedModifer = 10f;
    private AIDestinationSetter _destinationSetter;
    private Rigidbody2D _rb;
    private Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.SetPlayer();
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _destinationSetter.target = PlayerManager.Player.transform;
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(ApplyDamage(collision));
        }
    }

    private IEnumerator<dynamic> ApplyDamage(Collider2D collision)
    {
        while (collision.IsTouching(_collider))
        {
            PlayerManager.DamagePlayer(AttackStrength);
            yield return new WaitForSeconds(AttackSpeed / 10f);
        }
    }
}
