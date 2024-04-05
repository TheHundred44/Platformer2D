using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float NbOfKill = 0;
    public float NbOfhit = 0;
    public float ScoreOfTime = 0;

    private float _scoreFinal;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _textKill;
    [SerializeField] private TMP_Text _textHit;
    [SerializeField] private TMP_Text _textTime;

    [SerializeField] private Chronometer _chronometer;

    [SerializeField] private GameObject _canvaIG;

    public void CalculScore()
    {
        _canvaIG.SetActive(false);
        if(_chronometer.Timer > 180)
        {
            ScoreOfTime = 0;
        }
        else
        {
            ScoreOfTime = 180 - _chronometer.Timer;
        }

        _scoreFinal = ScoreOfTime + NbOfKill - NbOfhit;

        _textHit.text = "Number of times touched : " + NbOfhit;
        _textKill.text = "Number of times touched : " + NbOfKill;
        _textTime.text = "Number of times touched : " + ScoreOfTime;

        _text.text = "Your Score : " + _scoreFinal;
    }
}
