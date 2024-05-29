using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour, IPhoneNumber
{
    [SerializeField] Button numberButton;
    public int number;
    public PhoneController phoneController;
    public AudioClip buttonSound; // Tu� sesi

    public AudioSource audioSource; // D��ar�dan atanabilir AudioSource

    private void Start()
    {
        numberButton = GetComponent<Button>();
        numberButton.onClick.AddListener(() => TaskOnClick(number));
        phoneController = GetComponentInParent<PhoneController>();

        // E�er audioSource atanmam��sa yeni bir AudioSource bile�eni ekleyelim
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

        // Tu� sesini �al
        PlayButtonSound();
    }

    // Tu� sesini �almak i�in metot
    private void PlayButtonSound()
    {
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }
}
