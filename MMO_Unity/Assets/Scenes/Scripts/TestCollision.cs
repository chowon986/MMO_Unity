using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Collision 발동 조건
    // 나한테 RigidBody가 있어야 함 (IsKinematic : Off)
    // 나한테 Collider가 있어야 함 (IsTrigger : Off)
    // 상대한테 Collider가 있어야 함 (isTrigger : Off)

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name} !");
    }

    // Trigger 발동 조건
    //
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name} !");
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(Input.mousePosition); // Screen
        Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport
    }
}
