using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    public static SoundManager Instance { get; private set; }

    // Ses efektini çalmak için bir AudioSource bileþeni
    public AudioSource soundEffectSource;

    // Örnek bir ses efekti
    public AudioClip soundEffectClip;

    // Ses seviyesini ayarlamak için Slider
    public Slider volumeSlider;

    // Component'lerin ilk yükleniþinde çaðrýlýr
    private void Awake()
    {
        // Singleton instance oluþtur
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Sahne deðiþtirilse bile yok olmasýn
        }
        else
        {
            Destroy(gameObject);  // Eðer baþka bir instance varsa, bu instance'ý yok et
            return;
        }

        // soundEffectSource deðiþkenine bir AudioSource bileþeni atama
        if (soundEffectSource == null)
        {
            soundEffectSource = GetComponent<AudioSource>();
        }
    }

    // Baþlangýçta ses efekti çalma iþlevi
    private void Start()
    {
        // Null kontrolü yap
        if (!CheckSoundEffectSource()) return;

        // Ses efekti dosyasýný ayarla
        soundEffectSource.clip = soundEffectClip;

        // Ses efektini çal
        soundEffectSource.Play();

        // Slider deðerini güncelle ve dinleyici ekle
        if (volumeSlider != null)
        {
            volumeSlider.value = soundEffectSource.volume;
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    // Ses efektinin þiddetini deðiþtirmek için bir metot
    public void ChangeVolume(float newVolume)
    {
        // Null kontrolü yap
        if (!CheckSoundEffectSource()) return;

        // Yeni ses efekti þiddeti
        soundEffectSource.volume = newVolume;
    }

    // Null kontrolü yapacak yardýmcý bir metot
    private bool CheckSoundEffectSource()
    {
        // Bileþen atanmýþsa true, atanmamýþsa uyarý ver ve false döndür
        return soundEffectSource != null ? true : false;
    }
}
