using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlayrHP _playrHP;

    private void Awake()
    {
        _playrHP = FindAnyObjectByType<PlayrHP>().GetComponent<PlayrHP>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playrHP.LayerIgnore(7, 8, true);
            Debug.Log("oui");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playrHP.LayerIgnore(7, 8, false);
            Debug.Log("non");
        }
    }
}
