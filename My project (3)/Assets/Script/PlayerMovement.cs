using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    StaminaControl stamina;
    AudioManager audios;
    public Transform kamera;
    public float walkSpeed = 2f; // Yürüme hýzý
    public float runSpeedMultiplier = 1.5f; // Koþma hýzýnýn çarpaný
    NavMeshAgent agent;

    void Start()
    {
        stamina = GetComponent<StaminaControl>();
        audios = GetComponent<AudioManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!stamina.isRunning && !stamina.isCooldown)
        {
            audios.AudioStop(KeyCode.Q);
            audios.AudioStart(KeyCode.Q);
        }

        Move();
    }

    void Move()
    {
        // Yatay ve dikey giriþleri al
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Kamera yönünü al
        Vector3 kameraYonu = kamera.forward;
        kameraYonu.y = 0f;

        // Hareket yönünü hesapla
        Vector3 hareketYonu = (horizontalInput * kamera.right + verticalInput * kameraYonu).normalized;

        // Hareket yönünü ve hýzý belirle
        Vector3 moveDirection = hareketYonu * walkSpeed;

        // Hareket yönünü NavMeshAgent'e ayarla
        agent.Move(moveDirection * Time.deltaTime);
    }
}