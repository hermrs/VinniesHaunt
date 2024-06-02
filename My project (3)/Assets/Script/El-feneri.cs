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
    IEnumerator FlashLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            isLight = !isLight;
            Light.SetActive(isLight);
            StartCoroutine(FlashLight2(0.3f));
            
            isLight = !isLight;
            //StartCoroutine(FlashLight2(0.2f));
            Light.SetActive(isLight);
            Debug.Log("el feneri 2sn �al��t�");
        }
    }
    IEnumerator FlashLight2(float time)
    {
        Debug.Log("�al��t�"+time);
        yield return new WaitForSeconds(time);
        isLight = !isLight;
        Light.SetActive(isLight);
    }
}