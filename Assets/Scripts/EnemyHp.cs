using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyHp : MonoBehaviour
{
    public float _hp = 500;

    [SerializeField]
    private Color _damageColor;

    public virtual void LowerHealth(float damage)
    {
        if (_hp > 0)
        {
            _hp -= damage;
        }

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    //other.gameObject.SendMessage("LowerHealth", damage, SendMessageOptions.DontRequireReceiver);
}
