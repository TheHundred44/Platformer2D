using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    private float _speed = 5f;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    // Méthode pour que le joueur puisse bouger
    private void OnMove()
    {
        Vector2 direction = _input.actions.FindAction("Move").ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, 0) * Time.deltaTime * _speed;
    }

    private void FixedUpdate()
    {
        // La méthode OnMove() est mis dans un FixedUpdate pour que les movements du joueurs soient fluides
        OnMove();
    }
}
