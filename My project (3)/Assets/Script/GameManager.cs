using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int totalKeys = 3; // Toplam anahtar say�s�
    private int collectedKeys = 0; // Toplanan anahtar say�s�
    public TMP_Text keysCollectedText; // Anahtar say�s�n� g�sterecek UI TMP_Text
    
    public bool hasDuckTape = false;
    public Image duckTapeImage;

    //private int totalLandmine = 3;
    //private int collectedLandmine = 0;
    //public TMP_Text LandimeCollectorText;

    public TMP_Text landmineCountText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Sahne de�i�se bile yok olmas�n
        }
        else
        {
            Destroy(gameObject);  // E�er ba�ka bir instance varsa, bu instance'� yok et
        }
    }

    private void Start()
    {
        if (duckTapeImage != null)
        {
            duckTapeImage.enabled = false;  // Oyun ba�lad���nda DuckTape image'ini gizle
        }
    }

    public void UpdateLandmineCount(int count)
    {
        if (landmineCountText != null)
        {
            landmineCountText.text = "Landmines: " + count;
        }
    }

    public void CollectKey(GameObject keyObject)
    {
        collectedKeys++;
        Destroy(keyObject);

        UpdateKeyUI();

        // E�er t�m anahtarlar topland�ysa, i�lemleri ger�ekle�tir
        if (collectedKeys == totalKeys)
        {
            AllKeysCollected();
        }
    }
    private void UpdateKeyUI()
    {
        if (keysCollectedText != null)
        {
            keysCollectedText.text = "Collected Keys: " + collectedKeys;
        }
    }

    private void UpdateDuckTapeUI()
    {
        if (duckTapeImage != null)
        {
            duckTapeImage.enabled = true;  // DuckTape al�nd���nda image'i g�ster
        }
    }

    private void AllKeysCollected()
    {
        // T�m anahtarlar�n topland���nda yap�lacak i�lemler
        Debug.Log("All keys collected!");
        // Burada istedi�iniz i�lemleri ger�ekle�tirin, �rne�in bir kap�y� a�ma vs.
    }

    public void CollectDuckTape(GameObject duckTapeObject)
    {
        hasDuckTape = true;
        Destroy(duckTapeObject);

        UpdateDuckTapeUI();
    }
}
