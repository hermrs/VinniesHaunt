using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    StaminaControl stamina;
    AudioManager audios;
    public Transform kamera;
    public float walkSpeed = 50f;
    public float runSpeedMultiplier = 1.5f;
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stamina = GetComponent<StaminaControl>();
        audios = GetComponent<AudioManager>();
    }

    void Update()
    {
        moved();
        if (!stamina.isRunning && !stamina.isCooldown)
        {
            audios.AudioStop(KeyCode.Q);
            audios.AudioStart(KeyCode.Q);
        }
    }
    void moved()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 kameraYonu = kamera.forward;
        kameraYonu.y = 0f;
        Vector3 hareketYonu = (horizontalInput * kamera.right + verticalInput * kameraYonu).normalized;
        rb.velocity = hareketYonu * walkSpeed;

    }
}
