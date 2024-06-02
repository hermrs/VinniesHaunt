using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int totalKeys = 3;
    private int collectedKeys = 0;
    private bool hasDuckTape = false;
    public bool allKeysCollected = false;
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

    public void OnKeyCollected()
    {
        collectedKeys++;
        UIManager.Instance.UpdateKeyUI(collectedKeys);

        if (collectedKeys == totalKeys)
        {
            AllKeysCollected();
        }
    }

    public void OnDuckTapeCollected()
    {
        hasDuckTape = true;
        UIManager.Instance.UpdateDuckTapeUI();
    }

    private void AllKeysCollected()
    {
        allKeysCollected = true;
        Debug.Log("Tüm anahtarlar toplandý!");
        // Kapý açma gibi iþlemler burada yapýlabilir.
    }
}
