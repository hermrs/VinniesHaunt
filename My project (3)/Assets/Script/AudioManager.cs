using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource breathingSound;
    StaminaControl Stamina;
    public bool isBreathing = false;
    private void Start()
    {
        breathingSound = GetComponent<AudioSource>();
        Stamina = GetComponent<StaminaControl>();
    }
    private void FixedUpdate() { AdjustBreathingSoundDistance(); }
    void AdjustBreathingSoundDistance()
    {
        if (isBreathing)
        {

            float distanceMultiplier = (Stamina.maxStamina - Stamina.stamina) / Stamina.maxStamina;
            breathingSound.volume = Mathf.Clamp(Stamina.stamina / Stamina.maxStamina, 0.1f, 1f);
            breathingSound.spatialBlend = 1f;
            breathingSound.minDistance = 1f;
            breathingSound.maxDistance = 10f * distanceMultiplier;
        }
        else
        {
            breathingSound.volume = 0f;
        }
    }
    public void AudioStop(KeyCode StopKey)
    {
       if(Input.GetKeyDown(StopKey))
        {
            isBreathing = false;
            breathingSound.Stop();
            StartCoroutine(StartBreathingAfterDelay(StopKey));
        }
    }
    public void AudioStart(KeyCode StopKey)
    {
        if (Input.GetKeyUp(StopKey))
        {
            isBreathing = true;
            breathingSound.Play();
        }
    }
    private IEnumerator StartBreathingAfterDelay(KeyCode StopKey)
    {
        yield return new WaitForSeconds(2f);
        isBreathing = true;
        breathingSound.Play();
    }
}
//public void AudioStop(KeyCode StopKey, AudioSource audioSource)
//{
//    if (Input.GetKeyDown(StopKey))
//    {
//        isBreathing = false;
//        audioSource.Stop();
//    }
//}
