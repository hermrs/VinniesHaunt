using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        GameManager.Instance.OnKeyCollected();
        UIManager.Instance.UpdateKeyImage(UIManager.Instance.keyXImage);
        Destroy(gameObject);
    }
}
