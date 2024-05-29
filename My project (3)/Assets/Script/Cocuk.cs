using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cocuk : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        Destroy(gameObject);
        LandmineManager.Instance.IncreaseLandmineCount();
    }
}
