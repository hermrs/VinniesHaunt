using UnityEngine;

public class AudioSourceVolumeUpdater : MonoBehaviour
{
    // AudioSource bileþenine referans
    public AudioSource audioSource;

    // Start metodu yerine Awake metodu kullanýlabilir
    private void Awake()
    {
        // Null kontrolü yap
        if (audioSource == null)
        {
            Debug.LogError("AudioSource nesnesi atanmamýþ!");
            return;
        }

        // PlayerPrefs'ten kaydedilmiþ ses seviyesini yükle
        float savedVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);

        // Ses seviyesini ayarla
        audioSource.volume = savedVolume;
    }

    // Slider'dan gelen yeni ses seviyesi deðeri
    public void SetVolume(float newVolume)
    {
        // Null kontrolü yap
        if (audioSource == null)
        {
            Debug.LogError("AudioSource nesnesi atanmamýþ!");
            return;
        }

        // Yeni ses seviyesini AudioSource nesnesine ata
        audioSource.volume = newVolume;

        // PlayerPrefs'e ses seviyesini kaydet
        PlayerPrefs.SetFloat("SoundVolume", newVolume);
    }
}
