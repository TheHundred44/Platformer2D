using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayrHP : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private float hpMax = 3;
    [SerializeField] private float hp = 3;
    //public Slider sliderHealth;
    [SerializeField] float _fillSpeed;
    [SerializeField] private Image _healthBarFill;

    private bool _canTakeDamage = true;
    private bool _enemyHere;
    [SerializeField] private GameObject _canvaLose;
    [SerializeField] private GameObject _canvaInGame;

    [SerializeField] private int _iFrameDuration;
    [SerializeField] private int _numberOfFlash;
    private SpriteRenderer _spriteRenderer;

    public Physics2D Physics2D;
    public PlayerLook _playerLook;

    public ScoreManager ScoreManager;

    public AudioManager AudioManager;

    private void Start()
    {
        Time.timeScale = 1;

        hp = hpMax;
        //sliderHealth.maxValue = hpMax;
        //sliderHealth.value = hp;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_playerLook = GetComponent<PlayerLook>();
    }

    private void Update()
    {
        if (_enemyHere && _canTakeDamage)
        {
            AudioManager.PlaySFX(AudioManager.PlayerHit);
            float damage = -1;
            HealthManager(damage);
            ScoreManager.NbOfhit++;

            if(hp > 0)
            {
                Invincibility();
            }
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
        //sliderHealth.value = hp;
        HealthBarUpdate();

        if (hp <= 0)
        {
            _canvaLose.SetActive(true);
            _playerLook.DesactiveMouseLocked();
            Time.timeScale = 0;
            _canvaInGame.SetActive(false);
        }
    }

    private void HealthBarUpdate()
    {
        float targetFillAmount = hp / hpMax;
        _healthBarFill.DOFillAmount(targetFillAmount, _fillSpeed);
    }

    private async void Invincibility()
    {
        _canTakeDamage = false;
        Physics2D.IgnoreLayerCollision(6,7, true);
        for (int i = 0; i < _numberOfFlash; i++)
        {
            _spriteRenderer.color = new Color(1,0,0,0.5f);
            await Task.Delay(600);
            _spriteRenderer.color = Color.white;
            await Task.Delay(600);
        }
        _spriteRenderer.color = new Color(1,1,1,1f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        _canTakeDamage = true;        
    }

    public void LayerIgnore(int layer, int layer2, bool _bool)
    {
        Physics2D.IgnoreLayerCollision(layer, layer2, _bool);
    }
}
