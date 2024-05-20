using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    public string girilenNum;
    public const string polisNum="112";
    public Button buttonCall;
    public GameObject phonePanel;

    private void Start()
    {
        buttonCall.onClick.AddListener(()=>CallNumberChecker(polisNum));
    }

    public void CallNumberChecker(string controlNumber)
    {
        if (buttonCall != null && girilenNum == controlNumber) 
        {
            Debug.Log("polis arandý");
            StartCoroutine(KapatmaBekle());
        }

    }

    IEnumerator KapatmaBekle()
    {
        // 1 saniye bekle
        yield return new WaitForSeconds(1f);

        // Telefonu kapat
        PanelController.instance.ClosePanel(phonePanel);
    }
}
