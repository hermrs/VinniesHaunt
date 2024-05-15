using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCollisionHandler : MonoBehaviour, PanelOpener
{
    private bool canActivate = false;
    public GameObject phonePanel;

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.E))
        {
            Interact(phonePanel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cocuk"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cocuk"))
        {
            canActivate = false;
        }
    }
    public void Interact(GameObject phonePanel)
    {
        // player ile panel arasýnda bir etkileþim gerçekleþtir
        if (phonePanel != null)
        {
            phonePanel.SetActive(!phonePanel.activeSelf); // Paneli aktif veya pasif yap
        }
    }

}




