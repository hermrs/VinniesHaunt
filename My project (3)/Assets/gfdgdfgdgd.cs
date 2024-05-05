using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class gfdgdfgdgd : MonoBehaviour
{
    public float raycastDistance = 10f;
    public float raycastAngle = 45f; // Bak�� a��s� derecesi
    public int rayCount = 12; // Olu�turulacak ���n say�s�
    public LayerMask obstacleLayer; // Engel olarak alg�lanacak katman
    public Transform cocukNesnesi; // Takip edilecek �ocuk nesnesi
    public float rotationSpeed = 25f;

    void Update()
    {
        // D��man�n pozisyonu ba�lang�� noktas� olarak al�n�r
        Vector3 raycastOrigin = transform.position;

        // D��man�n bak�� y�n� al�n�r
        Vector3 forwardDirection = transform.forward;

        // I��nlar aras�ndaki a�� hesaplan�r
        float angleStep = raycastAngle / (rayCount - 1);

        // Her bir ���n i�in d�ng� olu�turulur
        for (int i = 0; i < rayCount; i++)
        {
            // I��n y�n� hesaplan�r
            Quaternion rotation = Quaternion.AngleAxis(-raycastAngle / 2 + angleStep * i, transform.up);
            Vector3 direction = rotation * forwardDirection;

            // I��n g�nderilir
            RaycastHit hit;
            bool hitObstacle = Physics.Raycast(raycastOrigin, direction, out hit, raycastDistance, obstacleLayer);
            if (hit.transform == cocukNesnesi)
            {
                // Hedefi takip et
                Vector3 targetDirection = (cocukNesnesi.position - transform.position).normalized;

                // Hedefe do�ru d�n
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Hedefe do�ru ileri hareket et
                transform.Translate(Vector3.forward * 5f * Time.deltaTime);
            }
            // I��n �izgisini g�rmek i�in bu kodu kullanabilirsiniz (sadece debug ama�l�)
            Debug.DrawRay(raycastOrigin, direction * raycastDistance, hitObstacle ? Color.red : Color.green);
        }
        
    }
}
