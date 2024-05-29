using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject masaCamera;
    public float maxHideTime = 10f;
    public float minHideTime = 0f;
    public GameObject Cocuk;
    bool isActive = true;

    bool isHide;

    private void Start()
    {
        
        masaCamera = GameObject.Find("MasaCamera");
        masaCamera.SetActive(false);
    }
    private void Update()
    {
        HideController();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Cocuk")&&isActive)
        {
           
            other.gameObject.SetActive(false);
            masaCamera.SetActive(true);
            isHide = true;
            minHideTime = 0.0f;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Cocuk"))
        {
            isActive = true;
        }
    }

    void HideController()
    {
        if (isHide)
        {
            minHideTime += Time.deltaTime; 

            if (minHideTime >= maxHideTime)
            {
                masaCamera.SetActive(false);
                isHide = false;
                isActive = false;
                Cocuk.gameObject.SetActive(true);

            }
            Debug.Log(minHideTime);
        }
    }
    
}