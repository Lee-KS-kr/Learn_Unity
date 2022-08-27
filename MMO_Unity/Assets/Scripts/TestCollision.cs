using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
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
        // Local <-> World <-> (Viewport <-> Screen) 화면
        // Debug.Log(Input.mousePosition);  // 카메라 좌표
        // Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));  // 뷰포트 좌표

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);

            int mask = (1 << 8) | (1 << 9);
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, mask))
                Debug.Log($"Raycast camera @ {hit.collider.gameObject.name}");

            // 윗줄과 정확히 같은 동작을 한다
            // Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            //     Camera.main.nearClipPlane));
            // Vector3 dir = mousePos - Camera.main.transform.position;
            // dir = dir.normalized;
            // if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            // {
            //     Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            // }
        }
    }
}
