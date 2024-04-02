using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private BoxCollider2D _boxCollider2D;

    private PlayerInput _playerInput;

    private bool _isJumping;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnJump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 10f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sol")
        {
            _isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sol")
        {
            _isJumping = true;
        }
    }
}
