using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    private float _yAngle = 0;

    private Vector3 _destPos;

    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState
    {
        Idle,
        Moving,
        Die,
    }

    void UpdateIdle()
    {
        Animator anime = GetComponent<Animator>();
        anime.SetFloat($"speed", 0);
    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.01f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.rotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            transform.position += dir.normalized * moveDist;
        }

        Animator anime = GetComponent<Animator>();
        anime.SetFloat($"speed", _speed);
    }

    void UpdateDie()
    {

    }

    private PlayerState _state = PlayerState.Idle;
    void Update()
    {
        switch (_state)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
        }
        
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

    // private void OnKeyboard()
    // {
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.forward);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.5f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //     }
    //
    //     if (Input.GetKey(KeyCode.S))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.back);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.5f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //     }
    //
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.left);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //     }
    //
    //     if (Input.GetKey(KeyCode.D))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.right);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //     }
    //
    //     _moveToDest = false;
    // }

    private void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die) return;
        // Debug.Log($"OnMouseClicked!");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.yellow, 1.0f);
        RaycastHit hit;
        int mask = 1 << 9;

        if (Physics.Raycast(ray, out hit, 100f, mask)) 
        {
            // Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }
}
