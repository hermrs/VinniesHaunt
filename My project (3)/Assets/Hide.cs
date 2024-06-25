using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Hide : MonoBehaviour, ICollectible
{
    public GameObject masaCamera;
    public float maxHideTime = 10f;
    public float minHideTime = 0f;
    public GameObject Cocuk;
    public GameObject FlashLight;
    bool isActive = true;
  

    bool isHide;

    private void Start()
    {
     
        masaCamera = GameObject.Find("MasaCamera");
        PanelController.instance.ClosePanel(masaCamera);
    }
    private void Update()
    {
        KeyCod();
        HideController();
    }

    public void Collect()
    {
        FlashLight.gameObject.SetActive(false);
        Cocuk.gameObject.SetActive(false);
        PanelController.instance.OpenPanel(masaCamera);
        isHide = true;
        minHideTime = 0.0f;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cocuk"))
        {
            isActive = true;
          
        }
    }
    void KeyCod()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            minHideTime = 10;
        }
    }

    void HideController()
    {
        if (isHide)
        {
            minHideTime += Time.deltaTime;

            if (minHideTime >= maxHideTime)
            {
                PanelController.instance.ClosePanel(masaCamera);
                isHide = false;
                isActive = false;
                PanelController.instance.OpenPanel(Cocuk);
                PanelController.instance.OpenPanel(FlashLight);

            }
            Debug.Log(minHideTime);
        }
    }

}