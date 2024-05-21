using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeCollector : MonoBehaviour
{
    public bool gotTheKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            gotTheKey = true;
            GameManager.Instance.CollectKey(other.gameObject);
        }

        else if (other.CompareTag("DuckTape"))
        {
            GameManager.Instance.CollectDuckTape(other.gameObject);
        }

        else if (other.CompareTag("Cocuk"))
        {
            Destroy(gameObject);
            LandmineManager.Instance.IncreaseLandmineCount();
        }

    }
    
}
