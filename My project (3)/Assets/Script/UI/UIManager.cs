using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text keysCollectedText;  // TMP_Text bile�enini burada tan�ml�yoruz
    public Image duckTapeImage;
    public TMP_Text landmineCountText;
    public Image keyXImage;
    public Image keyYImage;
    public Image keyZImage;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (duckTapeImage != null)
        {
            duckTapeImage.enabled = false; // Oyun ba�lad���nda DuckTape g�r�nt�s�n� gizle
        }
        if (keyXImage != null)//x Anahtar� ba�lad���nda g�r�nmez
        {
            keyXImage.enabled = false;
        }
        if (keyYImage != null)//y Anahtar� ba�lad���nda g�r�nmez
        {
            keyYImage.enabled = false;
        }
        if (keyZImage != null)//z Anahtar� ba�lad���nda g�r�nmez
        {
            keyZImage.enabled = false;
        }
    }

    public void UpdateKeyUI(int collectedKeys)
    {
        if (keysCollectedText != null)
        {
            keysCollectedText.text = "" + collectedKeys;
        }
    }

    public void UpdateImageUI(Image image)
    {
        if (image != null)
        {
            image.enabled = true;
        }
    }

    public void UpdateKeyImage(Image image)
    {
        UpdateImageUI(image);
    }

    public void UpdateDuckTapeUI()
    {
        if (duckTapeImage != null)
        {
            duckTapeImage.enabled = true; // DuckTape al�nd���nda g�r�nt�y� g�ster
        }
    }

    public void UpdateLandmineCount(int count)
    {
        if (landmineCountText != null)
        {
            landmineCountText.text = "" + count;
        }
    }
}
