﻿using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public BoxCollider2D _boxCollider2D;

    private PlayerInput _playerInput;

    public bool _isJumping;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField]
    private float _jumpforce = 10f;

    private Animator _animator;

    [SerializeField]
    private AudioManager _audioManager;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    public void OnJump()
    {
        if (!_isJumping)
        {
            _animator.SetBool("IsJumping", true);
            _isJumping = true;
            _audioManager.PlaySFX(_audioManager.JumpSound);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpforce);          
            PlayPArticleSystem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sol")
        {
            _isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sol")
        {
            _isJumping = true;
            _animator.SetBool("IsJumping", false);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);  
    }

    private void PlayPArticleSystem()
    {
        _particleSystem.Play();
    }
}
