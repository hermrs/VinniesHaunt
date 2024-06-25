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
    public float newSpeed = 4f;

    private bool isWaiting = false;
    private float waitTimer;
    private GameObject enYakinHedef = null;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
        agent.speed = newSpeed;
        newSpeed = 0.4f;

    }


    private void Update()
    {
        Debug.Log(agent.speed);
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                newSpeed = 0.4f;

                isWaiting = false;
                SetRandomDestination();
            }
            return;
        }

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

        if (enYakinHedef != null && IsTargetVisible(enYakinHedef))
        {
            agent.SetDestination(enYakinHedef.transform.position);
            newSpeed = 1;
        }
        else
        {
            // Hedef yoksa veya hedef görünür deðilse rastgele hareket et
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                isWaiting = true;
                waitTimer = waitTime;
                newSpeed = 0f;

            }
        }
        if (agent.speed > 0)
        {
            animator.SetBool("isWalk", true);
            Debug.Log("ANÝMASYON ÇALIÞTI");
        }
        animator.SetFloat("speed", newSpeed);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cocuk")
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
