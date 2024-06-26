﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    private float _speed = 10f;

    private Animator _animator;

    private Vector2 _horizontalMove;

    private SpriteRenderer _spriteRenderer;
    private PlayerJump _playerJump;

    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _horizontalMove = transform.position;
        _playerJump = GetComponent<PlayerJump>();
    }

    // Méthode pour que le joueur puisse bouger
    private void OnMove()
    {
        _horizontalMove = _input.actions.FindAction("Move").ReadValue<Vector2>();
        transform.position += new Vector3(_horizontalMove.x, 0, 0) * Time.deltaTime * _speed;
        if(!_playerJump._isJumping)
        {
            PlayDust();
        }
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalMove.x));
        if (_horizontalMove.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        // La méthode OnMove() est mis dans un FixedUpdate pour que les movements du joueurs soient fluides
        OnMove();
    }

    private void PlayDust()
    {
        _particleSystem.Play();
    }
}
