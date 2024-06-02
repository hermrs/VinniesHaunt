using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandminePlacer : MonoBehaviour
{
    public Transform childTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3 childPosition = childTransform.position;
            Vector3 landminePosition = new Vector3(childPosition.x, childPosition.y - childTransform.localScale.y, childPosition.z);//çocuðun ayaðýnýn altýna koymasý için
            LandmineManager.Instance.CreateLandmine(landminePosition);
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
