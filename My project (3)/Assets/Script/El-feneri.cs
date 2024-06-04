using UnityEngine;
using System.Collections;

public class El_Feneri : MonoBehaviour
{
    public GameObject Light;
    bool isLight;

    void Start()
    {
        isLight = true;
        StartCoroutine(FlashLight());
    }
    IEnumerator FlashLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            isLight = !isLight;
            Light.SetActive(isLight);
            StartCoroutine(FlashLight2(0.3f));
            StartCoroutine(FlashLight2(0.4f));
            Light.SetActive(isLight);
        }
    }
    IEnumerator FlashLight2(float time)
    {
        Debug.Log("çalýþtý"+time);
        yield return new WaitForSeconds(time);
        isLight = !isLight;
        Light.SetActive(isLight);
    }
}