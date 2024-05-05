using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 kameraYonu = cam.forward;
        kameraYonu.y = 0f; 
        Vector3 hareketYonu = (x * cam.right + z * kameraYonu).normalized;
        rb.velocity = hareketYonu * speed;

        if (hareketYonu != Vector3.zero)
        {
            Quaternion hedefRotasyon = Quaternion.LookRotation(hareketYonu, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefRotasyon, 0.1f);
        }
    }
}
