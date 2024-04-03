using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayrHP : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private float hpMax = 3;
    [SerializeField] private float hp = 3;
    public Slider sliderHealth;

    private bool _canTakeDamage = true;
    private bool _enemyHere;

    private void Start()
    {
        hp = hpMax;
        sliderHealth.maxValue = hpMax;
        sliderHealth.value = hp;
    }

    private void Update()
    {
        if (_enemyHere && _canTakeDamage)
        {
            float damage = -1;
            HealthManager(damage);
            Invincibility();
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemyHere = true;         
        }

        if (other.gameObject.tag == "Health")
        {
            if (hp < 3)
            {
                float health = 1;
                Destroy(other.gameObject);
                HealthManager(health);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _enemyHere = false;
        }
    }

    private void HealthManager(float health)
    {
        hp += health;
        sliderHealth.value = hp;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private async void Invincibility()
    {
        _canTakeDamage = false;
        await Task.Delay(1500);
        _canTakeDamage = true;
    }

    
}
