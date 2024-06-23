using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PoohAI : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public float maxMenzil = 50f;
    public LayerMask obstacleLayer;
    public float randomRadius = 50f;
    public float waitTime = 3f;
    public float newSpeed;
    //public float destinationThreshold = 1f; // Hedefe dokunma mesafesi
    public float randomDestinationInterval = 2f; // Yeni hedef için bekleme süresi

    private bool isWaiting = false;
    private float waitTimer;
    private GameObject enYakinHedef = null;
    private float randomDestinationTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
        newSpeed = 0.4f;
        randomDestinationTimer = randomDestinationInterval;
    }

    private void Update()
    {
        UpdateTarget();
        randomDestinationTimer -= Time.deltaTime;

        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                newSpeed = .3f;
                isWaiting = false;
                SetRandomDestination();
            }
            return;
        }

        // En yakýn hedefi güncelle

        else if (enYakinHedef != null && IsTargetVisible(enYakinHedef))
        {
            agent.SetDestination(enYakinHedef.transform.position); // Güncel hedefe doðru git
            newSpeed = 1f;
        }
        else
        {
            if (randomDestinationTimer <= 0f)
            {
                SetRandomDestination();
                randomDestinationTimer = randomDestinationInterval;
            }

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                isWaiting = true;
                waitTimer = waitTime;
                newSpeed = 0f;
            }
        }

        animator.SetFloat("speed", newSpeed);
    }

    void UpdateTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, maxMenzil);
        float enYakinMesafe = Mathf.Infinity;
        enYakinHedef = null;

        foreach (var objeler in hitColliders)
        {
            if (objeler.gameObject.CompareTag("Cocuk"))
            {
                float mesafe = Vector3.Distance(transform.position, objeler.transform.position);
                if (mesafe < enYakinMesafe)
                {
                    enYakinMesafe = mesafe;
                    enYakinHedef = objeler.gameObject;
                }
            }
        }
    }

    bool IsTargetVisible(GameObject hedef)
    {
        Vector3 directionToTarget = (hedef.transform.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, directionToTarget);
        RaycastHit hit;
        Debug.DrawRay(transform.position, directionToTarget * maxMenzil, Color.yellow);

        if (Physics.Raycast(ray, out hit, maxMenzil, obstacleLayer))
        {
            if (hit.collider.gameObject != hedef)
            {
                return false;
            }
        }
        return true;
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection;
        NavMeshHit navHit;
        for (int i = 0; i < 10; i++)
        {
            randomDirection = Random.insideUnitSphere * randomRadius;
            randomDirection += transform.position;
            if (NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(navHit.position);
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cocuk"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxMenzil);
    }
}


//    public float wanderTimer = 5f; // Rastgele dola?ma zaman aral???

//    private NavMeshAgent agent;
//    private float timer;

//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        timer = wanderTimer;

//        // ?lk hedefi belirlemek için rastgele bir konum ayarla
//        SetRandomDestination();
//    }

//    void Update()
//    {
//        // E?er karakter hedefe ula?t?ysa, yeni bir hedef belirle
//        if (!agent.pathPending && agent.remainingDistance < 0.5f)
//        {
//            SetRandomDestination();
//        }

//        timer += Time.deltaTime;
//        if (timer >= wanderTimer)
//        {
//            SetRandomDestination();
//            timer = 0;
//        }
//    }

//    // Rastgele bir konuma do?ru hareket etmek için hedef belirleme
//    public void SetRandomDestination()
//    {
//        float wanderRadius = Random.Range(10f, 25f); // Rastgele dola?ma yar?çap?
//        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
//        randomDirection += transform.position;
//        NavMeshHit hit;
//        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
//        Vector3 finalPosition = hit.position;

//        // Hedef konumu ayarla
//        agent.SetDestination(finalPosition);
//    }
//}