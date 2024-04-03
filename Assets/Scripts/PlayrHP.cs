using UnityEngine;
using UnityEngine.UI;

public class PlayrHP : MonoBehaviour
{
    private int score = 0;

    private int hp = 3;

    [SerializeField] private Image SpriteHealBar0;
    [SerializeField] private Image SpriteHealBar1;
    [SerializeField] private Image SpriteHealBar2;
    [SerializeField] private Image SpriteHealBar3;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hp--;
            OnLosingHealth();
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Heal")
        {
            if (hp < 3)
            {
                hp++;
                Destroy(other.gameObject);
                OnRegainingHealth();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnLosingHealth()
    {
        switch (hp)
        {
            case 2:
                SpriteHealBar3.gameObject.SetActive(false);
                break;
            case 1:
                SpriteHealBar2.gameObject.SetActive(false);
                break;
            case 0:
                SpriteHealBar1.gameObject.SetActive(false);
                break;
        }
    }

    private void OnRegainingHealth()
    {
        switch (hp)
        {
            case 3:
                SpriteHealBar3.gameObject.SetActive(true);
                break;
            case 2:
                SpriteHealBar2.gameObject.SetActive(true);
                break;
        }
    }
}
