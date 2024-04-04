using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeAmount = 0.5f;

    public bool start = false;

    private Vector3 originalPosition;

    [SerializeField] PlayerMovement _playerMovement;

    void Start()
    {
        originalPosition = new Vector3(_playerMovement.transform.localPosition.x, _playerMovement.transform.localPosition.y, -10);
    }

    private void Update()
    {
        if (start)
        {
            originalPosition = new Vector3(_playerMovement.transform.localPosition.x, _playerMovement.transform.localPosition.y, -10);
            start = false;
            StartCoroutine(Shaking());
        }
    }

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
