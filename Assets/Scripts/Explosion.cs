using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionRadius = 0.5f;
    public float ExplosionForce = 300f;
    public float UpwardsModifier = 2.0f;
    public float TimeDelay = 1.5f;
    public GameObject ExplosionCharge;
    public GameObject Explosions;

    public Vector3 PositionExplosion;
    public Vector2 PositionExplosion2D;
    public float DamageExplosion = 50;

    private EnemyHp _enemyHP;
    private ClickMouse _clickMouse;

    private GameObject _explosion;
    private ScreenShake _screenShake;

    public float _explosionShake;

    private void Awake()
    {
        _clickMouse = FindAnyObjectByType<ClickMouse>().GetComponent<ClickMouse>();
        _screenShake = FindAnyObjectByType<ScreenShake>().GetComponent<ScreenShake>();
    }

    public void Fire()
    {
        StartCoroutine(Explode());
    }

    public void Charge()
    {
        _explosion = Instantiate(ExplosionCharge, PositionExplosion, Quaternion.identity);
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(TimeDelay);
        Destroy(_explosion);
        GameObject flamme = Instantiate(Explosions, PositionExplosion, Quaternion.identity);
        _screenShake.start = true;
        _screenShake.shakeAmount = _explosionShake;

        Vector2 explosionPosition = PositionExplosion;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, ExplosionRadius);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 rbPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
                Vector2 direction = rbPosition - explosionPosition;
                float distance = direction.magnitude;
                float forceMagnitude = Mathf.Lerp(ExplosionForce, 0, distance / ExplosionRadius);
                Debug.Log(forceMagnitude);
                Debug.Log(forceMagnitude * direction.magnitude);
                Debug.Log(rb.gameObject.name);

                rb.AddForce(direction.normalized * forceMagnitude, ForceMode2D.Impulse);

                if (rb.tag == "Enemy")
                {
                    _enemyHP = rb.GetComponent<EnemyHp>();
                    _enemyHP.LowerHealth(DamageExplosion);
                }
            }

        }
        yield return new WaitForSeconds(0.5f);
        Destroy(flamme);
    }
}
