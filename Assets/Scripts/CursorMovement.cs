using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    public ClickMouse ClickMouse;

    private PlayerLook _playerLook;

    [SerializeField]
    private GameObject _gameObject;

    private void Start()
    {
        _playerLook = GetComponent<PlayerLook>();
    }

    private void FixedUpdate()
    {
        if (ClickMouse._isMousePressed)
        {
            _playerLook.enabled = false;
        }
        else
        {
            _playerLook.enabled = true;
        }
    }
}
