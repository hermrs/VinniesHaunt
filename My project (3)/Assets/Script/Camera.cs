using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // Fare hareketini al
        float horizontalInput = Input.GetAxis("Mouse X");

        // Kedi modelini yatayda döndür
        transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
    }
}
