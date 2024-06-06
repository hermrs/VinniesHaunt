//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KeyY : MonoBehaviour, ICollectible
//{
//    public static bool gotTheYKey = false;
//    public void Collect()
//    {
//        gotTheYKey = true;
//        GameManager.Instance.OnKeyCollected();
//        UIManager.Instance.UpdateKeyImage(UIManager.Instance.keyYImage);
//        Destroy(gameObject);
//    }
//}
using UnityEngine;
using UnityEngine.UI;

public class KeyY : BaseKey
{
    public static bool gotTheYKey = false;

    public override void Collect()
    {
        base.Collect();
        gotTheYKey = true;
    }

    protected override Image GetKeyImage()
    {
        return UIManager.Instance.keyYImage;
    }
}