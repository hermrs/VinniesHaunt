using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Phone : MonoBehaviour
{
    public TMP_Text numaraText; // Butonun üzerinde ne gösterileceðini belirleyen text bileþeni
    public Button[] tuslar;
    public bool polisArandi = false;
    private string beklenenNumara = "911";
    private string girilenNumara;
    public AudioClip tusSesi; // Tuþ sesi
    public AudioClip polisSesi; // Polis sesi
    public AudioSource audioSource; // Sesi çalmak için AudioSource bileþeni
    public GameObject phonePanel;
    private void Update()
    {
        RakamTikla();        
    }
    public void RakamTikla()
    {
        // Tuþ sesini çal
        //audioSource.PlayOneShot(tusSesi);

        if (!polisArandi && girilenNumara == beklenenNumara)// Polis arandý boolunu true yap
        {

            polisArandi = true; // Polis sesini çal

            audioSource.PlayOneShot(polisSesi);

            Debug.Log("Polis arandý!");

            StartCoroutine(KapatmaBekle());

        }

        IEnumerator KapatmaBekle()
        {
            // 1 saniye bekle
            yield return new WaitForSeconds(1f);

            // Telefonu kapat
            phonePanel.SetActive(false);
        }
    }

    public void TaskOnClick(int butonNumarasi)
    {
        switch (butonNumarasi)
        {
            case 0:
                Debug.Log("0");
                numaraText.text = "0";
                girilenNumara += "0";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 1:
                Debug.Log("1");
                numaraText.text = "1";
                girilenNumara += "1";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 2:
                Debug.Log("2");
                numaraText.text = "2";
                girilenNumara += "2";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 3:
                Debug.Log("3");
                numaraText.text = "3";
                girilenNumara += "3";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 4:
                Debug.Log("4");
                numaraText.text = "4";
                girilenNumara += "4";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 5:
                Debug.Log("5");
                numaraText.text = "5";
                girilenNumara += "5";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 6:
                Debug.Log("6");
                numaraText.text = "6";
                girilenNumara += "6";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 7:
                Debug.Log("7");
                numaraText.text = "7";
                girilenNumara += "7";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 8:
                Debug.Log("8");
                numaraText.text = "8";
                girilenNumara += "8";
                audioSource.PlayOneShot(tusSesi);
                break;
            case 9:
                Debug.Log("9");
                numaraText.text = "9";
                girilenNumara += "9";
                audioSource.PlayOneShot(tusSesi);
                break;
            default:
                Debug.Log("Tanýmsýz buton: " + butonNumarasi);
                break;
        }

    }
}