using Assets.Code.Enums;
using Assets.Code.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Door()
    {
        var x = 1; 
    }

    public Transform player;

    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Enum.GetName(typeof(Tags), Tags.Player))
        {
            GameSceneManager.LoadNextRandomScene();
        }
    }
}
