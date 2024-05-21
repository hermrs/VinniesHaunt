using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    public static SoundManager Instance { get; private set; }

    // Ses efektini �almak i�in bir AudioSource bile�eni
    public AudioSource soundEffectSource;

    // �rnek bir ses efekti
    public AudioClip soundEffectClip;

    // Ses seviyesini ayarlamak i�in Slider
    public Slider volumeSlider;

    // Component'lerin ilk y�kleni�inde �a�r�l�r
    private void Awake()
    {
        // Singleton instance olu�tur
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Sahne de�i�tirilse bile yok olmas�n
        }
        else
        {
            Destroy(gameObject);  // E�er ba�ka bir instance varsa, bu instance'� yok et
            return;
        }

        // soundEffectSource de�i�kenine bir AudioSource bile�eni atama
        if (soundEffectSource == null)
        {
            soundEffectSource = GetComponent<AudioSource>();
        }
    }

    // Ba�lang��ta ses efekti �alma i�levi
    private void Start()
    {
        // Null kontrol� yap
        if (!CheckSoundEffectSource()) return;

        // Ses efekti dosyas�n� ayarla
        soundEffectSource.clip = soundEffectClip;

        // Ses efektini �al
        soundEffectSource.Play();

        // Slider de�erini g�ncelle ve dinleyici ekle
        if (volumeSlider != null)
        {
            volumeSlider.value = soundEffectSource.volume;
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    // Ses efektinin �iddetini de�i�tirmek i�in bir metot
    public void ChangeVolume(float newVolume)
    {
        // Null kontrol� yap
        if (!CheckSoundEffectSource()) return;

        // Yeni ses efekti �iddeti
        soundEffectSource.volume = newVolume;
    }

    // Null kontrol� yapacak yard�mc� bir metot
    private bool CheckSoundEffectSource()
    {
        // Bile�en atanm��sa true, atanmam��sa uyar� ver ve false d�nd�r
        return soundEffectSource != null ? true : false;
    }
}
