using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision! : {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger! {other.gameObject.name}");
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 10, Color.red);
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, 10f))
            Debug.Log($"Raycast!");
    }
}
