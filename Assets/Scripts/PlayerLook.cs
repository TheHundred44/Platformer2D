using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    private float _sensibility = 12.5f;

    public ClickMouse _clickMouse;

    private bool isBlocked = false; // Indique si le curseur est bloqué
    private Rigidbody2D rb; // Référence au composant Rigidbody2D
    public float repulsionForce = 5f; // Force de repoussement

    private void Start()
    {
        StartCoroutine(MousePoint());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb = GetComponent<Rigidbody2D>(); // Récupérer le composant Rigidbody2D

    }

    private void OnLook()
    {
        Vector2 direction = _playerInput.actions.FindAction("Look").ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * _sensibility;
    }

    private void FixedUpdate()
    {

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collision"))
        {
            // Le curseur est entré en collision avec la zone bloquante
            isBlocked = true;
            Debug.Log(isBlocked);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collision"))
        {
            // Le curseur reste en collision avec la zone bloquante
            // Empêcher le curseur de pénétrer dans la zone

            // Calculer la direction de repoussement (de la zone vers le curseur)
            Vector2 pushDirection = ((Vector2)transform.position - (Vector2)other.transform.position).normalized;

            // Calculer la distance entre le curseur et la bordure de la zone
            float distanceToEdge = other.bounds.extents.magnitude + GetComponent<Collider2D>().bounds.extents.magnitude;

            // Déplacer le curseur vers l'extérieur de la zone
            transform.position = (Vector2)other.transform.position + pushDirection * distanceToEdge;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collision"))
        {
            // Le curseur a quitté la zone bloquante
            isBlocked = false;
            Debug.Log(isBlocked);
        }
    }
}
