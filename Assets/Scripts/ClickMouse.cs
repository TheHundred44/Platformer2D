﻿using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickMouse : MonoBehaviour
{
    public Explosion _explosion;
    private float clickStartTime;
    private float clickEndTime;

    [HideInInspector]
    public bool _isMousePressed;

    public PlayerInput _playerInput;

    [SerializeField]
    private GameObject _target;

    private void Start()
    {
        _explosion = FindAnyObjectByType<Explosion>().GetComponent<Explosion>();
        _playerInput = FindAnyObjectByType<PlayerInput>().GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_isMousePressed)
        {
            clickEndTime = Time.time - clickStartTime;
            if (clickEndTime > 1)
            {
                _explosion.ExplosionForce *= clickEndTime;
                _explosion.DamageExplosion *= clickEndTime;
            }
            else
            {
                _explosion.ExplosionForce += 0.01f;
                _explosion.DamageExplosion += 1;
            }
            _explosion.ExplosionRadius += 0.0050f;
            _explosion._explosionShake += 0.0033f;
            VerifStrengh();
        }
    }

    public async void OnExplode(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            _explosion.ExplosionForce = 5;
            _explosion.ExplosionRadius = 0.5f;
            _explosion.DamageExplosion = 50;
            _explosion._explosionShake = 0.1f;

            //Vector3 clickPosition = Input.mousePosition;
            //clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);

            //_explosion.PositionExplosion = new Vector3(clickPosition.x, clickPosition.y, 0);

            _explosion.PositionExplosion = new Vector3(_target.transform.position.x, _target.transform.position.y, 0);
            clickStartTime = Time.time;
            _isMousePressed = true;
            _explosion.Charge();

        }

        if (context.canceled)
        {
            clickEndTime = Time.time - clickStartTime;
            _explosion.TimeDelay = 0;
            _explosion.Fire();
            _isMousePressed = false;
            await Task.Delay(500);
            _target.transform.position = transform.position;
        }
    }

    private void VerifStrengh()
    {
        if (_explosion.ExplosionForce > 50)
        {
            _explosion.ExplosionForce = 50;
        }
        if (_explosion.ExplosionRadius > 3)
        {
            _explosion.ExplosionRadius = 3;
        }
        if (_explosion.DamageExplosion > 500)
        {
            _explosion.DamageExplosion = 500;
        }
        if(_explosion._explosionShake > 1f)
        {
            _explosion._explosionShake = 1f;
        }
    }
}
