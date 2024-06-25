using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    StaminaControl stamina;
    AudioManager audios;
    public Transform kamera;
    public float walkSpeed = 2f; // Y�r�me h�z�
    public float runSpeedMultiplier = 1.5f; // Ko�ma h�z�n�n �arpan�
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
        // Yatay ve dikey giri�leri al
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Kamera y�n�n� al
        Vector3 kameraYonu = kamera.forward;
        kameraYonu.y = 0f;

        // Hareket y�n�n� hesapla
        Vector3 hareketYonu = (horizontalInput * kamera.right + verticalInput * kameraYonu).normalized;

        // Hareket y�n�n� ve h�z� belirle
        Vector3 moveDirection = hareketYonu * walkSpeed;

        // Hareket y�n�n� NavMeshAgent'e ayarla
        agent.Move(moveDirection * Time.deltaTime);
    }
}