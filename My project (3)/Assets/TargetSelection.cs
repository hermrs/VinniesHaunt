using UnityEngine;
using UnityEngine.AI;

public static class TargetSelector
{
    public static GameObject FindClosestTarget(Vector3 position)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Cocuk");
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;

        foreach (var target in targets)
        {
            float distance = Vector3.Distance(position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }

        return closestTarget;
    }

    public static bool IsTargetVisible(Transform origin, GameObject target, float maxDistance, LayerMask obstacleLayer)
    {
        Vector3 directionToTarget = (target.transform.position - origin.position).normalized;
        Ray ray = new Ray(origin.position, directionToTarget);

        if (Physics.Raycast(ray, maxDistance, obstacleLayer))
        {
            return false;
        }
        return true;
    }
}

public class MovementController
{
    private NavMeshAgent agent;
    private PoohAI poohAI;

    public MovementController(NavMeshAgent agent, PoohAI poohAI)
    {
        this.agent = agent;
        this.poohAI = poohAI;
    }

    public void MoveToTarget(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }
}
