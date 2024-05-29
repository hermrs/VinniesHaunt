using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour, IPhoneNumber
{
    [SerializeField] Button numberButton;
    public int number;
    public PhoneController phoneController;
    public AudioClip buttonSound; // Tuþ sesi

    public AudioSource audioSource; // Dýþarýdan atanabilir AudioSource

    private void Start()
    {
        numberButton = GetComponent<Button>();
        numberButton.onClick.AddListener(() => TaskOnClick(number));
        phoneController = GetComponentInParent<PhoneController>();

        // Eðer audioSource atanmamýþsa yeni bir AudioSource bileþeni ekleyelim
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TaskOnClick(int buttonNumber)
    {
        Debug.Log(buttonNumber);
        phoneController.girilenNum += buttonNumber;
        Debug.Log("Girilen Numara: " + phoneController.girilenNum);

        // Tuþ sesini çal
        PlayButtonSound();
    }

    // Tuþ sesini çalmak için metot
    private void PlayButtonSound()
    {
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }
}
