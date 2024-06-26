using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text keysCollectedText;  // TMP_Text bileşenini burada tanımlıyoruz
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
            duckTapeImage.enabled = false; // Oyun başladığında DuckTape görüntüsünü gizle
        }
        if (keyXImage != null)//x Anahtarı başladığında görünmez
        {
            keyXImage.enabled = false;
        }
        if (keyYImage != null)//y Anahtarı başladığında görünmez
        {
            keyYImage.enabled = false;
        }
        if (keyZImage != null)//z Anahtarı başladığında görünmez
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
            duckTapeImage.enabled = true; // DuckTape alındığında görüntüyü göster
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
