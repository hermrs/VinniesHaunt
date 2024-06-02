using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Son : MonoBehaviour, IDestroyable
{
    public void Destroyable()
    {
        if (GameManager.Instance.allKeysCollected==true)
        {
            Destroy(gameObject); //animasyon girecek bunun yerine OYUN SONU
        }
    }

}
