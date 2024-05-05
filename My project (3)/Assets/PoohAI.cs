using UnityEngine;
using UnityEngine.AI;

public class PoohAI : MonoBehaviour
{
    public float wanderTimer = 5f; // Rastgele dolaþma zaman aralýðý

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        // Ýlk hedefi belirlemek için rastgele bir konum ayarla
        SetRandomDestination();
    }

    void Update()
    {
        // Eðer karakter hedefe ulaþtýysa, yeni bir hedef belirle
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }

        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            SetRandomDestination();
            timer = 0;
        }
    }

    // Rastgele bir konuma doðru hareket etmek için hedef belirleme
    public void SetRandomDestination()
    {
        float wanderRadius = Random.Range(10f, 25f); // Rastgele dolaþma yarýçapý
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        Vector3 finalPosition = hit.position;

        // Hedef konumu ayarla
        agent.SetDestination(finalPosition);
    }
}
