using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Collision �ߵ� ����
    // ������ RigidBody�� �־�� �� (IsKinematic : Off)
    // ������ Collider�� �־�� �� (IsTrigger : Off)
    // ������� Collider�� �־�� �� (isTrigger : Off)

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name} !");
    }

    // Trigger �ߵ� ����
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
