using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PoohAI : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public float maxMenzil = 15f;
    public LayerMask obstacleLayer;
    public float randomRadius = 20f;
    public float waitTime = 3f;
    public float newSpeed;

    private bool isWaiting = false;
    private float waitTimer;
    private GameObject enYakinHedef = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
        newSpeed = 0.4f;
    }


    private void Update()
    {
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

        UpdateTarget(); // En yak?n hedefi güncelle

        if (enYakinHedef != null && IsTargetVisible(enYakinHedef))
        {
            agent.SetDestination(enYakinHedef.transform.position); // Güncel hedefe do?ru git
            newSpeed = 1f;
        }
        else
        {
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
        Vector3 randomDirection = Random.insideUnitSphere * randomRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, NavMesh.AllAreas);
        agent.SetDestination(navHit.position);
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