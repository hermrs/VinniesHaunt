using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour, IPhoneNumber
{
    [SerializeField]Button numberButton;
    public int number;
    public PhoneController phoneController;
    private void Start()
    {
        numberButton = GetComponent<Button>();
        numberButton.onClick.AddListener(() => TaskOnClick(number));
        phoneController = GetComponentInParent<PhoneController>();
    }
    public void TaskOnClick(int butonnumber)
    {
        Debug.Log(butonnumber);
        phoneController.girilenNum += butonnumber;
        Debug.Log("Girilen Numara: "+ phoneController.girilenNum);
    }
}
