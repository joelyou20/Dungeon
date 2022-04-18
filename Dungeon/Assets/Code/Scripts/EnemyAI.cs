using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float WalkSpeed = 2.0f;
    public float WallLeft = 0.0f;
    public float WallRight = 5.0f;
    private float _walkingDirection = 1.0f;
    Vector3 walkAmount;
    // Update is called once per frame
    void Update()
    {
        walkAmount.x = _walkingDirection * WalkSpeed * Time.deltaTime;
        if (_walkingDirection > 0.0f && transform.position.x >= WallRight)
        {
            _walkingDirection = -1.0f;

        }
        else if (_walkingDirection < 0.0f && transform.position.x <= WallLeft)
        {
            _walkingDirection = 1.0f;
        }

        transform.Translate(walkAmount);
    }
}
