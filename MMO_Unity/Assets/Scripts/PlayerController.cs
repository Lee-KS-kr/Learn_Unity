using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    private float _yAngle = 0;
    
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }

    void Update()
    {
        //_yAngle += Time.deltaTime * 180f;
        //transform.rotation = Quaternion.Euler(0f, _yAngle, 0f);
        // local -> world
        // transform.TransformDirection
        // transform.eulerAngles = new Vector3(0f, _yAngle, 0f);
        //transform.Rotate(new Vector3(0f, Time.deltaTime * 180f, 0f));
        // if (Input.GetKey(KeyCode.W))
        //     transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        // if (Input.GetKey(KeyCode.S))
        //     transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);
        // if (Input.GetKey(KeyCode.A))
        //     transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        // if (Input.GetKey(KeyCode.D))
        //     transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
    }

    private void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.5f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.5f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }
    }
}
