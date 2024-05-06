using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonecarpısma : MonoBehaviour
{
    public GameObject obje1; // İlk oyun nesnesi
    public GameObject obje2; // İkinci oyun nesnesi
    public GameObject obje3; // Üçüncü oyun nesnesi

    void Update()
    {
        // Eğer obje1 ve obje2 çarpışıyorsa
        if (obje1.GetComponent<Collider>().bounds.Intersects(obje2.GetComponent<Collider>().bounds))
        {
            // obje3'ü aktif hale getir
            obje3.SetActive(true);
        }
    }
}
