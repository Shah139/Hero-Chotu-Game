using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3f;
    private bool isStopped = false;

    void Update()
    {
        // Only move if not stopped
        if (!isStopped)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    // Detect click or tap to stop vehicle
    void OnMouseDown()
    {
        isStopped = !isStopped;  // Toggle stop/start
    }
}
