using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyX : MonoBehaviour, ICollectible
{
    public static bool gotTheXKey = false;
    public void Collect()
    {
        gotTheXKey = true;
        GameManager.Instance.OnKeyCollected();
        UIManager.Instance.UpdateKeyXImage();
        Destroy(gameObject);
    }
}
