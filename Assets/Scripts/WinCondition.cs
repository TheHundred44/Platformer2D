using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject CanvaWin;
    public PlayerLook PlayerLook;
    public ScreenShake ScreenShake;

    public ScoreManager ScoreManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0f;
            CanvaWin.SetActive(true);
            PlayerLook.DesactiveMouseLocked();
            ScreenShake.gameObject.SetActive(false);
            ScoreManager.CalculScore();
        }
    }
}
