using System.Collections;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float _hp = 500;

    [SerializeField]
    private Color _damageColor;

    [SerializeField]
    private Collider2D _damageCollider;

    [SerializeField]
    private ParticleSystem _prefabExplosion;

    [SerializeField]
    private ParticleSystem _prefabSmoke;

    private EnnemyPatrol _enemyPatrol;

    private void Start()
    {
        _enemyPatrol = GetComponent<EnnemyPatrol>();
    }

    public virtual void LowerHealth(float damage)
    {
        if (_hp > 0)
        {
            _hp -= damage;
        }

        if (_hp <= 0)
        {
            StartCoroutine(AnimationDeath());
        }
    }

    private IEnumerator AnimationDeath()
    {
        _prefabExplosion.Play();
        _prefabSmoke.Play();
        _damageCollider.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }   
}
