using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    private float _sensibility = 5f;

    public ClickMouse _clickMouse;

    private void Start()
    {
        StartCoroutine(MousePoint());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnLook()
    {
        Vector2 direction = _playerInput.actions.FindAction("Look").ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * _sensibility;
    }

    private void FixedUpdate()
    {
        if (!_clickMouse._isMousePressed)
        {
            OnLook();
        }
    }

    private IEnumerator MousePoint()
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(0, 0, 0);
    }
}
