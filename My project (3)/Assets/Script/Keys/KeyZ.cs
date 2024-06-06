//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KeyZ : MonoBehaviour, ICollectible
//{
//    public static bool gotTheZKey = false;
//    public void Collect()
//    {
//        gotTheZKey = true;
//        GameManager.Instance.OnKeyCollected();
//        UIManager.Instance.UpdateKeyImage(UIManager.Instance.keyZImage);
//        Destroy(gameObject);
//    }
//}
using UnityEngine;
using UnityEngine.UI;

public class KeyZ : BaseKey
{
    public static bool gotTheZKey = false;

    public override void Collect()
    {
        base.Collect();
        gotTheZKey = true;
    }

    protected override Image GetKeyImage()
    {
        return UIManager.Instance.keyZImage;
    }
}