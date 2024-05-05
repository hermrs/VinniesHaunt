using UnityEngine;

public class Takip : MonoBehaviour
{
    PoohAI poohAI = new PoohAI();
    public Transform target; // Takip edilecek hedef
    public float beamDistance = 10f; // I��n�n menzili
    public float rotationSpeed = 5f; // D�n�� h�z�
    public float speed = 5f; // Takip h�z�
    public int rayCount = 12; // Olu�turulacak ���n say�s�
    public float raycastAnglemin = 0;
    public float raycastAnglemax = 0;
    // Bak�� a��s� derecesi

    void Update()
    {
        // D��man�n bak�� a��s�n� hesapla
        float raycastAngle = Random.Range(raycastAnglemin, raycastAnglemax);
        float angleStep = raycastAngle / rayCount;
        float currentAngle = 0f;
        
        for (int i = 0; i < rayCount; i++)
        {
            // I��n y�n�n� hesapla
            Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * transform.forward;

            RaycastHit hit;

            // I��n g�nder
            if (Physics.Raycast(transform.position, direction, out hit, beamDistance))
            {
                // I��n bir nesneye �arpt�ysa ve bu nesne takip edilecek hedefse
                if (hit.transform == target)
                {
                    // Hedefi takip et
                    Vector3 targetDirection = (target.position - transform.position).normalized;

                    // Hedefe do�ru d�n
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                    // Hedefe do�ru ileri hareket et
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    poohAI.SetRandomDestination();

                }
               
            }

            // I��n� g�ster
            Debug.DrawRay(transform.position, direction * beamDistance, Color.red);

            // Sonraki a��ya ge�
            currentAngle += angleStep;
        }
    }
}
