using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        GameManager.Instance.OnKeyCollected();
        Destroy(gameObject);
    }
}
