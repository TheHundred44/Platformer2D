using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chronometer : MonoBehaviour
{
    private float timer;
    private int minutes;
    private int seconds;
    private int milliseconds;

    [SerializeField] TMP_Text TimerText;

    void Start()
    {
        timer = 0f;
        minutes = 0;
        seconds = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        minutes = (int)(timer / 60);
        seconds = (int)(timer % 60);
        milliseconds = (int)((timer * 1000) % 1000);

        TimerText.text = "" + minutes.ToString("00") + " : " + seconds.ToString("00") + " : " + milliseconds.ToString("000");
    }
}
