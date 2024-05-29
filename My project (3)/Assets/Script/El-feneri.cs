using UnityEngine;
using System.Collections;

public class El_Feneri : MonoBehaviour
{
    public GameObject Light;
    bool isLight;
    bool shouldContinue = false;

    void Start()
    {
        isLight = true;
        StartCoroutine(FlashLight());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            shouldContinue = true;
        }
        else
        {
            shouldContinue = false;
        }
    }

    IEnumerator FlashLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            isLight = !isLight;
            Light.SetActive(isLight);
            StartCoroutine(FlashLight2(0.1f));
            StartCoroutine(FlashLight2(0.2f));
            isLight = !isLight;
            Light.SetActive(isLight);
            Debug.Log("el feneri 2sn çalýþtý");
        }
    }
    IEnumerator FlashLight2(float time)
    {

        yield return new WaitForSeconds(time);
        isLight = !isLight;
        Light.SetActive(isLight);
    }
}