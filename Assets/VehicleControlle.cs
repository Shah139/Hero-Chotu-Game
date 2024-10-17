using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControlle : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool isStopped = false;

    void Update()
    {
        // Only move if not stopped
        if (!isStopped)
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    // Detect click or tap to stop vehicle
    void OnMouseDown()
    {
        isStopped = !isStopped;  // Toggle stop/start
    }
}
