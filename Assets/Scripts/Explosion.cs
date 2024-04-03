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

    public void Fire()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(TimeDelay);

        GameObject explosion = Instantiate(ExplosionPrefab, PositionExplosion, Quaternion.identity);
        GameObject flamme = Instantiate(Flammes, PositionExplosion, Quaternion.identity);

        Vector3 explosionPosition = PositionExplosion;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, ExplosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(ExplosionForce, explosionPosition, ExplosionRadius, UpwardsModifier);
            }

        }
        yield return new WaitForSeconds(0.5f);
        Destroy(explosion);
        Destroy(flamme);

    }
}
