using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text keysCollectedText;  // TMP_Text bileþenini burada tanýmlýyoruz
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
            duckTapeImage.enabled = false; // Oyun baþladýðýnda DuckTape görüntüsünü gizle
        }
        if (keyXImage != null)//x Anahtarý baþladýðýnda görünmez
        {
            keyXImage.enabled = false;
        }
        if (keyYImage != null)//y Anahtarý baþladýðýnda görünmez
        {
            keyYImage.enabled = false;
        }
        if (keyZImage != null)//z Anahtarý baþladýðýnda görünmez
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
            duckTapeImage.enabled = true; // DuckTape alýndýðýnda görüntüyü göster
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
