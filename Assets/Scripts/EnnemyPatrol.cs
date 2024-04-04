using TMPro;
using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            _spriteRenderer.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            _spriteRenderer.flipX = true;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint.position.x >= pointB.transform.position.x)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint.position.x <= pointA.transform.position.x)
        {
            currentPoint = pointB.transform;
        }
    }
}
