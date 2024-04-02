﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickMouse : MonoBehaviour
{
    private Explosion _explosion;
    private float clickStartTime;
    private float clickEndTime;

    private bool _isMousePressed;

    public PlayerInput _playerInput;

    private void Start()
    {
        _explosion = FindAnyObjectByType<Explosion>().GetComponent<Explosion>();
        _playerInput = FindAnyObjectByType<PlayerInput>().GetComponent<PlayerInput>();
    }
    private void Update()
    {

    }



    public void OnExplode(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector3 clickPosition = Input.mousePosition;
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);

            _explosion.PositionExplosion = new Vector3(clickPosition.x, clickPosition.y, 0);
            clickStartTime = Time.time;
            _isMousePressed = true;
        }
        if (context.canceled)
        {
            clickEndTime = Time.time - clickStartTime;
            _explosion.TimeDelay = 0;
            _explosion.Fire();
            _isMousePressed = false;
        }
        if (context.performed)
        {
            clickEndTime = Time.time - clickStartTime;
            if (clickEndTime > 1)
            {
                _explosion.ExplosionForce *= clickEndTime;
            }
            else
            {
                _explosion.ExplosionForce += 1;
            }
            _explosion.ExplosionRadius += clickEndTime;
            VerifStrengh();
        }
    }

    private void VerifStrengh()
    {
        if (_explosion.ExplosionForce > 1000)
        {
            _explosion.ExplosionForce = 1000;
        }

        if (_explosion.ExplosionRadius > 3)
        {
            _explosion.ExplosionRadius = 3;
        }
    }
}
