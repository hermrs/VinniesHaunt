using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Son : MonoBehaviour, IInteractable
{
   
    public void Interact()
    {

        if (GameManager.Instance.allKeysCollected == true)
        {
            SceneManager.LoadScene("GoodFin");  //animasyon girecek bunun yerine OYUN SONU
            Debug.Log("oopss");
            // cenko oyun sonu ekraný ekle
        }
    }
}
