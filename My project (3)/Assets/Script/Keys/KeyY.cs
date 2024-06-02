using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyY : MonoBehaviour, ICollectible
{
    public static bool gotTheYKey = false;
    public void Collect()
    {
        gotTheYKey = true;
        GameManager.Instance.OnKeyCollected();
        UIManager.Instance.UpdateKeyYImage();
        Destroy(gameObject);
    }
}
