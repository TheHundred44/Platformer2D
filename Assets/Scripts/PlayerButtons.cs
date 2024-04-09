using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerButtons : MonoBehaviour
{
    public PlayerInput _playerInput;

    [SerializeField] private GameObject _canvaOptions;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnOptions()
    {
        if (_canvaOptions.activeSelf)
        {
            _canvaOptions.SetActive(true);
        }
        else
        {
            _canvaOptions.SetActive(false);
        }
    }
}
