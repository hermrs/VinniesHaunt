using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Son : MonoBehaviour, IDestroyable
{

    public void Destroyable()
    {
        if (GameManager.Instance.allKeysCollected == true)
        {
            SceneManager.LoadScene("GoodFin");  //animasyon girecek bunun yerine OYUN SONU
        }
    }
    public void Interact()
    {
        Destroyable();
    }
}
