using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class gfdgdfgdgd : MonoBehaviour
{
    public float raycastDistance = 10f;
    public float raycastAngle = 45f; // Bakýþ açýsý derecesi
    public int rayCount = 12; // Oluþturulacak ýþýn sayýsý
    public LayerMask obstacleLayer; // Engel olarak algýlanacak katman
    public Transform cocukNesnesi; // Takip edilecek çocuk nesnesi
    public float rotationSpeed = 25f;

    void Update()
    {
        // Düþmanýn pozisyonu baþlangýç noktasý olarak alýnýr
        Vector3 raycastOrigin = transform.position;

        // Düþmanýn bakýþ yönü alýnýr
        Vector3 forwardDirection = transform.forward;

        // Iþýnlar arasýndaki açý hesaplanýr
        float angleStep = raycastAngle / (rayCount - 1);

        // Her bir ýþýn için döngü oluþturulur
        for (int i = 0; i < rayCount; i++)
        {
            // Iþýn yönü hesaplanýr
            Quaternion rotation = Quaternion.AngleAxis(-raycastAngle / 2 + angleStep * i, transform.up);
            Vector3 direction = rotation * forwardDirection;

            // Iþýn gönderilir
            RaycastHit hit;
            bool hitObstacle = Physics.Raycast(raycastOrigin, direction, out hit, raycastDistance, obstacleLayer);
            if (hit.transform == cocukNesnesi)
            {
                // Hedefi takip et
                Vector3 targetDirection = (cocukNesnesi.position - transform.position).normalized;

                // Hedefe doðru dön
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Hedefe doðru ileri hareket et
                transform.Translate(Vector3.forward * 5f * Time.deltaTime);
            }
            // Iþýn çizgisini görmek için bu kodu kullanabilirsiniz (sadece debug amaçlý)
            Debug.DrawRay(raycastOrigin, direction * raycastDistance, hitObstacle ? Color.red : Color.green);
        }
        
    }
}
