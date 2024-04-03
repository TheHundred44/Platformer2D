using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionRadius = 0.5f;
    public float ExplosionForce = 300f;
    public float UpwardsModifier = 2.0f;
    public float TimeDelay = 1.5f;
    public GameObject ExplosionPrefab;
    public GameObject Flammes;

    public Vector3 PositionExplosion;
    public Vector2 PositionExplosion2D;
    public float DamageExplosion = 50;

    private EnemyHp _enemyHP;

    public void Fire()
    {
        StartCoroutine(Explode());
    }

    //IEnumerator Explode()
    //{
    //    yield return new WaitForSeconds(TimeDelay);

    //    GameObject explosion = Instantiate(ExplosionPrefab, PositionExplosion, Quaternion.identity);
    //    GameObject flamme = Instantiate(Flammes, PositionExplosion, Quaternion.identity);

    //    Vector3 explosionPosition = PositionExplosion;
    //    Collider[] colliders = Physics.OverlapSphere(explosionPosition, ExplosionRadius);

    //    foreach (Collider collider in colliders)
    //    {
    //        Rigidbody rb = collider.GetComponent<Rigidbody>();

    //        if(rb != null)
    //        {
    //            rb.AddExplosionForce(ExplosionForce, explosionPosition, ExplosionRadius, UpwardsModifier);
    //            if(rb.tag == "Enemy")
    //            {
    //                _enemyHP.LowerHealth(DamageExplosion);
    //            }
    //        }

    //    }
    //    yield return new WaitForSeconds(0.5f);
    //    Destroy(explosion);
    //    Destroy(flamme);

    //}

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(TimeDelay);

        GameObject explosion = Instantiate(ExplosionPrefab, PositionExplosion, Quaternion.identity);
        GameObject flamme = Instantiate(Flammes, PositionExplosion, Quaternion.identity);

        Vector2 explosionPosition = PositionExplosion;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, ExplosionRadius);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                //rb.AddExplosionForce(ExplosionForce, explosionPosition, ExplosionRadius, UpwardsModifier);
                //rb.AddForce(explosionPosition, ForceMode2D.Impulse);
                Vector2 rbPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
                Vector2 direction = rbPosition - explosionPosition;
                float distance = direction.magnitude;
                float forceMagnitude = Mathf.Lerp(ExplosionForce, 0, distance / ExplosionRadius);
                rb.AddForce(direction.normalized * forceMagnitude, ForceMode2D.Impulse);

                if (rb.tag == "Enemy")
                {
                    _enemyHP = rb.GetComponent<EnemyHp>();
                    _enemyHP.LowerHealth(DamageExplosion);
                }
            }

        }
        yield return new WaitForSeconds(0.5f);
        Destroy(explosion);
        Destroy(flamme);

    }
}
