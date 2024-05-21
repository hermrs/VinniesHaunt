using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int totalKeys = 3; // Toplam anahtar sayýsý
    private int collectedKeys = 0; // Toplanan anahtar sayýsý
    public TMP_Text keysCollectedText; // Anahtar sayýsýný gösterecek UI TMP_Text
    
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
            DontDestroyOnLoad(gameObject);  // Sahne deðiþse bile yok olmasýn
        }
        else
        {
            Destroy(gameObject);  // Eðer baþka bir instance varsa, bu instance'ý yok et
        }
    }

    private void Start()
    {
        if (duckTapeImage != null)
        {
            duckTapeImage.enabled = false;  // Oyun baþladýðýnda DuckTape image'ini gizle
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

        // Eðer tüm anahtarlar toplandýysa, iþlemleri gerçekleþtir
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
            duckTapeImage.enabled = true;  // DuckTape alýndýðýnda image'i göster
        }
    }

    private void AllKeysCollected()
    {
        // Tüm anahtarlarýn toplandýðýnda yapýlacak iþlemler
        Debug.Log("All keys collected!");
        // Burada istediðiniz iþlemleri gerçekleþtirin, örneðin bir kapýyý açma vs.
    }

    public void CollectDuckTape(GameObject duckTapeObject)
    {
        hasDuckTape = true;
        Destroy(duckTapeObject);

        UpdateDuckTapeUI();
    }
}
