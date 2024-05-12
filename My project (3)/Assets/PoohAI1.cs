using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoohAI1 : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject objectToFollow;
    public float trackingSpeed = 5f;
    public LayerMask obstacleLayerMask; 

    public bool isObjectInView = false;

   

    public void FollowObject()
    {
        if (isObjectInView)
        {
            Vector3 targetPosition = mainCamera.WorldToViewportPoint(objectToFollow.transform.position);
            targetPosition.z = 10f;
            Vector3 targetWorldPosition = mainCamera.ViewportToWorldPoint(targetPosition);
            transform.position = Vector3.Lerp(transform.position, targetWorldPosition, Time.deltaTime * trackingSpeed);
        }
    }

    public bool IsObstacleBetweenCameraAndObject()
    {

        Vector3 cameraToTarget = objectToFollow.transform.position - mainCamera.transform.position;
        Ray ray = new Ray(mainCamera.transform.position, cameraToTarget);

        RaycastHit[] hits = Physics.RaycastAll(ray, cameraToTarget.magnitude, obstacleLayerMask);


        return hits.Length > 0;
    }
}
