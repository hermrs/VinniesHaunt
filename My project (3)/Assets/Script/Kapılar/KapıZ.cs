using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapıZ : MonoBehaviour, IDestroyable
{
    public void Destroyable()
    {
        if (KeyZ.gotTheZKey == true)
        {
            Destroy(gameObject); //animasyon girecek bunun yerine
        }
    }
}
