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
        if (SoundManager.Instance != null)
        {
            if (volumeSlider == null)
            {
                volumeSlider = FindObjectOfType<Slider>();
            }

            if (volumeSlider != null)
            {
                volumeSlider.value = SoundManager.Instance.soundEffectSource.volume;
                volumeSlider.onValueChanged.AddListener(SoundManager.Instance.ChangeVolume);
            }
        }
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
}
