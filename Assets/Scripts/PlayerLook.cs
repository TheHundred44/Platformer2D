using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    private float _sensibility = 12.5f;

    public ClickMouse _clickMouse;

    private bool isBlocked = false; 
    private Rigidbody2D rb;
    public float repulsionForce = 5f;

    float mapX = 100.0f;
    float mapY = 100.0f;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    [SerializeField] private Camera _camera;

    private void Start()
    {
        StartCoroutine(MousePoint());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnLook()
    {
        Vector2 direction = _playerInput.actions.FindAction("Look").ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * _sensibility;
    }

    private void FixedUpdate()
    {
        CalculCamera();
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;

        if (!isBlocked)
        {
            if (!_clickMouse._isMousePressed)
            {
                OnLook();
            }
        }
    }

    private IEnumerator MousePoint()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(0, 0, 0);
    }

    public void DesactiveMouseLocked()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CalculCamera()
    {
        float vertExtent = _camera.orthographicSize;
        Debug.Log("Cam " + _camera.orthographicSize);
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float mapXFloat = (float)mapX;
        float mapYFloat = (float)mapY;

        minX = -horzExtent  + _camera.transform.position.x;
        maxX = horzExtent  + _camera.transform.position.x;
        minY = -vertExtent  + _camera.transform.position.y;
        maxY = vertExtent + _camera.transform.position.y;
    }
}
