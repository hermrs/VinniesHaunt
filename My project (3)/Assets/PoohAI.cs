using UnityEngine;
using UnityEngine.AI;

public class PoohAI : PoohAI1
{
    public float wanderTimer = 5f;

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        SetRandomDestination();
    }

    void Update()
    {
        if (objectToFollow != null && mainCamera != null)
        {

            Vector3 viewportPoint = mainCamera.WorldToViewportPoint(objectToFollow.transform.position);

            if (viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0 && !IsObstacleBetweenCameraAndObject())
            {

                isObjectInView = true;
                FollowObject();
            }
            else
            {
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

                isObjectInView = false;
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cocuk"))
        {
            Time.timeScale = 0;
            Debug.Log("temas etti");

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
