using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public BoxCollider2D _boxCollider2D;

    private PlayerInput _playerInput;

    private bool _isJumping;

    [SerializeField]
    private float _jumpforce = 10f;

    private Animator _animator;

    private void Start()
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
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpforce);
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
}
