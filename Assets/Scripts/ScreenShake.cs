using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeAmount = 0.5f;

    public bool start = false;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    //public void Shake(float duration)
    //{
    //    if (duration > 0)
    //    {
    //        for (float i = duration; i>0; i -= Time.deltaTime)
    //        {
    //            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;
    //        }
    //    }
    //    else
    //    {
    //        shakeDuration = 0f;
    //        transform.localPosition = originalPosition;
    //    }
    //}

    IEnumerator Shaking()
    {
        float elapsTime = 0f;

        while(elapsTime < shakeDuration)
        {
            elapsTime += Time.deltaTime;
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;
            yield return null;
        }
        transform.position = originalPosition;
    }
}
