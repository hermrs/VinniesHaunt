//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class KeyX : MonoBehaviour, ICollectible, IInteractable
//{
//    public static bool gotTheXKey = false;
//    public void Collect()
//    {
//        gotTheXKey = true;
//        GameManager.Instance.OnKeyCollected();
//        UIManager.Instance.UpdateKeyImage(UIManager.Instance.keyXImage);
//        Destroy(gameObject);
//    }

//    public void Interactable()
//    {
//        Collect();
//    }
//}
using UnityEngine;
using UnityEngine.UI;

public class KeyX : BaseKey
{
    public static bool gotTheXKey = false;

    public override void Collect()
    {
        base.Collect();
        gotTheXKey = true;
    }

    protected override Image GetKeyImage()
    {
        return UIManager.Instance.keyXImage;
    }
}