//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Tuzak : MonoBehaviour
//{
//    PoohAI poohAI;
//    bool isSlow;
//    float tuzakHizi = 1f; 
//    float normalHiz = 4f; 

//    private void Start()
//    {
//        poohAI = GetComponent<PoohAI>(); 
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Pooh"))
//        {
            
//            poohAI.SetNewSpeed(tuzakHizi);
//            isSlow = true; // Yava� modu aktifle�tir
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Pooh"))
//        {
//            // Tuzak b�lgesinden ��k�� yap�ld���nda, PoohAI bile�enindeki h�z� geri al
//            poohAI.SetNewSpeed(normalHiz);
//            isSlow = false; // Yava� modu devre d��� b�rak
//        }
//    }

//    void Update()
//    {
//        // E�er yava� mod aktifse ve tuzak h�z� belirli bir de�ere ula�m��sa, normal h�za d�n
//        if (isSlow && tuzakHizi < 3f)
//        {
//            tuzakHizi += Time.deltaTime * 0.5f; // H�z� yava��a artt�r
//            poohAI.SetNewSpeed(tuzakHizi); // PoohAI bile�enindeki h�z� g�ncelle
//        }
//    }
//}
