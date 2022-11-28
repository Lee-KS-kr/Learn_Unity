using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CameraShake _camera;
    
    [SerializeField] private int _attackCount = 0;
    private const int _bulletCount = 7;
    [SerializeField] private float _moveSpeed = -1f;

    private readonly int hashMoveSpeed = Animator.StringToHash("moveSpeed");
    private readonly int hashIsBulletEmpty = Animator.StringToHash("isBulletEmpty");
    private readonly int hashOnAttack = Animator.StringToHash("onAttack");

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            int mask = 1 << 3;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                _moveSpeed = Mathf.Clamp(_moveSpeed + (1 / 30f), 0f, 1f);
                transform.LookAt(hitInfo.point);
                transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _moveSpeed);
                _animator.SetFloat(hashMoveSpeed, _moveSpeed);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _moveSpeed = -1;
            _animator.SetFloat(hashMoveSpeed, _moveSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_bulletCount == _attackCount)
            {
                _animator.SetBool(hashIsBulletEmpty, true);
                _animator.SetTrigger(hashOnAttack);

                _attackCount = 0;
            }
            else
            {
                _attackCount++;
                _animator.SetTrigger(hashOnAttack);
                _camera.Shake();
            }
        }
    }
}
