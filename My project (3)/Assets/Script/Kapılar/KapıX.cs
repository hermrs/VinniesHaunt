using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapıX : MonoBehaviour, IDestroyable
{
    public void Destroyable()
    {
        if (KeyX.gotTheXKey == true)
        {
            Destroy(gameObject); //animasyon girecek bunun yerine
        }
    }

}
