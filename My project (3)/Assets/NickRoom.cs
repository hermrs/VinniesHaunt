using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickRoom : MonoBehaviour
{
    public string hedefOdaAdi; 
    public Text ekrandakiMetin;
    public GameObject closeRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cocuk")) 
        {
           
            StartCoroutine(TimeNickRoom(3));
        }
    }

    IEnumerator TimeNickRoom(float timeing)
    {
        ekrandakiMetin.text = hedefOdaAdi;
        
        yield return new WaitForSeconds(timeing);
        PanelController.instance.OpenPanel(closeRoom);
        PanelController.instance.ClosePanel(gameObject);

        ekrandakiMetin.text = ""; 
    }
    
}
