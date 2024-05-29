//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class SoundSettings : MonoBehaviour
//{
//    public Slider volumeSlider;

//    private void Start()
//    {
//        SetupSlider();
//    }

//    private void SetupSlider()
//    {
//        if (SoundManager.Instance != null)
//        {
//            if (volumeSlider == null)
//            {
//                volumeSlider = FindObjectOfType<Slider>();
//            }

//            if (volumeSlider != null)
//            {
//                volumeSlider.value = SoundManager.Instance.soundEffectSource.volume;
//                volumeSlider.onValueChanged.AddListener(SoundManager.Instance.ChangeVolume);
//            }
//        }
//    }

//    private void OnEnable()
//    {
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }

//    private void OnDisable()
//    {
//        SceneManager.sceneLoaded -= OnSceneLoaded;
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        SetupSlider();
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        SetupSlider();
    }

    private void SetupSlider()
    {
        if (volumeSlider == null)
        {
            Debug.LogError("Volume slider nesnesi bulunamadý!");
            return;
        }

        // PlayerPrefs'ten kaydedilmiþ ses seviyesini yükle
        float savedVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        volumeSlider.value = savedVolume;
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        SoundManager.Instance.ChangeVolume(savedVolume);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetupSlider();
    }

    // Ses seviyesini deðiþtirmek için metot
    public void ChangeVolume(float newVolume)
    {
        SoundManager.Instance.ChangeVolume(newVolume);
        // PlayerPrefs'e ses seviyesini kaydet
        PlayerPrefs.SetFloat("SoundVolume", newVolume);
    }
}
