using UnityEngine;

public class AudioSourceVolumeUpdater : MonoBehaviour
{
    // AudioSource bile�enine referans
    public AudioSource audioSource;

    // Start metodu yerine Awake metodu kullan�labilir
    private void Awake()
    {
        // Null kontrol� yap
        if (audioSource == null)
        {
            Debug.LogError("AudioSource nesnesi atanmam��!");
            return;
        }

        // PlayerPrefs'ten kaydedilmi� ses seviyesini y�kle
        float savedVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);

        // Ses seviyesini ayarla
        audioSource.volume = savedVolume;
    }

    // Slider'dan gelen yeni ses seviyesi de�eri
    public void SetVolume(float newVolume)
    {
        // Null kontrol� yap
        if (audioSource == null)
        {
            Debug.LogError("AudioSource nesnesi atanmam��!");
            return;
        }

        // Yeni ses seviyesini AudioSource nesnesine ata
        audioSource.volume = newVolume;

        // PlayerPrefs'e ses seviyesini kaydet
        PlayerPrefs.SetFloat("SoundVolume", newVolume);
    }
}
