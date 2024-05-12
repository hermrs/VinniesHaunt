using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public GameObject keyObject;

    public bool gotTheKey = false;

    public void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Key"))
        {
            gotTheKey = true;
            Destroy(keyObject);
        }
    }
}
