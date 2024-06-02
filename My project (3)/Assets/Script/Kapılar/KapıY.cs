using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapıY : MonoBehaviour, IDestroyable
{
    public void Destroyable()
    {
        if (KeyY.gotTheYKey == true)
        {
            Destroy(gameObject); //animasyon girecek bunun yerine
        }
    }
}
