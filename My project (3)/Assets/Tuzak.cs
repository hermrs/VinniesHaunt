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
//            isSlow = true; // Yavaþ modu aktifleþtir
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Pooh"))
//        {
//            // Tuzak bölgesinden çýkýþ yapýldýðýnda, PoohAI bileþenindeki hýzý geri al
//            poohAI.SetNewSpeed(normalHiz);
//            isSlow = false; // Yavaþ modu devre dýþý býrak
//        }
//    }

//    void Update()
//    {
//        // Eðer yavaþ mod aktifse ve tuzak hýzý belirli bir deðere ulaþmýþsa, normal hýza dön
//        if (isSlow && tuzakHizi < 3f)
//        {
//            tuzakHizi += Time.deltaTime * 0.5f; // Hýzý yavaþça arttýr
//            poohAI.SetNewSpeed(tuzakHizi); // PoohAI bileþenindeki hýzý güncelle
//        }
//    }
//}
