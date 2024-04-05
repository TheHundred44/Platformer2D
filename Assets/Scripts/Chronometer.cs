using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chronometer : MonoBehaviour
{
    public float Timer;
    private int minutes;
    private int seconds;
    private int milliseconds;

    [SerializeField] TMP_Text TimerText;

    void Start()
    {
        Timer = 0f;
        minutes = 0;
        seconds = 0;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        minutes = (int)(Timer / 60);
        seconds = (int)(Timer % 60);
        milliseconds = (int)((Timer * 1000) % 1000);

        TimerText.text = "" + minutes.ToString("00") + " : " + seconds.ToString("00") + " : " + milliseconds.ToString("000");
    }
}
