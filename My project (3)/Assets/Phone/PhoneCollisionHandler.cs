using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCollisionHandler : MonoBehaviour
{
    private bool canActivate = false;
    public GameObject phonePanel;



    private void Update()
    {
       
        if (canActivate)
        {
            
                PanelController.instance.OpenPanelWidthKey(phonePanel, KeyCode.E);
                Debug.Log("panel açýldý");
            
            //panelController.OpenPanel(phonePanel);
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
  

}




