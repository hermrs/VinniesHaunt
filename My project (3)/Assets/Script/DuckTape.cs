using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTape : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        GameManager.Instance.OnDuckTapeCollected();
        Destroy(gameObject);
    }
}
