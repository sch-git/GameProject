using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    public GameObject player;
    private Animator _playerAnimator;
    private bool _canClimb;
    void Start()
    {
        _playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _canClimb = true;
        if (player.TryGetComponent(out Rigidbody2D _rigidBody2d))
        {
            _rigidBody2d.gravityScale = 0;
            _rigidBody2d.velocity = new Vector2(_rigidBody2d.velocity.x, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _canClimb = false;
        if (player.TryGetComponent(out Rigidbody2D _rigidbody2D))
        {
            _rigidbody2D.gravityScale = 1;
        }
    }

    public bool CanCLimb()
    {
        return _canClimb;
    }
}
