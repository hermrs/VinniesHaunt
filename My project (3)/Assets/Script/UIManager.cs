using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text keysCollectedText;  // TMP_Text bileşenini burada tanımlıyoruz
    public Image duckTapeImage;
    public TMP_Text landmineCountText;

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
    }

    public void UpdateKeyUI(int collectedKeys)
    {
        if (keysCollectedText != null)
        {
            keysCollectedText.text = "Toplanan Anahtarlar: " + collectedKeys;
        }
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
            landmineCountText.text = "Mayınlar: " + count;
        }
    }
}
