using UnityEngine;

public class Takip : MonoBehaviour
{
    PoohAI poohAI = new PoohAI();
    public Transform target; // Takip edilecek hedef
    public float beamDistance = 10f; // Iþýnýn menzili
    public float rotationSpeed = 5f; // Dönüþ hýzý
    public float speed = 5f; // Takip hýzý
    public int rayCount = 12; // Oluþturulacak ýþýn sayýsý
    public float raycastAnglemin = 0;
    public float raycastAnglemax = 0;
    // Bakýþ açýsý derecesi

    void Update()
    {
        // Düþmanýn bakýþ açýsýný hesapla
        float raycastAngle = Random.Range(raycastAnglemin, raycastAnglemax);
        float angleStep = raycastAngle / rayCount;
        float currentAngle = 0f;
        
        for (int i = 0; i < rayCount; i++)
        {
            // Iþýn yönünü hesapla
            Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * transform.forward;

            RaycastHit hit;

            // Iþýn gönder
            if (Physics.Raycast(transform.position, direction, out hit, beamDistance))
            {
                // Iþýn bir nesneye çarptýysa ve bu nesne takip edilecek hedefse
                if (hit.transform == target)
                {
                    // Hedefi takip et
                    Vector3 targetDirection = (target.position - transform.position).normalized;

                    // Hedefe doðru dön
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                    // Hedefe doðru ileri hareket et
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    poohAI.SetRandomDestination();

                }
               
            }

            // Iþýný göster
            Debug.DrawRay(transform.position, direction * beamDistance, Color.red);

            // Sonraki açýya geç
            currentAngle += angleStep;
        }
    }
}
