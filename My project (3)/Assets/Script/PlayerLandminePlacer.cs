using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandminePlacer : MonoBehaviour
{
    public Transform childTransform;

    void Start()
    {
        if (childTransform == null)
        {
            childTransform = transform.Find("Cocuk");
            if (childTransform == null)
            {
                Debug.LogError("Bebe Transform bulunamadý. Lütfen sahnede objeyi kontrol edin.");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3 childPosition = childTransform.position;
            LandmineManager.Instance.CreateLandmine(childPosition);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Landmine"))
        {
            StartCoroutine(LandmineManager.Instance.CooldownInteraction(other));
        }
    }
}
