using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public StaminaControl staminaControl;
    public Slider slider;

    void Start()
    {
        slider.maxValue = staminaControl.maxStamina;
        slider.value = staminaControl.stamina;
    }

    void Update()
    {
        slider.value = staminaControl.stamina;

        if(slider.value==slider.maxValue)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
    }
}

