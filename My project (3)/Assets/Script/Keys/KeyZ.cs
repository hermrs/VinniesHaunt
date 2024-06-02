using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyZ : MonoBehaviour, ICollectible
{
    public static bool gotTheZKey = false;
    public void Collect()
    {
        gotTheZKey = true;
        GameManager.Instance.OnKeyCollected();
        UIManager.Instance.UpdateKeyZImage();
        Destroy(gameObject);
    }
}
